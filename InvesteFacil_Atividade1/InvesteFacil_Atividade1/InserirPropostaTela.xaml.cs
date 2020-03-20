using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InvesteFacil_Atividade1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InserirPropostaTela : ContentPage
    {
        List<string> listTipoInvestimento;
        int indicePicker = -1;
        int sliderQtdMeses = 6;
        public InserirPropostaTela()
        {
            InitializeComponent();

            listTipoInvestimento = new List<string>()
            {
                "POUPANÇA",
                "TESOURO DIRETO SELIC",
                "TESOURO DIRETO IPCA"
            };
            pickerTipoInvestimento.ItemsSource = listTipoInvestimento;
        }

        private void OnSliderMesesValueChanged(object sender, ValueChangedEventArgs args)
        {
            sliderQtdMeses = (int)args.NewValue;
            sliderValue.Text = String.Format("{0} meses", sliderQtdMeses);
        }

        private void pickerMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            indicePicker = picker.SelectedIndex;
        }


        private double calculaRendimento(double valor, double juros)
        {
            double montante = valor;

            for (int i = 0; i < sliderQtdMeses; i++)
            {
                double rendimentoMes = montante * juros;
                montante += rendimentoMes;
            }
            return montante;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (indicePicker == -1)
            {
                //Exibir mensagem de erro
                DisplayAlert("Alerta", "Escolha o tipo de investimento!", "OK");
            }
            if (string.IsNullOrEmpty(entryValor.Text))
            {
                //Mensagem de erro
                DisplayAlert("Alerta", "Digite o valor a ser investido!", "OK");
            }
            else
            {
                double valorMontante = double.Parse(entryValor.Text);

                switch (indicePicker)
                {
                    //POUPANÇA
                    case 0:
                        labelMontante.Text = calculaRendimento(valorMontante, 0.0028).ToString("C");
                        break;
                    case 1:
                        labelMontante.Text = calculaRendimento(valorMontante, 0.0038).ToString("C");
                        break;
                    case 2:
                        double juros = (5f / 12f) / 100;
                        labelMontante.Text = calculaRendimento(valorMontante, juros).ToString("C");
                        break;
                }
            }

        }
    }
}