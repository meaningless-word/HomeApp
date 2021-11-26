using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HomeApp.Pages
{
	public partial class LoginPage : ContentPage
	{
		// Константа для текста кнопки
		public const string BUTTON_TEXT = "Войти";
		// переменная счетчика
		public static int loginCounter = 0;

		// Создаём объект, возвращающий свойства устройства
		IDeviceDetector detector = DependencyService.Get<IDeviceDetector>();

		public LoginPage()
		{
			InitializeComponent();

			// С помощью свойства Device.Idiom можно определить тип устройства, на которомм запущено приложение
			// Изменяем внешний вид кнопки для Desktop-версии
			if (Device.Idiom == TargetIdiom.Desktop)
				loginButton.CornerRadius = 0;

			// Передаём информацию о платформе на экран
			runningDevice.Text = detector.GetDevice();

			// Устанавливаем динамический ресурс с помощью специального метода
			infoCounter.SetDynamicResource(Label.TextColorProperty, "growingColor");
			infoCounter.SetDynamicResource(Label.FontSizeProperty, "growingFont");
		}
		/// <summary>
		/// По клику обрабатываем счётчик и выводим на экран разные сообщения
		/// </summary>
		private async void Login_Click(object sender, EventArgs e)
		{
			//loginButton.Text = "Выполняется вход...";
			/*
            // можно так, но снижается производиетельность
            string xaml =  "<Button Text=\"⌛ Выполняется вход..\"  />";
            loginButton.LoadFromXaml(xaml);
            */

			if (loginCounter == 0)
			{
				// Если первая попытка - просто меняем сообщения
				loginButton.Text = $"Выполняется вход";
				// Имитация задержки (приложение загружает данные с сервера)
				await Task.Delay(150);

				// Переход на следующую страницу
				await Navigation.PushAsync(new DeviceGroupListPage());

				// Восстановим первоначальный текст на кнопке (на случай, если пользователь вернется на этот экран чтобы выполнить вход снова)
				loginButton.Text = BUTTON_TEXT;
			}
			else if (loginCounter > 5) // Слишком много попыток - показываем ошибку
			{
				// Деактивируем кнопку
				loginButton.IsEnabled = false;

				// Получаем последний дочерний элемент, используя свойство Children, затем выполняем распаковку
				var _infoMessage = (Label)stackLayout.Children.Last();
				// но после добавления лейбла runningDevice такой способ не канает


				// Задаём текст элемента
				infoMessage.Text = "Слишком много попыток! Попробуйте позже.";
				/* // Отставить красный цвет - определяем цвет для исползьования в качестве ресурса
				// Задаём красный цвет сообщения
				infoMessage.TextColor = Color.FromRgb(255, 0, 0);
				*/
				// Новый цвет для информационных сообщений
				var warningColor = Color.FromHex("#ffa500");
				// Добавляем в словарь ресурсов
				Resources.Add("warningColor", warningColor);
				// Используем добавленный ресурс
				infoMessage.TextColor = (Color)Resources["warningColor"];
				// А так можно использовать глобальный ресурс, заданный в app.xaml
				infoMessage.TextColor = (Color)Application.Current.Resources["errorColor"];

				/*
                // Добавляем элемент через свойство Children
                stackLayout.Children.Add(new Label
                {
                    Text = "Слишком много попыток! Попробуйте позже.",
                    TextColor = Color.Red,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Padding = new Thickness()
                    {
                        Bottom = 30,
                        Left = 10,
                        Right = 10,
                        Top = 30
                    }
                });
                */

				/*
                // Показывваем текстовое сообщение об ошибке
                errorMessage.Text = "Слишком много попыток! Попробуйте позже.";
                */
			}
			else
			{
				// Изменяем текст кнопки и показываем количество попыток входа
				//loginButton.Text = $"Выполняется вход... Попыток входа: {loginCounter}";
				// переделано для демонстрации динамических ресурсов

				// Обновление динамического ресурса
				Resources["growingFont"] = 10 + loginCounter * 5;
				Resources["growingColor"] = Color.FromRgb(255, 255 - loginCounter * 50, 0);

				loginButton.Text = $"Выполняется вход...";
				infoCounter.Text = $" Попыток входа: {loginCounter}";
			}

			// Увеличиваем счетчик
			loginCounter += 1;
		}
	}
}