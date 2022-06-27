using App016.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App016.Database
{
    public class Massa
    {
        public static void CriarMassaDados()
        {
            var realm = Realm.GetInstance();

            var count = realm.All<Profissional>().Count();

            if(count == 0)
            {
                realm.Write(() =>
                {
                    for (int i = 0; i < 20; i++)
                    {
                        Profissional prof = new Profissional() { Nome = "Prof " + i, Descricao = "Descri " + i, Especialidade = "Especialidade " + i, Img = "https://conteudo.imguol.com.br/blogs/174/files/2018/05/iStock-648229868-1024x909.jpg" };

                        realm.Add<Profissional>(prof);

                        for (int j = 0; j < 3; j++)
                        {
                            Comentario coment = new Comentario() { profissional = prof, Autor = String.Format("Autor [0] [1]", i, j), Data = DateTimeOffset.Now, Descricao = String.Format("Descricao [0], [1]", i, j) };

                            realm.Add<Comentario>(coment);
                        }
                    }
                });
            }
        }
    }
}
