using Avalonia.Controls;
using ReactiveUI;

namespace AvaloniaApplication1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private UserControl uc = new AuthorizationPage();
        public UserControl UC { get => uc; set => this.RaiseAndSetIfChanged(ref uc, value); }
    }
}
