using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DeviceControlPage : ContentPage
	{
		public DeviceControlPage()
		{
			InitializeComponent();
			GetContent();
		}

		private void GetContent()
		{
			// Создадим виджет выбора даты
			var datePickerText = new Label { Text = "Дата запуска", Margin = new Thickness(0, 20, 0, 0) };
			var datePicker = new DatePicker
			{
				Format = "D",
				// диапазон дат +/- неделя
				MaximumDate = DateTime.Now.AddDays(7),
				MinimumDate = DateTime.Now.AddDays(-7)
			};

			// Добавляем на страницу
			stackLayout.Children.Add(datePickerText);
			stackLayout.Children.Add(datePicker);

			// Регистрируем обработчик события выбора даты
			datePicker.DateSelected += (sender, e) => DateSelectedHandler(sender, e, datePickerText);


			// Виджет выбора времени
			var timePickerText = new Label { Text = "Время запуска", Margin = new Thickness(0,20,0,0) };
			var timePacker = new TimePicker
			{
				Time = new TimeSpan(13, 0, 0)
			};

			stackLayout.Children.Add(timePickerText);
			stackLayout.Children.Add(timePacker);

			// Регистрируем обработчик события выбора времени
			timePacker.PropertyChanged += (sender, e) => TimeChangedHandler(sender, e, timePickerText, timePacker);


			// Создаём меню выбора в виде выпадающего списка с текстовым заголовком
			var pickerText = new Label { Text = "Напряжение сети, В", Margin = new Thickness(0, 20, 0, 0) };
			var picker = new Picker { Title = "Выберите напряжение сети" };
			// Добавялем значения выпадающего списка для пользовательского выбора
			picker.Items.Add("220");
			picker.Items.Add("120");
			// Добавляем элементы на страницу
			stackLayout.Children.Add(pickerText);
			stackLayout.Children.Add(picker);

			// Slider выбора температур
			Slider slider = new Slider
			{
				Minimum = -30,
				Maximum = 30,
				Value = 5.0,
				ThumbColor = Color.DodgerBlue,
				MinimumTrackColor = Color.DodgerBlue,
				MaximumTrackColor = Color.Gray
			};
			var sliderText = new Label { Text = $"Температура: {slider.Value} °C", HorizontalOptions = LayoutOptions.Center, Margin = new Thickness(0, 30, 0, 0) };
			stackLayout.Children.Add(sliderText);
			stackLayout.Children.Add(slider);

			// Регистрируем обработчик события выбора температуры
			slider.ValueChanged += (sender, e) => TempChangedHandler(sender, e, sliderText);


			// Кнопка сохранения
			var saveButton = new Button
			{
				Text = "Сохранить",
				BackgroundColor = Color.Silver,
				Margin = new Thickness(0, 5, 0, 0)
			};

			saveButton.Clicked += SaveButtonClick;
			stackLayout.Children.Add(saveButton);

		}

		private void TempChangedHandler(object sender, ValueChangedEventArgs e, Label header)
		{
			header.Text = String.Format("Температура: {0:F1}°C", e.NewValue);
		}

		private void TimeChangedHandler(object sender, PropertyChangedEventArgs e, Label timePickerText, TimePicker timePacker)
		{
			// Обновляем текст сообщения, когда появляется новое значение времени
			if (e.PropertyName == "Time")
				timePickerText.Text = "В " + timePacker.Time;
		}

		private void DateSelectedHandler(object sender, DateChangedEventArgs e, Label datePickerText)
		{
			// При срабатывании выбора будет меняться информационное сообщение
			datePickerText.Text = "Запустится " + e.NewDate.ToString("dd/MM/yyyy");
		}

		/// <summary>
		/// Обработчик кнопки сохранения
		/// </summary>
		private void SaveButtonClick(object sender, EventArgs e)
		{
			// После сохранения параметров отключаем пользователю возможность редактирования
			deviceEntry.IsEnabled = false;
		}
	}
}