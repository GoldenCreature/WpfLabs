using System.Windows.Input;

namespace WpfMessenger.Client.Commands;

// 화면 동작과 실행 조건 연결
public sealed class RelayCommand(Action execute, Func<bool>? canExecute= null) : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => canExecute?.Invoke() ?? true;

    public void Execute(object? parameter)
    {
        if (CanExecute(parameter))
            execute();
    }
    public void Refresh() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
