/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package edu.epsevg.PROP.LAB1.model;

import java.util.Date;

/**
 *
 * @author Usuari
 */
public abstract class Persona {
    private int id;
    private String nom;
    private String cognoms;
    private Date dataNaixement;
    private boolean alta;

    public Persona(int id, String nom, String cognoms) {
        setId(id);
        setNom(nom);
        setCognoms(cognoms);
    }

   public abstract String getNIF();
    
    
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getNom() {
        return nom;
    }

    public void setNom(String nom) {
        if(nom==null || nom.isEmpty()) throw new RuntimeException("Nom obligatori!!!");
        this.nom = nom;
    }

    public String getCognoms() {
        return cognoms;
    }

    public void setCognoms(String cognoms) {
        this.cognoms = cognoms;
    }

    public Date getDataNaixement() {
        return dataNaixement;
    }

    public void setDataNaixement(Date dataNaixement) {
        this.dataNaixement = dataNaixement;
    }

    public boolean isAlta() {
        return alta;
    }

    public void setAlta(boolean alta) {
        this.alta = alta;
    }

    @Override
    public String toString() {
        return "Persona{" + "id=" + id + ", nom=" + nom + ", cognoms=" + cognoms + ", dataNaixement=" + dataNaixement + ", alta=" + alta + '}';
    }
    

}
