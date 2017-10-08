using GalaSoft.MvvmLight.Command;
using MVVM3.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVM3.ViewModels
{
    public class MainViewModel
    {
        #region Attributes
        private NavigationService navigationService;
        private ApiService apiService;
        #endregion

        #region Properties
        //sera para que pueda observar cada cosa del menuItenViewModel
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public ObservableCollection<OrderViewModel> Orders { get; set; }
        public OrderViewModel NewOder { get;private  set; }
        #endregion

        #region Commands
        public ICommand StartCommand { get {return new RelayCommand(Start) ; } }

        private async void Start()
        {
            var orders = await apiService.GetAllOrders();
            Orders.Clear();

            foreach (var order in orders)
            {
                Orders.Add(new OrderViewModel{
                    Client=order.Client,
                    CreationDate=order.CreationDate,
                    DeliveryDate=order.DeliveryDate,
                    DeliveryInformation=order.DeliveryInformation,
                    Description=order.Description,
                    Id=order.Id,
                    IsDelivered=order.IsDelivered,
                    Phone=order.Phone,
                    Title=order.Title
                });
            }


            navigationService.SetMainPage();
        }

        public ICommand GoToCommand { get { return new RelayCommand<string>(GoTo); } }//nomre interno de como quiero llamar al comando
        //GoToCommand , es el nombre del comando que esta en la pagina
        private void GoTo(string pageName)//aqui vemos para que pagina tenemos que navegar
        {
            switch (pageName) {
                case "NewOrderPage":
                    NewOder= new OrderViewModel();
                    ; break;
                default:break;
            }
            navigationService.Navegate(pageName);
        }
        #endregion
        #region Constructor
        public MainViewModel()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();
            Orders = new ObservableCollection<OrderViewModel>();
            navigationService = new NavigationService();
            apiService = new ApiService();
            LoadMenu();
      //      LoadFakeData();
        }
        #endregion


        /*private void LoadFakeData()
        {
            for (int i = 0; i < 10; i++)
            {
                Orders.Add(new OrderViewModel{
                    Title=string.Format("Prueba {0}",i),
                    DeliveryDate=DateTime.Today,
                    Description="Loren ipsum dolor sir t amet, consecctur adipp" +
                    "elit asod , ser der con da li aliv sabar"
                });
            }
        }*/

        private void LoadMenu()
        {
            Menu.Add(new MenuItemViewModel {
                Icon="ic_action_orders.png",
                PageName="MainPage",
                Title="Pedidos"
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_customers.png",
                PageName = "ClientsPage",
                Title = "Clientes"
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_alarms.png",
                PageName = "AlarmsPage",
                Title = "Alarmas"
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_settings.png",
                PageName = "SettingsPage",
                Title = "Ajustes"
            });
        }
    }
}
