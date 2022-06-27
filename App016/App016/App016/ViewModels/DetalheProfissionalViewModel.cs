using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using App016.Models;
using Prism.Navigation;

namespace App016.ViewModels
{
    [Obsolete]
    public class DetalheProfissionalViewModel : BindableBase, INavigatingAware
    {
        private Profissional _profissional;
        public Profissional Profissional
        {
            get { return _profissional; }
            set { SetProperty(ref _profissional, value); }
        }
        public DetalheProfissionalViewModel()
        {

        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("profissional"))
            {
                Profissional = parameters.GetValue<Profissional>("profissional");
            }
        }
    }
}
