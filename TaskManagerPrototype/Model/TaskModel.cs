using System.ComponentModel;

namespace TaskManagerPrototype
{
    public class TaskModel : INotifyPropertyChanged
    {
        private string _name;
        private bool _isComplete;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public bool IsComplete
        {
            get => _isComplete;
            set
            {
                if (_isComplete != value)
                {
                    _isComplete = value;
                    OnPropertyChanged(nameof(IsComplete));
                }
            }
        }

        public TaskModel(string name)
        {
            Name = name;
            IsComplete = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}