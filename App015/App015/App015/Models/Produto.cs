using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Realms;

namespace App015.Models
{
    public class Produto : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Item { get; set; }
        
        [System.ComponentModel.DataAnnotations.Required]
        [Range(1,999)]
        public int? Quantidade { get; set; }
    }
}
