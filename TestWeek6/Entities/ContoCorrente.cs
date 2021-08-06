using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek6.Entities
{
    public class ContoCorrente
    {
        public int NumeroConto { get; set; }
        public string NomeBanca { get; set; }
        public decimal Saldo { get; set; }
        public DateTime DataUltimaOperazione { get ; set; }
        public IList<Movimento> Movimenti { get; set; } = new List<Movimento>();

        public ContoCorrente()
        {
            DataUltimaOperazione = DateTime.Now.Date;
        }

    }
}
