using System.Collections.Generic;

namespace TaskManagerPrototype
{
    public class TaskPool<T> where T : class, new()
    {
        private readonly Queue<T> _objects = new Queue<T>();
        private readonly int _poolSize;

        public TaskPool(int poolSize)
        {
            _poolSize = poolSize;
        }

        public T GetObject()
        {
            if (_objects.Count == 0)
            {
                for (var i = 0; i < _poolSize; i++)
                {
                    _objects.Enqueue(new T());
                }
            }
            return _objects.Dequeue();
        }

        public void ReleaseObject(T obj)
        {
            if (_objects.Count < _poolSize)
            {
                _objects.Enqueue(obj);
            }
        }
    }
}