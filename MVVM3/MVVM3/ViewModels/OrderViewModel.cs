
using GalaSoft.MvvmLight.Command;
using MVVM3.Models;
using MVVM3.Services;
using System;
using System.Windows.Input;

namespace MVVM3.ViewModels
{
    public class OrderViewModel
    {
        #region Attributes
        private ApiService apiService;
        private DialogService dialogService;
        #endregion
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryInformation { get; set; }
        public string Client { get; set; }
        public string Phone { get; set; }
        public bool IsDelivered { get; set; }
        #endregion

        #region Constructor
        public OrderViewModel()
        {
            apiService = new ApiService();
            dialogService = new DialogService();
            DeliveryDate = DateTime.Today;
        }
        #endregion


        #region Commmands
        //SaveCommand
        public ICommand SaveCommand{ get { return new RelayCommand(Save); } }
        
        //public ICommand NavigateCommand { get { return new RelayCommand(Navegate); } }
        #endregion

        #region Method
        private async void Save()
        {
            try
            {
                if (string.IsNullOrEmpty(Title))
                {
                    await dialogService.ShowMessage("Error", "Debes ingresar un titulo");
                }
                var order = new Order
                {
                    Client = this.Client,
                    CreationDate = DateTime.Now,
                    DeliveryDate = this.DeliveryDate,
                    DeliveryInformation = this.DeliveryInformation,
                    Description = this.Description,
                    IsDelivered = false,
                    Phone = this.Phone,
                    Title = this.Title,
                };
                await apiService.CreateOrder(order);
                await dialogService.ShowMessage("Información", "El servicio a sido creado");
            }
            catch (Exception)
            {
                await dialogService.ShowMessage("Error", "Ha ocurrido un error inesperado");
            }
           
        }
        #endregion

   
    }
}
    