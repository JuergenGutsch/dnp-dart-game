using System.Windows.Input;

namespace go.dnp.dart.gui.ViewModels.Commands
{
    public interface IAppCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}