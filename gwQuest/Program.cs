using gwQuest.Domain;
using gwQuest.Repository;
using System;
using System.Windows.Forms;

namespace gwQuest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(new QuestService(new QuestRepository("quests.json")), new SettingsRepository("settings.json")));
        }
    }
}
