using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerPrototype
{
    public class TaskManager
    {
        private readonly List<TaskModel> _taskPool = new List<TaskModel>(); // 
        private readonly List<TaskModel> _tasks = new List<TaskModel>(); // ??

        public TaskManager()
        {
            // remplir la pool des tâches avec les tâches stockées dans un fichier et non complétées
            // fonction qui return la liste des tâches
        }

        public List<TaskModel> Tasks
        {
            get => _tasks;  // récupérer la liste des tâches
        }

        public void AddTask(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Task name cannot be empty.");
            }

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
            _tasks.Remove(task); // tasks : liste des tâches non complétées (fichier)
            _taskPool.Add(task); // taskPool : liste des tâches complétées (ram)
        }
        // fonction de sauvegarde des tâches dans un fichier
        // fonction de chargement des tâches depuis un fichier
    }
}