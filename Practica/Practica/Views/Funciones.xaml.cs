using Practica.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FuncionesPage : ContentPage
    {

        public FuncionesPage(Cartelera cartelera)
        {

            InitializeComponent();
            datos.BindingContext = cartelera;
            funciones.ItemsSource = cartelera.Funciones;
        }

        private async void cartelera_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Funcion)e.SelectedItem;
            Cartelera carte = (Cartelera)datos.BindingContext;

            if(cantidadBoletas.Text != null && cantidadBoletas.Text != " ")
            {
                int cantidad = int.Parse(cantidadBoletas.Text);

                if(cantidad > 0)
                {
                    await Navigation.PushAsync(new ResumenPage(item, cantidad, carte));
                }
                else
                {
                    await DisplayAlert("Alerta", "La cantidad minima es 1", "Ok");
                }

            }
            else
            {
                await DisplayAlert("Ciudado", "Ingresa cantidad de boletas", "Ok");
            }

            
        }
    }
    
}