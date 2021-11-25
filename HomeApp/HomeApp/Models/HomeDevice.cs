using System;
using System.ComponentModel;

namespace HomeApp.Models
{
	public class HomeDevice : INotifyPropertyChanged
	{
		private string _name;
		private string _description;

		public Guid id { get; set; }

		// Обновление этого свойства теперь получают все страницы
		public string Name
		{
			get { return _name; }
			set
			{
				if (_name != value)
				{
					_name = value;
				}
				// Вызов уведомления при изменении
				OnPropertyChanged("Name");
			}
		}
		public string Image { get; set; }
		public string Description
		{
			get { return _description; }
			set
			{
				if (_description != value)
				{
					_description = value;
				}
				// Вызов уведомления при изменении
				OnPropertyChanged("Description");
			}
		}
		public string Room { get; set; }

		public HomeDevice() { }

		public HomeDevice(string name)
		{
			Name = name;
		}
		public HomeDevice(string name, string image = null, string description = null)
		{
			id = Guid.NewGuid();
			Name = name;
			Image = image;
			Description = description;
		}
		public HomeDevice(string name, string image = null, string description = null, string room = null)
		{
			id = Guid.NewGuid();
			Name = name;
			Image = image;
			Description = description;
			Room = room;
		}

		/* Реализация интерфейса InotifyPropertyChanged для автоматического обновления интерфейса во всех страницах при обновлении модели */

		/// <summary>
		/// Делегат, указывающий на метод-обработчик события PropertyChanged, возникающего при изменении свойств компонента
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Метод, вызывающий событие PropertyChanged
		/// </summary>
		/// <param name="prop"></param>
		public void OnPropertyChanged(string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}
