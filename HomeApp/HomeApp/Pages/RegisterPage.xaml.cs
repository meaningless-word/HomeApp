using Xamarin.Forms;

namespace HomeApp.Pages
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();

            // определяем триггер для поля ввода
            var entryTrigger = new Trigger(typeof(Entry))
            {
                Property = Entry.IsFocusedProperty,
                Value = true
            };
            entryTrigger.Setters.Add(new Setter
            {
                Property = Entry.BackgroundColorProperty,
                Value = Color.Gray
            });

            // добавляем триггер
            emailEntry.Triggers.Add(entryTrigger);

            // так же для триггеров можно задавать дополнительные действия, используя класс TriggerAction<T>
            // для этого необходимо добавить новый класс-обработчик действия
            // это будет EmailTriggerAction, унаследованный от TriggerAction<T>
            // подключение в XAMLе
        }
    }
}