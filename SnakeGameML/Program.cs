using System;
using SnakeGameML.Implementation;
using System.Windows.Forms;

namespace SnakeGameML
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
            //Application.Run(new SnakeForm());

            //Application.Run(new SnakeForm(new RandomSnakeController()));

            Application.Run(new DataCollectionForm());
        }
    }
}
