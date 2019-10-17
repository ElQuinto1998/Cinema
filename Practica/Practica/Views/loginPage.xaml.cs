using Practica.Services;
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
    public partial class loginPage : ContentPage
    {
     
        public loginPage()
        {
            InitializeComponent();
        }

        private async void login(object sender, EventArgs e)
        {
            if(Username.Text != " " && Password.Text != " " && Username.Text != null && Password.Text != null)
            {
                Usuarios usuario = new Usuarios();
                usuario.Usuario = Username.Text;
                usuario.Password = Password.Text;

                Permiso permiso = CinemaService.Login(usuario);

                if(permiso.EsPermitido == true)
                {
                    await Navigation.PushAsync(new CarteleraPage());
                }
                else
                {
                    await DisplayAlert("Ops!", "No estas autorizado", "OK");
                }

            }
            else
            {
                await DisplayAlert("Ops!", "Campos requeridos", "OK");
            }
        }
    }
}