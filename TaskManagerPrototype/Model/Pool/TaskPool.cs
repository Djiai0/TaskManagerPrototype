using System.Collections.Generic;

namespace TaskManagerPrototype
{
    public class TaskPool<TaskModel> where TaskModel : class, new() // pool des tâches
    {
        private readonly Queue<TaskModel> _objects = new Queue<TaskModel>();
        private readonly int _poolSize;

        public TaskPool(int poolSize)
        {
            _poolSize = poolSize;
        }

        public TaskModel GetObject()
        {
            if (_objects.Count == 0)
            {
                for (var i = 0; i < _poolSize; i++) 
                {
                    _objects.Enqueue(new TaskModel());
                }
            }
            return _objects.Dequeue(); // repenser cette partie (entrer les données qui m'intéressent)
        }

        public void ReleaseObject(TaskModel obj)
        {
            if (_objects.Count < _poolSize)
            {
                _objects.Enqueue(obj);
            }
        }
    }
}



// task pool doit être update par le taskmanager (évolution des tâches) update les deux listes // les deux listes contiennent les mêmes données
// si je supprime dans la queue, je supprime dans la pool (exemple) avoir les mêmes données dans les deux listes à tout moment
// faire ça dans le task manager