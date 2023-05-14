using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerPrototype
{
    public class TaskManager
    {
        private readonly List<TaskModel> _taskPool;
        private readonly List<TaskModel> _tasks;

        public TaskManager()
        {
            _taskPool = new List<TaskModel>();
            _tasks = new List<TaskModel>();
        }

        public List<TaskViewModel> Tasks
        {
            get { return _tasks.Select(task => new TaskViewModel(task)).ToList(); }
        }

        public void AddTask(string name)
        {
            var prototype = _taskPool.FirstOrDefault(task => task.Name == name);
            if (prototype != null)
            {
                _taskPool.Remove(prototype);
                _tasks.Add(prototype);
            }
            else
            {
                var task = new TaskModel(name);
                _tasks.Add(task);
            }
        }

        public void RemoveTask(TaskModel task)
        {
            _tasks.Remove(task);
            _taskPool.Add(task);
        }
    }
}