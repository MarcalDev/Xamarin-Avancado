using Xamarin.Forms;

namespace App018.Views
{
    public partial class Inicial : ContentPage
    {
        public Inicial(params string[] paramentros)
        {
            InitializeComponent();

            foreach(var para in paramentros)
            {
                LblInformacao.Text += para + "\n";
            }
        }
    }
}
