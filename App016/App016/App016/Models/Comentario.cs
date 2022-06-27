using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace App016.Models
{
    public class Comentario : RealmObject
    {
        public Profissional profissional {get; set; }
        public string Autor { get; set; }
        public DateTimeOffset Data { get; set; }
        public string Descricao { get; set; }


    }
}
