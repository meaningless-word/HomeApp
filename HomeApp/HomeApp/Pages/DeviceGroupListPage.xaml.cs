using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HomeApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceGroupListPage : ContentPage
    {
        /// <summary>
        /// Группируемая коллекция
        /// </summary>
        public ObservableCollection<Group<string, HomeDevice>> DeviceGroups { get; set; } = new ObservableCollection<Group<string, HomeDevice>>();

        /// <summary>
        /// Ссылка на выбранный объект
        /// </summary>
        HomeDevice SelectedDevice;

        public DeviceGroupListPage()
        {
            InitializeComponent();
            
            // Первоначальные данные сохраним в обычном листе
            var initialList = new List<HomeDevice>();
            initialList.Add(new HomeDevice(name:"Чайник", image:"Chainik.png", description:"LG, объем 2л.", room:"Кухня"));
            initialList.Add(new HomeDevice(name:"Стиральная машина", image:"StiralnayaMashina.png", description: "BOSCH", room:"Ванная"));
            initialList.Add(new HomeDevice(name:"Посудомоечная машина", image:"PosudomoechnayaMashina.png", description:"Gorenje", room:"Кухня"));
            initialList.Add(new HomeDevice(name:"Мультиварка", image:"Multivarka.png", description:"Philips", room:"Кухня"));
 
            // Сгруппируем по комнатам
            var devicesByRooms = initialList.GroupBy(d => d.Room).Select(g => new Group<string, HomeDevice>(g.Key, g));
  
            // Сохраним
            DeviceGroups = new ObservableCollection<Group<string, HomeDevice>>(devicesByRooms);
            BindingContext = this;
        }

		private async void NewDeviceButton_Clicked(object sender, System.EventArgs e)
		{
            // Переход на следующую страницу - страницу нового устройства (и помещение её в стек навигации)
            await Navigation.PushAsync(new NewDevicePage());
        }

		private async void LogoutButton_Clicked(object sender, System.EventArgs e)
		{
            // Возврат на первую страницу стека навигации (корневую страницу приложения) - экран логина
            await Navigation.PopAsync();
        }

		private async void EditDeviceButton_Clicked(object sender, System.EventArgs e)
		{
            // проверяем, выбрал ли пользователь устройство из списка
            if (SelectedDevice == null)
            {
                await DisplayAlert(null, $"Пожалуйста, выберите устройство!", "OK");
                return;
            }

            // Переход на следующую страницу - страницу нового устройства (и помещение её в стек навигации)
            await Navigation.PushModalAsync(new EditDevicePage("Изменить устройство", SelectedDevice));

            // Данные вроде бы сохранились, но обновления информации о стиральной машине в общем списке не происходит.
            // Это связано с тем, что наша модель не реализует интерфейс INotifyPropertyChanged,
            // который позволяет зависимым визуальным элементам автоматически реагировать на изменения модели.
            // Для добавления поддержки автоматического обновления, изменим код модели HomeDevice.cs
        }

        /// <summary>
        /// Обработчик выбора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void deviceList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
            // распаковка модели из объекта
            SelectedDevice = (HomeDevice)e.SelectedItem;
        }

        private async void UserProfileButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
    }
}