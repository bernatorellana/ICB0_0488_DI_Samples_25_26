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

            decimal result = 0;
            return result;
        }

    }
}
