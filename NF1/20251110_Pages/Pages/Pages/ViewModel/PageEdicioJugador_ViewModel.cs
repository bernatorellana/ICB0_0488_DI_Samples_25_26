using GestioDequips.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.ViewModel
{
    class PageEdicioJugador_ViewModel
    {
        private Jugador jugador;


        public PageEdicioJugador_ViewModel(Jugador j)
        {
            if (j != null)
            {
                this.Dorsal = ""+j.Dorsal;
                this.Nom = j.Nom;
                this.Cognoms = j.Cognoms;
                this.UrlFoto = j.UrlFoto;

                this.jugador = j;
            } else
            {
                this.Dorsal = "";
                this.Nom = "";
                this.Cognoms = "";
                this.UrlFoto = "pack://application:,,,/Assets/unknown.png";
            }

        }

        public String Dorsal { get; set; }
        public String Nom { get; set; }
        public String Cognoms { get; set; }
        public String UrlFoto { get; set; }

        internal void save() 
        {
            if (validacioCorrecta())
            {
                if (jugador != null)
                {
                    jugador.Cognoms = this.Cognoms;
                    jugador.Dorsal = Int32.Parse(this.Dorsal);

                    // Aquí caldria fer un update de la base de dades
                    // OracleFactory.getUOW().JugadorDAO.update(jugador);
                }
                else
                {
                    jugador = new Jugador(0, "Pepe", Cognoms, "Uganda", UrlFoto, Int32.Parse(Dorsal));

                    Equip.getLlistaEquips()[0].Add(jugador);

                    // Aquí caldria fer un insert de la base de dades
                    // OracleFactory.getUOW().JugadorDAO.insert(jugador);
                }
            }
        }

        private bool validacioCorrecta()
        {

            return true;
            //return Persona.validaNom(this.Nom);// &&
               // Persona.validaCognom(this.Cognoms);
               // ...
                
        }
    }
}
