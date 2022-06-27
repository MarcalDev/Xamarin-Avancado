using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using App012.Validacao;

namespace App012.Modelo
{
    public class Pessoa
    {
        [Required(AllowEmptyStrings = false, ErrorMessage ="O campo nome é obrigatório!")]
        [StringLength(60, MinimumLength = 5)]
        public string Nome { get; set; }
        
        [Required(ErrorMessageResourceName = "MSG_E01", ErrorMessageResourceType = typeof(Lang.Message))]
        [EmailAddress(ErrorMessage = null, ErrorMessageResourceName = "MSG_E02", ErrorMessageResourceType = typeof(Lang.Message))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "MSG_E01", ErrorMessageResourceType = typeof(Lang.Message))]
        [CPF(ErrorMessageResourceName ="MSG_E02", ErrorMessageResourceType = typeof(Lang.Message))]
        public string CPF { get; set; }

    }
}
