using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallStandard {
    public class User {

        private string Name;
        private DateTime firstDate;

        public string NomeUsuario { get => Name; set => Name = value; }
        public DateTime PrimeiroLogin { get => firstDate; set => firstDate = value; }

    }
}
