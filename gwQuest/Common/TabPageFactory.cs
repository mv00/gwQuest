using System.Windows.Forms;

namespace gwQuest.Common
{
    public static class TabPageFactory
    {
        public static TabPage CreateTabPage(string name, int index, string text)
        {
            return new TabPage
            {
                TabIndex = index,
                Text = text,
                Name = name,
                Location = new System.Drawing.Point(4, 22),

                Padding = new Padding(3),
                Size = new System.Drawing.Size(1180, 593),
                UseVisualStyleBackColor = true
            };
    }
    }
}
