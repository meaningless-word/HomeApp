using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewDevicePage : ContentPage
    {
        public NewDevicePage()
        {
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
                Text = "Добавить",
                Margin = new Thickness(30, 10),
                BackgroundColor = Color.Silver
            };
            addButton.Clicked += (sender, e) => AddButtonClicked(sender, e, new View[] { newDeviceName, newDeviceDscription, switchControl});
            stackLayout.Children.Add(addButton);
        }

        /// <summary>
        /// Кнопка сохранения деактивирует все контолы
        /// </summary>
		private void AddButtonClicked(object sender, EventArgs e, View[] views)
		{
            foreach (var view in views)
                view.IsEnabled = false;
		}

		/// <summary>
		/// Обработчик-валидатор текстовых полей
		/// </summary>
		private void InputTextChanged(object sender, TextChangedEventArgs e, InputView view)
		{
            // Регулярное выражение для описания специальных символов
            Regex rgx = new Regex("[^A-Za-z0-9]");
            // Не разрешаем использовать специалбные символы в названии и описании, если они есть, то проставляем Invalid
            VisualStateManager.GoToState(view, rgx.IsMatch(view.Text) ? "Invalid" : "Valid");
		}

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