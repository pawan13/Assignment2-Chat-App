using MvvmHelpers;
using Xamarin.Forms;
using ChatApp.Interfaces;
using ChatApp.Cores;
namespace ChatApp.ViewModel
{
    public class ViewModelBase : BaseViewModel
    {
        ChatService chatService;
        public ChatService ChatService =>
            chatService ?? (chatService = DependencyService.Resolve<ChatService>());

        IDialogService dialogService;
        public IDialogService DialogService =>
            dialogService ?? (dialogService = DependencyService.Resolve<IDialogService>());
    }
}
