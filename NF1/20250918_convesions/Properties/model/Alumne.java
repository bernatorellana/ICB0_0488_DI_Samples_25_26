package edu.epsevg.PROP.LAB1.model;

/**
 *
 * @author Usuari
 */
public class Alumne extends Persona{
    
    private int codiAlumne;
    
    public Alumne(int id, String nom, String cognoms, int codiAlumne) {
        super(id, nom, cognoms);
        this.codiAlumne = codiAlumne;
    }
    
}
