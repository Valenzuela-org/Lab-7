namespace Lab7;

public static class Funciones
{
    // Suma los puntajes de las entregas desde indice hasta el final.
    // Indice == Count -> no quedan entregas, suma 0.
    // Puntaje actual + suma del resto (indice + 1).
    public static double SumarPuntajes(List<Entrega> entregas, int indice = 0)
    {
        if (entregas == null)
        {
            throw new ArgumentNullException(nameof(entregas), "La lista de entregas no puede ser nula.");
        }

        if (indice >= entregas.Count)
        {
            return 0;
        }

        return entregas[indice].Puntaje + SumarPuntajes(entregas, indice + 1);
    }

    // Busca un código de estudiante y devuelve su posición en la lista (o -1 si no existe).
    // Indice >= Count -> se acabó la lista, no se encontró (-1).
    // El código de la entrega actual coincide -> devuelve indice.
    // No coincide -> busca en el resto (indice + 1).
    public static int BuscarCodigo(List<Entrega> entregas, string codigo, int indice = 0)
    {
        if (entregas == null)
        {
            throw new ArgumentNullException(nameof(entregas), "La lista de entregas no puede ser nula.");
        }

        if (string.IsNullOrWhiteSpace(codigo))
        {
            throw new ArgumentException("El código a buscar no puede estar vacío.", nameof(codigo));
        }

        if (indice >= entregas.Count)
        {
            return -1;
        }

        if (string.Equals(entregas[indice].Codigo, codigo.Trim(), StringComparison.OrdinalIgnoreCase))
        {
            return indice;
        }

        return BuscarCodigo(entregas, codigo, indice + 1);
    }
}