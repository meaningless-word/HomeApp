using HomeApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceListPage : ContentPage
    {
        // усложним задачу - будем использовать список моделей
        /*
        public List<string> Devices { get; set; } = new List<string>();
        */
        
        // Вместо обычного List использовать для хранения модели данных Devices другой тип коллекции,
        // которая автоматически генерирует уведомления о происходящих со своими элементами событиями верно
        // public List<HomeDevice> Devices { get; set; } = new List<HomeDevice>();
        public ObservableCollection<HomeDevice> Devices { get; set; } = new ObservableCollection<HomeDevice>();
        
        public DeviceListPage()
        {
            InitializeComponent();
            // поменяется заполнение листа
            /*
            Devices.Add("Чайник");
            Devices.Add("Стиральная машина");
            Devices.Add("Посудомоечная машина");
            Devices.Add("Мультиварка");
            Devices.Add("Водонагреватель");
            Devices.Add("Плита");
            Devices.Add("Микроволновая печь");
            Devices.Add("Духовой шкаф");
            Devices.Add("Холодильник");
            Devices.Add("Увлажнитель воздуха");
            Devices.Add("Телевизор");
            Devices.Add("Пылесос");
            Devices.Add("музыкальный центр");
            Devices.Add("Компьютер");
            Devices.Add("Игровая консоль");
            */
            
            // Заполняем список устройств
            // дополним ссылками на картинки
            Devices.Add(new HomeDevice(name:"Чайник", description: "LG, объем 2л.", image: "Chainik.png"));
            Devices.Add(new HomeDevice(name:"Стиральная машина", description: "BOSCH", image: "StiralnayaMashina.png"));
            Devices.Add(new HomeDevice(name:"Посудомоечная машина", description: "Gorenje", image: "PosudomoechnayaMashina.png"));
            Devices.Add(new HomeDevice(name:"Мультиварка", description: "Philips", image: "Multivarka.png"));
 
            BindingContext = this;  // установка контекста привязки
        }

        /// <summary>
        /// Обработчик нажатия (происходит всякий раз, когда на элемент производится нажатие (однократное, кратковременное, двойное...)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void deviceList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // распаковка модели из объекта
            var tappedDevice = (HomeDevice)e.Item;
            // уведомление
            DisplayAlert("Нажатие", $"Вы нажали на элемент {tappedDevice.Name}", "OK"); ; ;
        }

        /// <summary>
        /// Обработчик выбора (происходит когда элемент выбирается. происходит одновременно с событием нажатия.
        /// при повторном нажатии на выбранном элементе этот обработчиек не срабатывает
        /// зато срабатывает при снятии выделения с элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void deviceList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // распаковка модели из объекта
            var selectedDevice = (HomeDevice)e.SelectedItem;
            // уведомление
            DisplayAlert("Выбор", $"Вы выбрали {selectedDevice.Name}", "OK"); ; ;
        }

        /// <summary>
        /// Обработчик добавления нового устройства
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AddDevice(object sender, EventArgs e)
        {
            // Запрос и валидация имени устройства
            var newDeviceName = await DisplayPromptAsync("Новое устройство", "Введите имя устройства", "Продолжить", "Отмена");
            if(Devices.Any(d => d.Name.CompareTo(newDeviceName.Trim()) == 0))
            {
                await DisplayAlert("Ошибка", $"Устройство '{newDeviceName}' уже существует", "ОК");
                return;
            }
 
            // Запрос описания устройства
            var newDeviceDescription = await DisplayPromptAsync(newDeviceName, "Добавьте краткое описание устройства", "Сохранить", "Отмена");
  
            // Добавление устройства и уведомление пользователя
            Devices.Add(new HomeDevice(name: newDeviceName, image: null, description: newDeviceDescription));
            await DisplayAlert(null, $"Устройство '{newDeviceName}' успешно добавлено", "ОК");
        }

        /// <summary>
        /// Обработчик удаления устройства
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private async void RemoveDevice(object sender, EventArgs e)
        {
            // Получаем и "распаковываем" выбранный элемент
            var deviceToRemove = deviceList.SelectedItem as HomeDevice;
            if (deviceToRemove != null)
            {
                // Удаляем
                Devices.Remove(deviceToRemove);
                // Уведомляем пользователя
                await DisplayAlert(null, $"Устройство '{deviceToRemove.Name}' удалено", "ОК");
            }
        }
    }
}