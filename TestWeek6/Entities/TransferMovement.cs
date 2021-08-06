using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek6.Entities
{
    class TransferMovement : Movimento
    {
        public string BancaOrigine { get; set; }
        public string BancaDestinazione { get; set; }

        public override string ToString()
        {
            return $"Banca Origine: {BancaOrigine} \nBanca Destinazione: {BancaDestinazione}";
        }
    }


    

}
