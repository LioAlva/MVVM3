﻿using GalaSoft.MvvmLight.Command;
using MVVM3.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM3.ViewModels
{
     public class MenuItemViewModel
    {

        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }

        public ICommand NavigateCommand { get { return new RelayCommand(Navegate); } }

       /* private void Navegate()
        {
            //una regla es que el  enu item viev model no conosca al master , tampoco alas paginas 
            App.Master.IsPresented = false;
            switch (PageName)
            {
                case "AlarmsPage":
                    App.Navigator.PushAsync(new AlarmsPage());
                     break;
                case "ClientsPage":
                    App.Navigator.PushAsync(new ClientsPage());
                     break;
                case "SettingsPage":
                    App.Navigator.PushAsync(new SettingsPage());
                     break;
                case "MainPage":
                    App.Navigator.PopToRootAsync()//en main page no vamos al mai page nos vamos ala raiz que es la pagina de pedidos
                    ; break;
                default:break;
            }
        }*/
    }
}
