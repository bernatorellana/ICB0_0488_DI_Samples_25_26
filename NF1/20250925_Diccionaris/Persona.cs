using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _20250925_Diccionaris
{
    public class Persona
    {
        // PROPIETATS
        public int Id { get => id; set => id = value; }
        public string NIF { get => nif; 
            set { 
                if( ValidarNIF(value) )
                    nif = value;
                else
                {
                    throw new Exception("NIF invàlid");
                }
            } 
        }
        public string Nom { get => nom; set => nom = value; }
        public string Cognom { get => cognom; set => cognom = value; }

        public string NomComplet { get => nom + " " + cognom; }

        //CAMPS
        private int id;
        private String nif;
        private String nom;
        private String cognom;

        public Persona(int _id, string _NIF, string _nom, string _cognom)
        {
            this.Id = _id;
            NIF = _NIF;
            Nom = _nom;
            Cognom = _cognom;
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

        public override bool Equals(object obj)
        {
            return obj is Persona persona &&
                   NIF == persona.NIF;
        }

        public override int GetHashCode()
        {
            return 980250522 + EqualityComparer<string>.Default.GetHashCode(NIF);
        }

        public override string ToString()
        {
            return NomComplet;
        }
    }
}
