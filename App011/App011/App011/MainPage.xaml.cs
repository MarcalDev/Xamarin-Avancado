using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PCLStorage;

namespace App011
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BtnEscrever.Clicked += async(sender, args) =>
            {
                Util.StoreManager.SalvarArquivo("File.txt", Conteudo.Text);
            };

            BtnLerArquivo.Clicked += async(sender, args) =>
            {
                string conteudo = await Util.StoreManager.LerArquivo("File.txt");
                LblConteudoArquivo.Text = conteudo;
            };

        }
    }
}
