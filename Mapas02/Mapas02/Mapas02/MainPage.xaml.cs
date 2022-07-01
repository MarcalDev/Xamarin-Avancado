using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Mapas02
{
    public partial class MainPage : ContentPage
    {
        Map mapa;
        public MainPage()
        {
            InitializeComponent();

            CriarMapa();
            PermissaoGPSAsync();
        }

        public async Task PermissaoGPSAsync()
        {
            try
            {
                // Cria váriavel para armazenar o estado das permissões
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                
                // Caso as permissões estejam desativadas
                if (status != PermissionStatus.Granted)
                {
                    // Verifica se deve fazer a requisição da ativação de permissões
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await DisplayAlert("Usar localização", "Por favor, autorize a utilização da localização", "OK");
                    }

                    // Atribui a váriavel o pedido de ativação das permissões
                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Location))
                        status = results[Permission.Location];
                }

                // Caso as Permissões estejam ativadas
                if (status == PermissionStatus.Granted)
                {
                    // Instancia o objeto gps
                    GPS gps = new GPS();

                    // Caso a localização esteja disponível
                    if (gps.IsLocationAvailable())

                    {
                        // Intancia a Position e requisita um retorno de localização
                        Plugin.Geolocator.Abstractions.Position pos = gps.GetCurrentLocation().GetAwaiter().GetResult();

                        // Caso o retorno não esteja vazio
                        if (pos != null)
                        {
                            // Instancia novo ponteiro, utilizando a localização trazida no retorno (pos)
                            var MyPos = new Pin()
                            {
                                Position = new Position(pos.Latitude, pos.Longitude),
                                Label = "Minha Posição"
                            };

                            // Adiciona esse ponteiro no mapa
                            mapa.Pins.Add(MyPos);
                        }
                    }

                    // Define o mapa como visível
                    mapa.IsShowingUser = true;
                }

                // Caso o estado de permissão seja desconhecido
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Localização negada", "Não foi possível continuar, tente novamente.", "OK");
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void CriarMapa()
        {
            // Atribui a mapa um Map e adiciona uma posição, definindo a distancia em quilometros
            mapa = new Map(MapSpan.FromCenterAndRadius(new Position(-15.8260571, -48.060058), Distance.FromKilometers(1)));

            // Define o tipo de mapa
            mapa.MapType = MapType.Street;

            // Instancia novos ponteiros, passando os parâmetros de posição, rótulo (nome) e endereço
            var cartorio = new Pin()
            {
                Position = new Position(-15.825906, -48.0570538),
                Label = "Cartório do 5º Ofício de Registro Civil, Títulos e Documentos e Pessoas Jurídicas do DF",
                Address = "CNA 03, Lote 02, Praça do DI, Taguatinga Norte CNA 3 - Taguatinga, Brasília - DF, 72110-035"
            };

            var pracaDI = new Pin()
            {
                Position = new Position(-15.8265988, -48.0581059),
                Label = "Praça do DI",
                Address = "St. A Norte QNA CNA - Taguatinga, Brasília - DF, 72110-015"
            };

            //Adiciona os ponteiros ao mapa
            mapa.Pins.Add(cartorio);
            mapa.Pins.Add(pracaDI);

            // Define mapa como conteúdo do stackLayout
            MapContainer.Children.Add(mapa);
        }
    }
}
