using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Media;

namespace App013
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BtnFoto.Clicked += TirarFoto;
        }

        private async void TirarFoto(object origem, EventArgs args)
        {
            // Inicializa o plugin
            await CrossMedia.Current.Initialize();

            // Caso o plugin esteja disponível
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Sem camera", ":( camera não autorizada.", "OK");
                return;
            }

            // atribui a file uma instancia, passando o diretório e nome da imagem, através de um método
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });


            if (file == null)
                return;

            await DisplayAlert("Local do arquivo: ", file.Path, "OK");

            // Define a imagem do componente (Stream - classe para passagem de arquivos)
            Imagem.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }
    }
}
