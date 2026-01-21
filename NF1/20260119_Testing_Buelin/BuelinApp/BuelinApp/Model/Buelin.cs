using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BuelinApp.Model
{
    public class Buelin
    {
        public decimal getSobrecostPerEquipatge(
            int?[] midaEquipatgeMaCm,
            int? pesEquipatgeMa,
            int[] pesMaletes,
            bool pagaAmbTarja)
        {
            if (midaEquipatgeMaCm == null && pesEquipatgeMa != null)
            {
                error("Equipatge de mà: mida nula i pes no nul!!");
            }
            if (midaEquipatgeMaCm != null)
            {
                if (midaEquipatgeMaCm.Length != 3)
                    error("Equipatge de mà: mida ha de tenir 3 components (x,y,z)");
                else
                    foreach (int p in midaEquipatgeMaCm)
                    {
                        if (p <= 0) error("Equipatge de mà: dimensions errònies");
                    }
            }
            if (pesEquipatgeMa<=0) error("Equipatge de mà: pes erroni");
            
            
            if (pesMaletes != null)
            {
                foreach (int p in pesMaletes)
                {
                    if (p <= 0) error("Malete: dimensions errònies");
                }
            }
            //===================================
            decimal sobrecostEquipatgeDeMa = 0m;
            if (midaEquipatgeMaCm != null)
            {
                if( midaEquipatgeMaCm.Count(m=>m.Value>30) >0){
                    sobrecostEquipatgeDeMa = 60m;
                } else if (pesEquipatgeMa.HasValue && pesEquipatgeMa.Value > 20)
                {
                    sobrecostEquipatgeDeMa = (pesEquipatgeMa.Value - 20m)*20m;
                }
            }


            //===================================
            decimal sobrecostMaletes = 0m;
            if(pesMaletes!= null)
            for (int i = 0; i < pesMaletes.Length; i++)
            {
                if (i < 2)
                {
                    sobrecostMaletes += (pesMaletes[i] - 20) * 20;
                }
                else
                {
                    sobrecostMaletes += pesMaletes[i] * 10;
                }
          }
            
           

            //===================================
            decimal sobrecostTarjaDeCredit = 0m;
            if (sobrecostEquipatgeDeMa + sobrecostMaletes > 0)
            {
                sobrecostTarjaDeCredit += pagaAmbTarja ? 2 : 0;
            }

            return sobrecostEquipatgeDeMa+sobrecostMaletes + sobrecostTarjaDeCredit;
        }

        private static void error(string msg)
        {
            throw new ArgumentException(msg);
        }
    }
}