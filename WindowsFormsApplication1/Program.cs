using InfraFramework.Repository;
using InfraFramework.Repository.Interfaces;
using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
    
        [STAThread]
        static public void Main()
        {
            IConexaoBDRepository repo = new ConexaoBDRepository();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AddMessage(repo));
        }
    }
}
