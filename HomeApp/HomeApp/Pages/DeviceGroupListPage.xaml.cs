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
    }
}