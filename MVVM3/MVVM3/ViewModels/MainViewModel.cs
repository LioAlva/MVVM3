﻿using System;
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
        public ObservableCollection<OrderViewModel> Orders{ get; set; }

        public MainViewModel()
        {
            Menu =new ObservableCollection<MenuItemViewModel>();
            Orders = new ObservableCollection<OrderViewModel>();
            LoadMenu();
            LoadFakeData();
        }

        private void LoadFakeData()
        {
            for (int i = 0; i < 10; i++)
            {
                Orders.Add(new OrderViewModel{
                    Title="",
                    DeliveryDate=DateTime.Today,
                    Description="Loren ipsum dolor sir t amet, consecctur adipp" +
                    "elit asod , ser der con da li aliv sabar"
                });
            }
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
