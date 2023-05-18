using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace TaskManagerPrototype
{
    public class MainWindowViewModel 
    {
        private readonly TaskManager _taskManager;

        public MainWindowViewModel()
        {
            _taskManager = new TaskManager();
            Tasks = new ObservableCollection<TaskModel>(_taskManager.Tasks);
            AddTaskCommand = new RelayCommand(AddTask);
        }

        public string NewTaskName { get; set; }
        public ObservableCollection<TaskModel> Tasks { get; }

        public ICommand AddTaskCommand { get; }

        private void AddTask()
        {
            _taskManager.AddTask(NewTaskName);
            NewTaskName = "";
        }
    }
}