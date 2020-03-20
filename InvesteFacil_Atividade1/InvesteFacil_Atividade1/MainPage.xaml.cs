using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InvesteFacil_Atividade1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        string usuario = "ana";
        string senha = "123456";

        
        public MainPage()
        {
            InitializeComponent();

            
            
        }

        public async void OnLoginButtonClicked(Object sender, EventArgs e)
        {
            string txtUser, txtPassword;
            txtUser = entryUser.Text;
            txtPassword = entryPassword.Text;

            if (txtUser == usuario && txtPassword == senha)
            {
                await Navigation.PushAsync(new InserirPropostaTela());
            }
            else
            {
                await DisplayAlert("Alerta!", "Usuário ou Senha não correspondem.", "Ok");
            }
        }
    }
}
