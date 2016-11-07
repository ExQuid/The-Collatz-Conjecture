using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MathEq
{
    public partial class Program : Application
    {
        [STAThread]
        public static void Main(string[] args)
        {
            // Tries, so if the application encounters any problems it wont crash. 
            try
            {
                // Starts the application
                Application application = new Application();
                application.Run(new TCC_Client());
            }
            catch (Exception ex)
            {
                // Shows an message about the exception
                MessageBox.Show(ex.ToString());
            }
        }
    }
}