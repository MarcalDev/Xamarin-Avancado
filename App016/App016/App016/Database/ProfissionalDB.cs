using System;
using System.Collections.Generic;
using System.Text;
using App016.Models;
using Realms;

namespace App016.Database
{
    public class ProfissionalDB
    {
        public static List<Profissional> GetListProf()
        {
            return new List<Profissional>(Realm.GetInstance().All<Profissional>());
        }
    }
}

