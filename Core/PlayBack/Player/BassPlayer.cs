using MusicBox.Core.Common;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Un4seen.Bass;

namespace MusicBox.Core.PlayBack.Player
{
    public class BassPlayer
    {
        private int _stream; // 用于音频流的句柄
        private int nowStatus; // 0 - 未加载 1 - 加载完毕，暂停状态 2 - 播放状态
        private bool autoRepeat; // 是否自动重播

        public event EventHandler TrackEnded; // 定义一个事件，当歌曲播放完毕时触发

        public BassPlayer(bool autoRepeat = false)
        {
            // 初始化Bass
            if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, nint.Zero))
            {
                Debug.WriteLine("Bass 初始化失败!");
            }
            nowStatus = 0;
            this.autoRepeat = autoRepeat;
        }

        // 载入音频文件
        public void LoadAudio(string source)
        {
            float nowVolum = GetVolume();
            // 先释放之前的音频流
            if (_stream != 0)
                Bass.BASS_StreamFree(_stream);

            // 检查 source 是文件路径还是 URL
            if (source.StartsWith("http"))
            {
                // 从 URL 创建音频流，但不使用 BASS_STREAM_BLOCK
                string encodedUrl = UrlConverter.EncodeUrl(source);
                _stream = Bass.BASS_StreamCreateURL(encodedUrl, 0, BASSFlag.BASS_STREAM_STATUS, null, IntPtr.Zero);
            }
            else
            {
                // 从文件创建音频流
                _stream = Bass.BASS_StreamCreateFile(source, 0, 0, BASSFlag.BASS_DEFAULT);
            }

            if (_stream == 0)
            {
                BASSError error = Bass.BASS_ErrorGetCode();
                Debug.WriteLine($"载入音频源失败! Error:{error}");
                return;
            }
            if(nowStatus == 0)
            {
                nowStatus = 1;
                nowVolum = (float)0.35;
            }
            SetVolume(nowVolum);
            // 设置歌曲播放完毕的事件处理器
            Bass.BASS_ChannelSetSync(_stream, BASSSync.BASS_SYNC_END, 0, new SYNCPROC(EndTrack), IntPtr.Zero);
        }

        // 开始播放
        public void Play()
        {
            if (!Bass.BASS_ChannelPlay(_stream, false))
            {
                Debug.WriteLine("播放失败!");
            }
        }

        // 停止播放
        public void Stop()
        {
            if (!Bass.BASS_ChannelStop(_stream))
            {
                Debug.WriteLine("停止播放失败!");
            }
        }

        // 获取音乐总时长（以秒为单位）
        public double GetTotalDurationInSeconds()
        {
            long length = Bass.BASS_ChannelGetLength(_stream);
            return Bass.BASS_ChannelBytes2Seconds(_stream, length);
        }

        // 获取当前播放到的时长（以秒为单位）
        public double GetCurrentPositionInSeconds()
        {
            long position = Bass.BASS_ChannelGetPosition(_stream);
            return Bass.BASS_ChannelBytes2Seconds(_stream, position);
        }

        // 获取音量（返回值为0到1之间）
        public float GetVolume()
        {
            float volume = 0;
            Bass.BASS_ChannelGetAttribute(_stream, BASSAttribute.BASS_ATTRIB_VOL, ref volume);
            return volume;
        }

        public void CheckHTTPHeaders(int stream)
        {
            IntPtr httpHeadersPtr = Bass.BASS_ChannelGetTags(stream, BASSTag.BASS_TAG_HTTP);
            if (httpHeadersPtr != IntPtr.Zero)
            {
                string httpHeaders = Marshal.PtrToStringAnsi(httpHeadersPtr);
                Debug.WriteLine("HTTP Headers:\n" + httpHeaders);
            }
            else
            {
                Debug.WriteLine("无法获取 HTTP 头部信息");
            }
        }

        // 设置当前播放到的时长（以秒为单位）
        public void SetCurrentPosition(double seconds)
        {
            // 将秒转换为字节位置
            long position = Bass.BASS_ChannelSeconds2Bytes(_stream, seconds);

            // 设置播放位置
            if (!Bass.BASS_ChannelSetPosition(_stream, position))
            {
                BASSError error = Bass.BASS_ErrorGetCode();
                Debug.WriteLine($"设置播放位置失败，错误代码: {error}");
            }
        }

        // 调整音量（volume取值范围0到1）
        public void SetVolume(float volume)
        {
            if (!Bass.BASS_ChannelSetAttribute(_stream, BASSAttribute.BASS_ATTRIB_VOL, volume))
            {
                Debug.WriteLine("设置音量失败!");
            }
        }

        // 清理资源
        public void Dispose()
        {
            if (_stream != 0)
                Bass.BASS_StreamFree(_stream);
            Bass.BASS_Free();
        }

        private void EndTrack(int handle, int channel, int data, IntPtr user)
        {
            TrackEnded?.Invoke(this, EventArgs.Empty); // 触发事件
        }
    }
}
