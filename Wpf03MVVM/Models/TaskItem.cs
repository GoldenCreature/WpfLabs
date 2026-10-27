using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpf03MVVM.Models
{
    /*
        Models
        Model : 프로그램에서 다루는 데이터의 형태를 표현하는 객체 
        
        TaskItem : 하나의 업무를 표현하는 사용자 정의 Model 
         -> 본 프로젝트에서는 업무명(Title), 진행률(Progress)을 관리

        INotifyPropertyChanged
         - Source의 Property가 변경되었음을 WPF Binding 시스템에 알려주는 인터페이스
         
        Source : 원본, Binding에서 데이터를 제공하는 쪽
        Target : 대상, Source의 데이터를 받아 사용하는 UI Property
            TaskItem의 Property는 Source가 되고,
            TextBox.Text, ProgressBar.Value 등이 Target이 된다.
        
        
    */
    public class TaskItem : INotifyPropertyChanged
    {
        // 실제 값을 저장하는 Field

        private string _title; // 업무명
        private int _progress; // 진행률

        // 생성할 떄 업무명과 진행률을 전달받아 초기화
        public TaskItem(string title, int progress)
        {
            _title = title;
            _progress = progress;
        }

        /*
            Title
            업무명을 저장하는 Property
            TextBox.Text와 Binding
        */
        public string Title
        {
            get => _title;
            set
            {
                // 이전 값과 같으면 불필요한 변경 알림을 발생시키지 않겠다.
                if (_title == value) return;

                _title = value;

                // Title 변경 사실을 WPF Binding 시스템에 알리겠다.
                OnPropertyChanged();
            }
        }

        /*
            Progress = 진행, 진행 정도
            업무 진행률을 0 ~ 100 사이의 숫자로 저장하는 Property
        */
        public int Progress
        {
            get => _progress;
            set
            {
                if (_progress == value) return;

                _progress = value;
                OnPropertyChanged();
            }
        }



        /*
            Event : 이벤트, 어떤 변화가 발생했음을 알리는 기능
            PropertyChanged : 어떤 Property가 변경되었는지 WPF에 전달
        */
        public event PropertyChangedEventHandler? PropertyChanged;

        /*
            CallerMemberName
                Caller : 호출한 쪽
                Member : 멤버
                Name   : 이름
            호출한 Property 이름을 자동으로 propertyName에 전달!
        */
        protected void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
    

    
    
}
