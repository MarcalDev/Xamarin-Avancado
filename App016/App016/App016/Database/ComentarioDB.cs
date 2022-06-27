using System;
using System.Collections.Generic;
using System.Text;
using App016.Models;
using Realms;

namespace App016.Database
{
    public class ComentarioDB
    {
        public static List<Comentario> GetListComent()
        {
            return new List<Comentario>(Realm.GetInstance().All<Comentario>()); 
        }

    }
}
