using Avalonia.Controls;
using AvaloniaApplication1.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;

namespace AvaloniaApplication1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        static AvaloniaTestBaseContext DBConnect = new AvaloniaTestBaseContext();
        
        //private bool adminRole = false;
        //public bool AdminRole { get => adminRole; set => adminRole = value; }
        
        private UserControl uc = new AuthorizationPage();
        public UserControl UC { get => uc; set => this.RaiseAndSetIfChanged(ref uc, value); }


        string textAdmin;
        public string AdminText { get => textAdmin; set { textAdmin = value; AdminPage(); } }

        void AdminPage()
        {
            if(textAdmin == "0000")
            {
                Service.AdminButtons = true;
                UC = new AuthorizationPage();
            }
            else
            {
                Service.AdminButtons = false;
                UC = new AuthorizationPage();
            }

        }


        #region AuthorizationPage
        private AuthorizationViewModel pageAuthorizationViewVM = new AuthorizationViewModel(DBConnect);
        public AuthorizationViewModel PageAuthorizationViewVM { get => pageAuthorizationViewVM; set => pageAuthorizationViewVM = value; }
        #endregion
    }
}
