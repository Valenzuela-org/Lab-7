using System.Globalization;

namespace Lab7;

public static class Pruebas
{
    public static void Ejecutar(List<Entrega> entregas)
    {
        Console.WriteLine();
        Console.WriteLine("===== PRUEBAS: esperado vs. obtenido =====");

        Probar("Caso base", "Factorial(0)", "1",
            () => Funciones.Factorial(0).ToString());

        Probar("Caso recursivo simple", "Factorial(5)", "120",
            () => Funciones.Factorial(5).ToString());

        Probar("Lista vacía", "Buscar N2024001 en lista vacía", "-1",
            () => Funciones.BuscarCodigo(new List<Entrega>(), "N2024001").ToString());

        Probar("Código existente", "Buscar N2024004", "3",
            () => Funciones.BuscarCodigo(entregas, "N2024004").ToString());

        Probar("Código inexistente", "Buscar N9999999", "-1",
            () => Funciones.BuscarCodigo(entregas, "N9999999").ToString());

        Probar("Comparación iterativa", "Sumatoria recursiva vs. iterativa", "iguales",
            () => Funciones.SumarPuntajes(entregas) == Funciones.SumarPuntajesIterativo(entregas) ? "iguales" : "distintos");

        Probar("Sumatoria de puntajes", "Las 8 entregas", "122.5",
            () => Funciones.SumarPuntajes(entregas).ToString(CultureInfo.InvariantCulture));

        Probar("Entrada inválida (negativo)", "Factorial(-1)", "Rechazado",
            () => { Funciones.Factorial(-1); return "Aceptado"; });

        Probar("Búsqueda vacía", "Buscar \"\"", "Rechazado",
            () => { Funciones.BuscarCodigo(entregas, ""); return "Aceptado"; });
    }

    // Ejecuta una prueba. Si la función lanza ArgumentException, el resultado es "Rechazado".
    private static void Probar(string nombre, string entrada, string esperado, Func<string> accion)
    {
        string obtenido;
        try
        {
            obtenido = accion();
        }
        catch (ArgumentException)
        {
            obtenido = "Rechazado";
        }

        string resultado = obtenido == esperado ? "OK" : "FALLÓ";
        Console.WriteLine($"[{resultado}] {nombre} | Entrada: {entrada} | Esperado: {esperado} | Obtenido: {obtenido}");
    }
}