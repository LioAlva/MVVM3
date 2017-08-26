using MVVM3.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM3.Services
{
    public class NavigationService
    {
        public async void Navegate(string PageName)
        {//await se pone a naegar sin terner que esperar que cargen los otros
            //una regla es que el  enu item viev model no conosca al master , tampoco alas paginas 
            App.Master.IsPresented = false;
            switch (PageName)
            {//SIN EMBARGO RL MAIN VIEW MODEL CONOCE LA CLASE APP ESO NO DEBE SER
                case "AlarmsPage":
                    await App.Navigator.PushAsync(new AlarmsPage());
                    break;
                case "ClientsPage":
                    await App.Navigator.PushAsync(new ClientsPage());
                    break;
                case "NewOrderPage":
                     await App.Navigator.PushAsync(new NewOrderPage());
                    break;
                case "SettingsPage":
                    await App.Navigator.PushAsync(new SettingsPage());
                    break;
                case "MainPage":
                    await App.Navigator.PopToRootAsync()//en main page no vamos al mai page nos vamos ala raiz que es la pagina de pedidos
                    ; break;
                default: break;
            }
        }

        internal void SetMainPage()
        {
            App.Current.MainPage = new MasterPage();
        }
    }
}
