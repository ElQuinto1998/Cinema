using Practica.Domain;
using Practica.Services;
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
    public partial class CarteleraPage : ContentPage
    {
        public CarteleraPage()
        {
            InitializeComponent();

            lsvCartelera.ItemsSource = CinemaService.GetCinemas();
        }

        private async void lsvCartelera_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Cartelera)e.SelectedItem;

            await Navigation.PushAsync(new FuncionesPage(item));
        }
    }
}