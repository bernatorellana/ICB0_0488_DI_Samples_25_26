using System;
using System.Collections.Generic;
using System.Text;

namespace WpfTestingTeatre.Model
{
    public class TarifesTeatre
    {

        public static decimal getPreu(int tipus_seient, int edat)
        {

            if (tipus_seient <= 0 || tipus_seient > 4) throw new Exception("Tipus de seient erroni");
            if (edat <= 0 || edat >= 120) throw new Exception("Edat erronia");


            /*
                 1 (platea) : 60€
                 2 (laterals) : 50€
                 3 (primer pis): 40€
                 4 (segon pis): 30€ 
             * */
            decimal[] preus = { 0, 60, 50, 40, 30 };
            if (edat < 4) return 0;
            if (edat < 12) return preus[tipus_seient] * 0.75m;
            if (edat < 60) return preus[tipus_seient];
            else
            {
                if (tipus_seient==1) return preus[tipus_seient]*0.5m;
                else { 
                    return preus[tipus_seient]*0.2m;
                }
            }

            decimal result = 0;
            return result;
        }

    }
}
