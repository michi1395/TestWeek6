using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek6.Entities
{
    public abstract class Movimento
    {
        public decimal Importo { get; set; }
        public DateTime DataMovimento { get; set; }
        public bool IsPrelievo { get; set; }
    }
}
