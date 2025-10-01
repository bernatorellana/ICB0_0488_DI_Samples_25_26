using System.Collections.Generic;
using System.Windows.Documents;

namespace _20251001_Controls_Senders.model
{
    internal class Provincia
    {
        private int id;
        private string nom;

        public Provincia(int id, string nom)
        {
            this.Id = id;
            this.Nom = nom;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
    
    
        //----------------------------------------
        private static List<Provincia> _provincies;
        public static List<Provincia> GetProvincies()
        {
            if(_provincies == null)
            {
                _provincies = new List<Provincia>
                {
                    new Provincia(1, "Barcelona"),
                    new Provincia(2, "Girona"),
                    new Provincia(3, "Tarragona"),
                    new Provincia(4, "Lleida")
                };
            }
            return _provincies;
        }
    
    }
}