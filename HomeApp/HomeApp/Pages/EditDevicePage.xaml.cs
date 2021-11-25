using HomeApp.Models;
using System;
using Xamarin.Forms;

namespace HomeApp.Pages
{
	public partial class EditDevicePage : ContentPage
	{
        public static string PageName { get; set; }
        public static string DeviceName { get; set; }
        public static string DeviceDescription { get; set; }
        public HomeDevice HomeDevice { get; set; }


		public EditDevicePage(string pageName, HomeDevice homeDevice = null)
		{
            PageName = pageName;

            if(homeDevice != null)
			{
                HomeDevice = homeDevice;
                DeviceName = homeDevice.Name;
                DeviceDescription = homeDevice.Description;
			}
            else
			{
                HomeDevice = new HomeDevice();
			}

			InitializeComponent();
			OpenEditor();
		}

        public void OpenEditor()
        {
            // Создание однострочного текстового поля для названия
            var newDeviceName = new Entry
            {
                BackgroundColor = Color.AliceBlue,
                Margin = new Thickness(30, 10),
                Placeholder = "Название",
                Text = DeviceName,
                Style = (Style)App.Current.Resources["ValidInputStyle"]
            };
            newDeviceName.TextChanged += (sender, e) => InputTextChanged(sender, e, newDeviceName);
            stackLayout.Children.Add(newDeviceName);

            // Создание многострочного поля для описания
            var newDeviceDscription = new Editor
            {
                HeightRequest = 200,
                BackgroundColor = Color.AliceBlue,
                Margin = new Thickness(30, 10),
                Placeholder = "Описание",
                Text = DeviceDescription,
                Style = (Style)App.Current.Resources["ValidInputStyle"]
            };
            newDeviceDscription.TextChanged += (sender, e) => InputTextChanged(sender, e, newDeviceDscription);
            stackLayout.Children.Add(newDeviceDscription);

            // Создание заголовка для переключателя
            var switchHeader = new Label
            {
                Text = "Не использует газ",
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 5, 0, 0)
            };
            stackLayout.Children.Add(switchHeader);
            // Сздание переключателя
            Switch switchControl = new Switch
            {
                IsToggled = false,
                HorizontalOptions = LayoutOptions.Center,
                ThumbColor = Color.DodgerBlue,
                OnColor = Color.LightSteelBlue
            };
            stackLayout.Children.Add(switchControl);
            // Регистрация обработчика события
            switchControl.Toggled += (sender, e) => SwitchHandler(sender, e, switchHeader);

            // Создание кнопки
            var addButton = new Button
            {
                Text = "Сохранить",
                Margin = new Thickness(30, 10),
                BackgroundColor = Color.Silver
            };
            addButton.Clicked += (sender, e) => SaveButtonClicked(sender, e, new View[] { newDeviceName, newDeviceDscription, switchControl });
            stackLayout.Children.Add(addButton);
        }

        /// <summary>
        /// Кнопка сохранения деактивирует все контолы
        /// </summary>
		private void SaveButtonClicked(object sender, EventArgs e, View[] views)
        {
            foreach (var view in views)
                view.IsEnabled = false;

            HomeDevice.Name = DeviceName;
            HomeDevice.Description = DeviceDescription;
            Navigation.PopModalAsync();
        }

        /// <summary>
        /// Обработчик-валидатор текстовых полей
        /// </summary>
        private void InputTextChanged(object sender, TextChangedEventArgs e, InputView view)
        {
            /*
            // Регулярное выражение для описания специальных символов
            Regex rgx = new Regex("[^A-Za-z0-9]");
            // Не разрешаем использовать специалбные символы в названии и описании, если они есть, то проставляем Invalid
            VisualStateManager.GoToState(view, rgx.IsMatch(view.Text) ? "Invalid" : "Valid");
            */

            if(view is Entry)
			{
                DeviceName = view.Text;
			}
			else
			{
                DeviceDescription = view.Text;
			}
        }

        /// <summary>
        /// Обработка переключателя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="header"></param>
        private void SwitchHandler(object sender, ToggledEventArgs e, Label header)
        {
            if (!e.Value)
            {
                header.Text = "Не использует газ";
                return;
            }

            header.Text = "Использует газ";
        }
    }
}