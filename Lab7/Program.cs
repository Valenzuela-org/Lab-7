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

Console.WriteLine("Entregas registradas: " + entregas.Count);
foreach (Entrega e in entregas)
{
    Console.WriteLine($"{e.Codigo} | {e.NombreArchivo} | intentos: {e.Intentos} | puntaje: {e.Puntaje}");
}

Console.WriteLine();
Console.WriteLine("Sumatoria recursiva de puntajes: " + Funciones.SumarPuntajes(entregas));
Console.WriteLine("Sumatoria con lista vacía: " + Funciones.SumarPuntajes(new List<Entrega>()));

Console.WriteLine();
Console.WriteLine("Buscar N2024004 (existe): posición " + Funciones.BuscarCodigo(entregas, "N2024004"));
Console.WriteLine("Buscar N9999999 (no existe): posición " + Funciones.BuscarCodigo(entregas, "N9999999"));
Console.WriteLine("Buscar en lista vacía: posición " + Funciones.BuscarCodigo(new List<Entrega>(), "N2024001"));

try
{
    Funciones.BuscarCodigo(entregas, "   ");
}
catch (ArgumentException ex)
{
    Console.WriteLine("Búsqueda vacía rechazada: " + ex.Message);
}