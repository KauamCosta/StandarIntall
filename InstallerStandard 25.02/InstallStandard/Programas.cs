using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallStandard {

    public class Programas {

        private int Id;
        private string Name;
        private bool Installed;


        public int Identificador { get => Id; set => Id = value; }
        public string NomeDoPrograma { get => Name; set => Name = value; }
        public bool Instalado { get => Installed; set => Installed = value; }
    }
}
