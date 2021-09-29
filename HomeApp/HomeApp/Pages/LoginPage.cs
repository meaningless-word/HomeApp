using System;
using Xamarin.Forms;

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
                // Показывваем текстовое сообщение об ошибке
                errorMessage.Text = "Слишком много попыток! Попробуйте позже.";
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