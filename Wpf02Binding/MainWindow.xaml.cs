using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf02Binding.Models;

namespace Wpf02Binding
{
    /*
        MainWindow.xaml
    */
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private TaskItem? _selectedTask;

        // Tasks : 업무 목록
        public ObservableCollection<TaskItem> Tasks { get; }
            = new ObservableCollection<TaskItem>();

        // SelectedTask : 선택된 업무
        public TaskItem? SelectedTask
        {
            get => _selectedTask;
            set
            {
                if(_selectedTask == value) return;

                _selectedTask = value;

                OnPropertyChanged();
            }
        }
       
        public MainWindow()
        {
            InitializeComponent();

            // MainWindow 자체를 Binding의 기본 Source로 지정
            DataContext = this;

            // 초기 업무 데이터

            Tasks.Add(new TaskItem("프로젝트 제안서 작성", 70));
            Tasks.Add(new TaskItem("WPF 화면 설계", 30));
            Tasks.Add(new TaskItem("Web API 연동", 0));
            
            // 1번째 업무를 기본 선택
            if(Tasks.Count > 0)
            {
                SelectedTask = Tasks[0];
            }

        }

        private void DeleteTaskButton_Click(
            Object sender,
            RoutedEventArgs e)
        {
            if (SelectedTask == null) return;

            // 선택된 업무를 삭제
            Tasks.Remove(SelectedTask);

            // 삭제 후 업무가 남아 있으면 1번째 업무 선택 
            if(Tasks.Count > 0)
            {
                SelectedTask = Tasks[0];
            }
            else // *** 없다면 변수에 남아있던 데이터를 null로 초기화 ***
            {
                SelectedTask = null;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}