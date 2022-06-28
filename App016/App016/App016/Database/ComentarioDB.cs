using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App016.Models;
using Realms;

namespace App016.Database
{
    public class ComentarioDB
    {
        public static List<Comentario> GetListComent(Profissional prof)
        {
            return new List<Comentario>(Realm.GetInstance().All<Comentario>().Where(a=>a.profissional == prof));
        }

    }
}
