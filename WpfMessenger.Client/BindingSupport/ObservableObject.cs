using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfMessenger.Client.BindingSupport;

// INotifyPropertyChanged를 공통 구현하여 ViewModel 속성 변경을 View에 전달
public abstract class ObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    // 값이 달라질 때만 변경을 알림
    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? name = null)
    {
        if(EqualityComparer<T>.Default.Equals(field, value)) 
            return false;

        else
        {
            field = value;
            Notify(name);
            return true;
        }
    }

    // WPF 바인딩에 속성 변경 전달
    // ?.Invoke는 이벤트 구독자가 있을 때만 변경 알림 호출
    protected void Notify([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new(name));
    }

}
