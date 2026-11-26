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

    // Cuenta cuántos nombres de archivo contienen la palabra clave.
    // Indice >= Count -> no quedan entregas, conteo 0.
    // (1 si el archivo actual contiene la palabra, 0 si no) + conteo del resto.
    public static int ContarArchivosConPalabra(List<Entrega> entregas, string palabra, int indice = 0)
    {
        if (entregas == null)
        {
            throw new ArgumentNullException(nameof(entregas), "La lista de entregas no puede ser nula.");
        }

        if (string.IsNullOrWhiteSpace(palabra))
        {
            throw new ArgumentException("La palabra clave no puede estar vacía.", nameof(palabra));
        }

        if (indice >= entregas.Count)
        {
            return 0;
        }

        int actual = entregas[indice].NombreArchivo.Contains(palabra.Trim(), StringComparison.OrdinalIgnoreCase) ? 1 : 0;

        return actual + ContarArchivosConPalabra(entregas, palabra, indice + 1);
    }

    // Calcula n! de forma recursiva.
    // n <= 1 -> devuelve 1.
    // n * Factorial(n - 1).
    // Se limita a 20 porque 21! ya no cabe en un long. "desbordamiento".
    public static long Factorial(int n)
    {
        if (n < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "El factorial no está definido para números negativos.");
        }

        if (n > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "El máximo permitido es 20 (con más se desborda el tipo long).");
        }

        if (n <= 1)
        {
            return 1;
        }

        return n * Factorial(n - 1);
    }
}