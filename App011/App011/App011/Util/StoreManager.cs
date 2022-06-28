using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PCLStorage;

namespace App011.Util
{
    public class StoreManager
    {

        public async static void SalvarArquivo(string fileName, string conteudo)
        {
            try
            {
                // inicia váriavel (rootFolder) com o repositório local atual
                IFolder rootFolder = FileSystem.Current.LocalStorage;

                // Cria a pastar arquivos dentro do repositório (rootFolder)
                IFolder folder = await rootFolder.CreateFolderAsync("arquivos", CreationCollisionOption.OpenIfExists);

                //Cria arquivo dentro da pasta "arquivos"
                IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

                //Escreve dentro do arquivo o conteúdo("texto") passado
                await file.WriteAllTextAsync(conteudo);
            }
            catch (Exception ex)
            {

                await App.Current.MainPage.DisplayAlert("Alerta", ex.Message, "OK");
            }
        }




        public async static Task<string> LerArquivo(string fileName)
        {
            try
            {
                // inicia váriavel (rootFolder) com o repositório local atual
                IFolder rootFolder = FileSystem.Current.LocalStorage;

                // Cria a pastar arquivos dentro do repositório (rootFolder)
                IFolder folder = await rootFolder.CreateFolderAsync("arquivos", CreationCollisionOption.OpenIfExists);

                // Puxa arquivo correspondente através do Get
                IFile file = await folder.GetFileAsync(fileName);

                //Retorna o conteúdo("texto") dentro do arquivo
                return await file.ReadAllTextAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alerta", ex.Message, "OK");
                return null;
            }
        }
    }
}
