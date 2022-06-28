
using System;
using System.Collections.Generic;
using System.Linq;
using App016.Models;
using Prism.Mvvm;
using Prism.Navigation;

namespace App016.ViewModels
{

    public class DetalheProfissionalViewModel : BindableBase, IInitialize
    {
        private Profissional _profissional;
        public Profissional Profissional
        {
            get { return _profissional; }
            set { SetProperty(ref _profissional, value); }
        }

        private List<Comentario> _comentarios;
        public List<Comentario> Comentarios
        {
            get { return _comentarios; }
            set { SetProperty(ref _comentarios, value); }
        }



        public DetalheProfissionalViewModel()
        {

        }

        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("profissional"))
            {
                Profissional = parameters.GetValue<Profissional>("profissional");

                Comentarios = App016.Database.ComentarioDB.GetListComent(Profissional);
            }
        }
    }
}
