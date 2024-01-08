using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // 确保引入 System.Windows.Forms 命名空间
using static MusicBox.Core.Dtos.Album;
using static MusicBox.Core.Dtos.Artist;

namespace MusicBox.UI.CustomList
{
    internal class SearchPanel : Panel
    {
        private TextBox searchBox; // 定义一个 TextBox 成员变量作为搜索框

        public SearchPanel()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // 创建搜索框
            searchBox = new TextBox();
            searchBox.Size = new Size(400, 20); // 设置宽度为 400，高度为 100
            searchBox.Location = new Point(100, 10); // 设置合适的位置
            searchBox.BackColor = Color.FromArgb(36, 36, 36);
            searchBox.Font = new Font("Microsoft YaHei UI", 25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            searchBox.ForeColor = Color.White;
            searchBox.PlaceholderText = "想听什么？"; 
            // 将搜索框添加到面板中
            this.Controls.Add(searchBox);
        }
    }
}
