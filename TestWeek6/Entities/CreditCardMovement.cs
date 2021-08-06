using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek6.Entities
{
    class CreditCardMovement : Movimento
    {
        public Tipo Tipologia { get; set; }
        public long NumeroCarta { get; set; }

        public enum Tipo
        {
            AMEX,
            VISA,
            MASTERCARD,
            OTHER
        }

        public override string ToString()
        {
            return $"Tipo Carta: {Tipologia} \nNumero Carta: {NumeroCarta}";
        }
    }
}
