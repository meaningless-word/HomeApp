using System.ComponentModel;

namespace HomeApp.Models
{
    public class UserInfo : INotifyPropertyChanged
    {
        private string _name;
        private string _email;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    // Вызов уведомления об изменении
                    OnPropertyChanged("Name");
                }
            }
        }
        
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    // Вызов уведомления об изменении
                    OnPropertyChanged("Email");
                }
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string prop = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}