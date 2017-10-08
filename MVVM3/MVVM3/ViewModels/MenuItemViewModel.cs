using GalaSoft.MvvmLight.Command;
using MVVM3.Services;
using System.Windows.Input;

namespace MVVM3.ViewModels
{
    public class MenuItemViewModel
    {
        //lqa idea, la pagina no conoce los modelos ylos modelos no deben de conocer la paginas
        private NavigationService navigationService;

        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }

        public ICommand NavigateCommand { get { return new RelayCommand(Navegate); } }

        public MenuItemViewModel()
        {
            navigationService =new  NavigationService();
        }

        private void Navegate()
        {
            navigationService.Navegate(PageName);
        }


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
