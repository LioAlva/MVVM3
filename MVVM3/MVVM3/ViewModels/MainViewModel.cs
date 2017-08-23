using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM3.ViewModels
{
    public class MainViewModel
    {
        //sera para que pueda observar cada cosa del menuItenViewModel
        public ObservableCollection<MenuItemViewModel> Menu{ get; set; }

        public MainViewModel()
        {
            Menu =new ObservableCollection<MenuItemViewModel>();
            LoadMenu();
        }

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
