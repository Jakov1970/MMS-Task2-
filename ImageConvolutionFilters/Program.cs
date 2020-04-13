using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

//---------------------------------------------------
//
//GITHUB link https://github.com/Jakov1970/MMS-Task2- 
//za slucaj da ne mozete da se snadjete 
//
//---------------------------------------------------

namespace MeanRemovalAndSphere
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
            Application.Run(new MainForm());
        }
    }
}
