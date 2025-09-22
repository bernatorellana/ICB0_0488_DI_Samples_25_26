using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _20250922_Classes
{
    public class Persona
    {
        // PROPIETATS
        public int Id { get => id; set => id = value; }
        public string NIF1 { get => NIF; 
            set { 
                if(ValidarNIF(value))
                    NIF = value;
                else
                {
                    throw new Exception("NIF invàlid");
                }
            } 
        }
        public string Nom1 { get => Nom; set => Nom = value; }
        public string Cognom1 { get => Cognom; set => Cognom = value; }

        //CAMPS
        private int id;
        private String NIF;
        private String Nom;
        private String Cognom;

        public Persona(int id, string nIF, string nom, string cognom)
        {
            this.Id = id;
            NIF1 = nIF;
            Nom1 = nom;
            Cognom1 = cognom;
        }





        private static bool ValidarNIF(string nif)
        {
            if (string.IsNullOrWhiteSpace(nif))
                return false;

            // Format: 8 dígits + 1 lletra
            if (!Regex.IsMatch(nif, @"^\d{8}[A-Z]$"))
                return false;

            string lletres = "TRWAGMYFPDXBNJZSQVHLCKE";
            int numero = int.Parse(nif.Substring(0, 8));
            char lletraEsperada = lletres[numero % 23];

            return nif[nif.Length-1] == lletraEsperada;
        }
    }
}
