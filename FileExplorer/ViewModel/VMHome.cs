using FileExplorer.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using Microsoft.Win32;
using WPFFolderBrowser;

namespace FileExplorer.ViewModel
{
    public class VMHome: ViewModelBase
    {
        private readonly BaseController _baseCommand;
        

        private string _selectedFolder;


        
        public VMHome()
        {
             _baseCommand = new BaseController(CommandHandler, CommandCanExecute);
        }


        #region ICommand Methods

        public void CommandHandler(object commandParameter)
        {
            switch (commandParameter.ToString())
            {
                case "OpenFolder":
                    OpenSearchDirectory();
                    break;
            }
        }

        public bool CommandCanExecute(string commandParameter)
        {
            return true;
        }

        #endregion


        private void OpenSearchDirectory()
        {
            WPFFolderBrowserDialog fb = new WPFFolderBrowserDialog();
            if (fb.ShowDialog() == true)
            {
                Console.WriteLine(fb.FileName);
                SelectedFolder = fb.FileName;
                PropertyChangedNotify("SelectedFolder");
            }
        }

        


        #region Binding Properties

        public ICommand CommandBase
        {
            get { return _baseCommand; }
        }

        public string SelectedFolder { get => _selectedFolder; set => _selectedFolder = value; }

        #endregion
    }
}
