using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace TaskManagerPrototype
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly TaskManager _taskManager;

        public MainWindowViewModel()
        {
            _taskManager = new TaskManager();
            Tasks = new ObservableCollection<TaskViewModel>(_taskManager.Tasks);
            AddTaskCommand = new RelayCommand(AddTask);
        }

        public string NewTaskName { get; set; }
        public ObservableCollection<TaskViewModel> Tasks { get; }

        public ICommand AddTaskCommand { get; }

        private void AddTask()
        {
            _taskManager.AddTask(NewTaskName);
            NewTaskName = "";
            OnPropertyChanged(nameof(NewTaskName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}