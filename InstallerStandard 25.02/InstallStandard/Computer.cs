using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallStandard {
    public class Computer {

        private string Name;
        private DateTime LastMod;

        public string GravarNomeComputador { get => Name; set => Name = value; }
        public DateTime UltimaInstalacao { get => LastMod; set => LastMod = value; }
    }
}
