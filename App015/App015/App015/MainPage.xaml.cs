using App015.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Realms;

namespace App015
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BtnAdicionar.Clicked += delegate
            {
                

                Produto produto = new Produto();
                produto.Item = Item.Text;
                produto.Quantidade = int.Parse(Quantidade.Text);

                //Validação
                List<ValidationResult> listRes = new List<ValidationResult>();
                var contexto = new ValidationContext(produto);
                bool valido = Validator.TryValidateObject(produto, contexto, listRes, true);


                if(valido == false)
                {
                    string mensagem = string.Empty;

                    // Saída de erros
                    foreach(var res in listRes)
                    {
                        mensagem += res.ErrorMessage = "\n";
                    }
                    DisplayAlert("Erros", mensagem, "OK");
                }
                else
                {
                    //Salvar
                    var realm = Realms.Realm.GetInstance();

                    if(Id.Text == null)
                    {
                        #region Produto - Adicionar
                    

                    // puxa o último produto a ser inserido
                    var produtoFinal = realm.All<Produto>().OrderByDescending(a => a.Id).First();
                    int newId = 1;

                    if (produtoFinal != null)
                    {
                        // Define o novo id
                        newId = produtoFinal.Id + 1;
                    }
                    produto.Id = newId;

                    realm.Write(() =>
                    {
                        // Inserção do produto utilizando os parametros do objeto
                        realm.Add(produto);
                    });
                        #endregion

                    }
                    else
                    {
                        #region Produto - Atualizar
                        produto.Id = int.Parse(Id.Text);

                        realm.Write(() =>
                        {
                            realm.Add(produto, true);
                        });
                        #endregion
                    }

                    // Limpa os campos (entry)
                    Id.Text = "";
                    Item.Text = "";
                    Quantidade.Text = "";

                    // Atualiza os itens da lista
                    Lista.ItemsSource = realm.All<Produto>();

                    // Retorna alerta
                    DisplayAlert("Salvo com sucesso", "Itens no banco de dados" + 
                        realm.All<Produto>().Count(), "OK");

                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var realm = Realm.GetInstance();
            Lista.ItemsSource = realm.All<Produto>();
        }

        private void MenuItemExcluir_Clicked(object sender, EventArgs e)
        {
            // pega o objeto do item selecionado
            Produto produto = ((Produto)((MenuItem)sender).CommandParameter);

            var realm = Realm.GetInstance();

            realm.Write(() =>
            {
                // Remove produto
                realm.Remove(produto);
            });

            // Atualiza a lista de produtos
            Lista.ItemsSource = realm.All<Produto>();
        }

        private void MenuItemEditar_Clicked(object sender, EventArgs e)
        {
            // Pega o objeto do item selecionado
            Produto produto = ((Produto)((MenuItem)sender).CommandParameter);

            // Puxa os parametros para auto preenchimento dos campos
            Id.Text = produto.Id.ToString();
            Item.Text = produto.Item;
            Quantidade.Text = produto.Quantidade.ToString();
        }
    }
}
