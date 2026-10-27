using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wpf03MVVM.Commands;
using Wpf03MVVM.Models;

namespace Wpf03MVVM.ViewModels
{
    /*
        ViewModel : View를 위한 데이터와 기능을 제공하는 객체
                   
     */
    public class MainViewModel : INotifyPropertyChanged
    {
        private TaskItem? _selectedTask;

        public ObservableCollection<TaskItem> Tasks { get; }
            = new ObservableCollection<TaskItem>();

        public TaskItem? SelectedTask
        {
            get => _selectedTask;

            set
            {
                if(_selectedTask != value)
                {
                    _selectedTask = value;
                    OnPropertyChanged();

                    DeleteTaskCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public RelayCommand DeleteTaskCommand { get; }

        public MainViewModel()
        {
            DeleteTaskCommand = new RelayCommand(
                    DeleteTask,
                    CanDeleteTask
                );

            // 초기 업무 데이터
            Tasks.Add(new TaskItem("프로젝트 제안서 작성", 90));
            Tasks.Add(new TaskItem("WPF 화면 설계", 65));
            Tasks.Add(new TaskItem("Web API 연동", 20));

            if (Tasks.Count > 0)
            {
                SelectedTask = Tasks[0];
            }
        }

        // DeleteTask : 현재 선택된 업무를 삭제
        private void DeleteTask(object? parameter)
        {
            if(SelectedTask == null)
            {
                return;
            }

            Tasks.Remove(SelectedTask);

            if(Tasks.Count > 0)
            {
                SelectedTask = Tasks[0];
            }
            else
            {
                SelectedTask = null;
            }
        }

        // CanDeleteTask : 현재 업무를 삭제할 수 있는지 판단
        private bool CanDeleteTask(object? parameter)
        {
            return SelectedTask != null;
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }
        
    }
}
