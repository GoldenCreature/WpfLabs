using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wpf03MVVM.Commands
{
    /*
        Command : View의 사용자 동작을 ViewModel의 기능과 연결
        -> MVVM에서는 Button의 Click Event 대신 
           Command를 사용하여 View와 동작을 분리하겠다.
        
        Command Pattern
         - 실행할 동작을 하나의 객체로 만들어 처리하는 디자인 패턴
         - ICommand를 통해 Command를 구현하고,
           View의 동작을 ViewModel과 연결할 때 활용
    */
    public class RelayCommand : ICommand
    {
        private readonly Action<Object?> _execute;
        private readonly Predicate<Object?> _canExecute;

        public RelayCommand(
            Action<object?> execute, // 실행할 메소드
            Predicate<object?>? canExecute = null) // 실행 가능 여부를 판단할 매소드
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public event EventHandler? CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(
                this, EventArgs.Empty );
        }
    }
}
