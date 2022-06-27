using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App012.Modelo;
using System.ComponentModel.DataAnnotations;

namespace App012
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BtnSalvar.Clicked += delegate
            {
            
                Pessoa pessoa = new Pessoa();
                pessoa.Nome = TxtNome.Text;
                pessoa.Email = TxtEmail.Text;
                pessoa.CPF = TxtCPF.Text;

                var ListaHas = new List<ValidationResult>();
                var Contexto = new ValidationContext(pessoa);
                var IsValid = Validator.TryValidateObject(pessoa, Contexto, ListaHas, true);

                
                if(ListaHas.Count > 0)
                {
                    LblMsg.Text = string.Empty;
                    LblMsg.TextColor = Color.Red;

                    foreach(var x in ListaHas)
                    {
                        LblMsg.Text += string.Format(x.ErrorMessage, x.MemberNames) + "\n";
                    }
                }
                else
                {
                    LblMsg.Text = "OK";
                    LblMsg.TextColor = Color.Green;
                }                
            };
        }
    }
}
