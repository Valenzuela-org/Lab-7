namespace Lab7;

public class Entrega
{
    public string Codigo { get; set; }
    public string NombreArchivo { get; set; }
    public int Intentos { get; set; }
    public double Puntaje { get; set; }
    public string Observaciones { get; set; }

    public Entrega(string codigo, string nombreArchivo, int intentos, double puntaje, string observaciones)
    {
        Codigo = codigo;
        NombreArchivo = nombreArchivo;
        Intentos = intentos;
        Puntaje = puntaje;
        Observaciones = observaciones;
    }
}