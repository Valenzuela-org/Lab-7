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
}