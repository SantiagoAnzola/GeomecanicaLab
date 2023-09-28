using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maquina
{
    // Propiedades básicas
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Uso { get; set; }
    public string Fabricante { get; set; }
    public string Modelo { get; set; }
    public string NumeroDeSerie { get; set; }
    public string FechaDeAdquisicion { get; set; }
    public string Estado { get; set; }
    public double Precio { get; set; }
    public string Ubicacion { get; set; }

    // Constructor
    public Maquina(string nombre, string descripcion, string uso, string fabricante,
        string modelo, string numeroDeSerie, string fechaDeAdquisicion, string estado, double precio,
        string ubicacion)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        Uso = uso;
        Fabricante = fabricante;
        Modelo = modelo;
        NumeroDeSerie = numeroDeSerie;
        FechaDeAdquisicion = fechaDeAdquisicion;
        Estado = estado;
        Precio = precio;
        Ubicacion = ubicacion;
    }
}
