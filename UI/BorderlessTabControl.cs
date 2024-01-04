using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace MusicBox.UI
{
    public class BorderlessTabControl : UserControl
    {
        public List<Panel> panels = new List<Panel>();

        public BorderlessTabControl()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // 初始化控件时的逻辑
        }

        public void AddPanel(Panel panel)
        {
            panel.Dock = DockStyle.Fill; // 确保Panel填满整个PanelTabControl
            panels.Add(panel);
            this.Controls.Add(panel);
            panel.BringToFront(); // 新添加的Panel显示在最前面
            UpdatePanelVisibility();
        }

        public void RemovePanel(Panel panel)
        {
            if (panels.Contains(panel))
            {
                panels.Remove(panel);
                this.Controls.Remove(panel);
            }
            UpdatePanelVisibility();
        }

        private void UpdatePanelVisibility()
        {
            if (panels.Any())
            {
                panels.Last().Visible = true; // 只显示最后添加的Panel
                foreach (var panel in panels.Take(panels.Count - 1))
                {
                    panel.Visible = false;
                }
            }
        }

        public void SwitchToPanel(int panelIndex)
        {
            if (panelIndex >= 0 && panelIndex < panels.Count)
            {
                foreach (var panel in panels)
                {
                    panel.Visible = false;
                }
                panels[panelIndex].Visible = true;
            }
        }

        // 更多方法和属性可以根据需要添加
    }
}
