package org.example.prueba2.dominio;

import javax.swing.*;

public class User {
    private int Id;
    private String Nombre;
    private String Apellido;
    private String PasswordHash;
    private String Email;
    private String Genero;
    private String Rol;
    private byte Status;

    public User() {
    }

    public User(int Id, String Nombre, String Apellido, String PasswordHash, String Email, String Genero, String Rol, byte Status) {
        this.Id = Id;
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.PasswordHash = PasswordHash;
        this.Email = Email;
        this.Genero = Genero;
        this.Rol = Rol;
        this.Status = Status;
    }

    public int getId() {
        return Id;
    }

    public void setId(int Id) {
        this.Id = Id;
    }

    public String getNombre() { return Nombre; }

    public void setNombre(String Nombre) { this.Nombre = Nombre; }

    public String getApellido() { return Apellido; }

    public void setApellido(String Apellido) { this.Apellido = Apellido; }

    public String getPasswordHash() { return PasswordHash; }

    public void setPasswordHash(String PasswordHash) { this.PasswordHash = PasswordHash; }

    public String getEmail() { return Email; }

    public void setEmail(String Email) { this.Email = Email; }

    public String getGenero() { return Genero; }

    public void setGenero(String Genero) { this.Genero = Genero; }

    public String getRol() { return Rol; }

    public void setRol(String Rol) { this.Rol = Rol; }

    public byte getStatus() { return Status; }

    public void setStatus(byte Status) { this.Status = Status; }

    public String getStrEstatus()
    {
        String str = "";
        switch (Status)
        {
            case 1:
                str = "ACTIVO";
                break;
            case 2:
                str = "INACTIVO";
            default:
                str = "";
        }
        return str;
    }

}
