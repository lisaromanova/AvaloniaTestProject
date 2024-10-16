using Avalonia.Controls;
using AvaloniaApplication1.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;

namespace AvaloniaApplication1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        static AvaloniaTestBaseContext DBConnect = new AvaloniaTestBaseContext();

        private UserControl uc = new AuthorizationPage();
        public UserControl UC { get => uc; set => this.RaiseAndSetIfChanged(ref uc, value); }

        #region AuthorizationPage
        private AuthorizationViewModel pageAuthorizationViewVM = new AuthorizationViewModel(DBConnect);
        public AuthorizationViewModel PageAuthorizationViewVM { get => pageAuthorizationViewVM; set => pageAuthorizationViewVM = value; }
        #endregion
    }
}
