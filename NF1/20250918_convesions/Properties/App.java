package edu.epsevg.PROP.LAB1;

import edu.epsevg.PROP.LAB1.model.Alumne;
import edu.epsevg.PROP.LAB1.model.Persona;
import java.util.Date;



/**
 *
 * @author Usuari
 */
public class App {

    public static void main(String[] args) {
        System.out.println("Hello World!");
        
        int j=0;
        char c = 'A';
        boolean vindras = true;
        //           01234567
        String nom ="   Paquitoxxx González   ";
        nom += " Pérez    ";
        System.out.println(">"+nom);
        System.out.println(">"+nom.toUpperCase());
        nom = nom.toUpperCase();
        System.out.println(">"+nom);
        
        String nomTrimejat = nom.trim();
        String primerNom = nomTrimejat.substring(0, nomTrimejat.indexOf(" "));
        System.out.println(">"+primerNom);
        
        //*********************************************
         // Prova de rendiment de contatenació d'Strings
        //*********************************************
        StringBuffer numero = new StringBuffer();
        //int numero = 0;
        long timeBegin = (new Date()).getTime();
        for(int i=0;i<1000000;i++){
            numero.append(""+i);
        }
        long timeEnd = (new Date()).getTime();
        System.out.println("temps (ms):"+(timeEnd-timeBegin));
        
        
        //********************************
        
        //Persona p = new Persona(12, "Maria", "Sanchez");
        
        System.out.println("Persona:"+p);
        Alumne a = new Alumne( 12, "Juan", "Martí",123);
        
    }
}
