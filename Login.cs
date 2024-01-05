using MusicBox.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicBox
{
    public partial class Login : Form
    {
        //
        // 调整非客户区颜色为黑色
        //
        [DllImport("dwmapi.dll", PreserveSig = true)]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        public Login()
        {
            InitializeComponent();
            int TitlebarDarkColour = 0x000000;
            DwmSetWindowAttribute(this.Handle, 35, ref TitlebarDarkColour, System.Runtime.InteropServices.Marshal.SizeOf(TitlebarDarkColour));
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            var isSuccess = await UserAPI.PostLoginAsync(AccountTextBox.Text, PasswordTextBox.Text);
            if (isSuccess.Equals("success"))
            {
                Form musicbox = new MusicBox();
                this.Hide();
                UserAPI.favoriteResponse = await ListAPI.GetFavoriteSongsAsync();
                musicbox.Show();
                Debug.WriteLine("Login Success");
            }
            else
            {
                ErrorLabel.Text = "登录错误： " + isSuccess;
                ErrorLabel.Visible = true;
                Debug.WriteLine("Login Failed");
            }
        }
    }
}
