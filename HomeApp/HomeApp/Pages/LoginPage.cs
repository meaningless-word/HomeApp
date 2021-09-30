using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Pages
{
    public partial class LoginPage : ContentPage
    {
        // Константа для текста кнопки
        public const string BUTTON_TEXT = "Войти"; 
        // переменная счетчика
        public static int loginCounter = 0;

        public LoginPage()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, EventArgs e)
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
            }
            else if (loginCounter > 5) // Слишком много попыток - показываем ошибку
            {
                // Деактивируем кнопку
                loginButton.IsEnabled = false;
                
                // Получаем последний дочерний элемент, используя свойство Children, затем выполняем распаковку
                var infoMessage = (Label) stackLayout.Children.Last();
                // Задаём текст элемента
                infoMessage.Text = "Слишком много попыток! Попробуйте позже.";

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
                loginButton.Text = $"Выполняется вход... Попыток входа: {loginCounter}";
            }
            
            // Увеличиваем счетчик
            loginCounter += 1;
        }
    }
}