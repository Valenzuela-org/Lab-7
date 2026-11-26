using Lab7;

List<Entrega> entregas = new List<Entrega>
{
    new Entrega("N2024001", "tarea1_final.pdf",      1, 18.5, "Entrega completa"),
    new Entrega("N2024002", "informe_v2.docx",       2, 15.0, "Faltó la conclusión"),
    new Entrega("N2024003", "lab6_codigo.zip",       1, 17.0, "Buen orden"),
    new Entrega("N2024004", "proyecto_final.pdf",    3, 12.5, "Reenviado dos veces"),
    new Entrega("N2024005", "ejercicios_v2.cs",      2, 14.0, "Falta validar entradas"),
    new Entrega("N2024006", "resumen.docx",          1, 19.0, "Excelente"),
    new Entrega("N2024007", "avance_final_v2.pdf",   4, 10.5, "Entrega tardía"),
    new Entrega("N2024008", "practica7.py",          1, 16.0, "Sin observaciones"),
};

int opcion = -1;

while (opcion != 0)
{
    Console.WriteLine();
    Console.WriteLine("===== ANÁLISIS DE ENTREGAS DIGITALES =====");
    Console.WriteLine("1. Listar entregas");
    Console.WriteLine("2. Sumatoria de puntajes (recursiva)");
    Console.WriteLine("3. Buscar código de estudiante (recursiva)");
    Console.WriteLine("4. Contar archivos con palabra clave (recursiva)");
    Console.WriteLine("5. Factorial (recursiva)");
    Console.WriteLine("6. Comparar recursiva vs. iterativa");
    Console.WriteLine("7. Ejecutar pruebas");
    Console.WriteLine("0. Salir");
    Console.Write("Elige una opción: ");

    string? entrada = Console.ReadLine();

    if (!int.TryParse(entrada, out opcion))
    {
        opcion = -1;
        Console.WriteLine("Opción inválida: escribe un número del menú.");
        continue;
    }

    switch (opcion)
    {
        case 1:
            foreach (Entrega e in entregas)
            {
                Console.WriteLine($"{e.Codigo} | {e.NombreArchivo} | intentos: {e.Intentos} | puntaje: {e.Puntaje} | {e.Observaciones}");
            }
            break;

        case 2:
            Console.WriteLine("Sumatoria de puntajes: " + Funciones.SumarPuntajes(entregas));
            break;

        case 3:
            Console.Write("Código a buscar: ");
            string? codigo = Console.ReadLine();
            try
            {
                int pos = Funciones.BuscarCodigo(entregas, codigo ?? "");
                if (pos == -1)
                {
                    Console.WriteLine("El código no existe en la lista.");
                }
                else
                {
                    Console.WriteLine($"Encontrado en la posición {pos}: {entregas[pos].NombreArchivo}");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            break;

        case 4:
            Console.Write("Palabra clave (ej. final, v2): ");
            string? palabra = Console.ReadLine();
            try
            {
                int total = Funciones.ContarArchivosConPalabra(entregas, palabra ?? "");
                Console.WriteLine($"Archivos que contienen '{palabra}': {total}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            break;

        case 5:
            Console.Write("Número para el factorial (0 a 20): ");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                try
                {
                    Console.WriteLine($"{n}! = {Funciones.Factorial(n)}");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Error: debes escribir un número entero.");
            }
            break;

        case 6:
            Console.WriteLine($"Sumatoria -> recursiva: {Funciones.SumarPuntajes(entregas)} | iterativa: {Funciones.SumarPuntajesIterativo(entregas)}");
            Console.WriteLine($"Búsqueda U2024004 -> recursiva: {Funciones.BuscarCodigo(entregas, "U2024004")} | iterativa: {Funciones.BuscarCodigoIterativo(entregas, "U2024004")}");
            Console.WriteLine($"Conteo 'final' -> recursiva: {Funciones.ContarArchivosConPalabra(entregas, "final")} | iterativa: {Funciones.ContarArchivosConPalabraIterativo(entregas, "final")}");
            break;

        case 7:
            Pruebas.Ejecutar(entregas);
            break;

        case 0:
            Console.WriteLine("Programa finalizado.");
            break;

        default:
            Console.WriteLine("Opción inválida: elige un número entre 0 y 7.");
            break;
    }
}