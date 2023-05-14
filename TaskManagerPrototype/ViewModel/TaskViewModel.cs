using System.ComponentModel;
using System.Threading.Tasks;

namespace TaskManagerPrototype
{
    public class TaskViewModel 
    {
        private readonly TaskModel _task;

        public TaskViewModel(TaskModel task)
        {
            _task = task;
        }

        public string Name
        {
            get { return _task.Name; }
            set
            {
                _task.Name = value;
            }
        }

        public bool IsComplete
        {
            get { return _task.IsComplete; }
            set
            {
                _task.IsComplete = value;
            }
        }
    }
}