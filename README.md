# Lab 7 – Recursividad: análisis de entregas digitales

**Curso:** Fundamentos de Programación (CIIN1205P)
**Tema 7:** Recursividad – *Resolver dividiendo: recursividad, pruebas y comparación con iteración*
**Lenguaje:** C# (.NET, programa de consola)

## Integrantes

- Valenzuela Armas Jhon Anthony

## Descripción

Programa de consola que ayuda a un docente a analizar entregas digitales de estudiantes. Cada entrega tiene código de estudiante, nombre de archivo, intentos de envío, puntaje y observaciones. Se registran 8 entregas simuladas y se aplican funciones recursivas para:

- calcular la sumatoria de puntajes,
- buscar un código de estudiante,
- contar cuántos archivos contienen una palabra clave (por ejemplo `final` o `v2`),
- calcular el factorial (función simple adicional).

Además se implementaron versiones iterativas de la sumatoria, la búsqueda y el conteo para compararlas con las recursivas.

## Cómo ejecutar

```bash
cd Lab7
dotnet run
```

## Estructura del proyecto

| Archivo | Contenido |
|---|---|
| `Lab7/Entrega.cs` | Clase `Entrega` (código, archivo, intentos, puntaje, observaciones) |
| `Lab7/Funciones.cs` | Funciones recursivas e iterativas |
| `Lab7/Pruebas.cs` | Pruebas con resultado esperado vs. obtenido |
| `Lab7/Program.cs` | Datos simulados y menú interactivo |

## Pseudocódigo de las funciones recursivas

```
SumarPuntajes(entregas, indice):
    si indice >= cantidad de entregas:
        devolver 0
    devolver puntaje de entregas[indice] + SumarPuntajes(entregas, indice + 1)

BuscarCodigo(entregas, codigo, indice):
    si codigo está vacío: rechazar
    si indice >= cantidad de entregas:
        devolver -1
    si entregas[indice].codigo == codigo:
        devolver indice
    devolver BuscarCodigo(entregas, codigo, indice + 1)

ContarArchivosConPalabra(entregas, palabra, indice):
    si palabra está vacía: rechazar
    si indice >= cantidad de entregas:
        devolver 0
    actual = 1 si el nombre de archivo contiene la palabra, 0 si no
    devolver actual + ContarArchivosConPalabra(entregas, palabra, indice + 1)

Factorial(n):
    si n < 0 o n > 20: rechazar
    si n <= 1:
        devolver 1
    devolver n * Factorial(n - 1)
```

## Tabla 1. Diseño recursivo

| Función | Problema que resuelve | Caso base | Caso recursivo | Dato de prueba |
|---|---|---|---|---|
| `SumarPuntajes` | Suma los puntajes de todas las entregas | `indice >= Count` → devuelve 0 | `puntaje actual + SumarPuntajes(indice + 1)` | 8 entregas → 122.5 |
| `BuscarCodigo` | Ubica la posición de un código de estudiante | `indice >= Count` → -1 (no existe); o código coincide → `indice` | `BuscarCodigo(indice + 1)` | `N2024004` → posición 3 |
| `ContarArchivosConPalabra` | Cuenta archivos cuyo nombre contiene una palabra | `indice >= Count` → 0 | `(1 o 0) + ContarArchivosConPalabra(indice + 1)` | `final` → 3 |
| `Factorial` | Calcula n! | `n <= 1` → 1 | `n * Factorial(n - 1)` | `5` → 120 |

## Tabla 2. Comparación iterativa vs. recursiva

| Operación | Solución iterativa | Solución recursiva | Ventaja | Riesgo |
|---|---|---|---|---|
| Sumatoria | `for` que acumula en la variable `suma` | Puntaje actual + sumatoria del resto | La iterativa es más corta y no consume pila | La recursiva puede desbordar la pila con listas muy grandes |
| Búsqueda | `for` que devuelve `i` al encontrar el código; `-1` al terminar | Dos casos base: encontrado y fin de lista | La recursiva deja explícitos los dos casos de parada | Sin el caso base de "no encontrado", el índice se sale de la lista |
| Conteo en lista | `for` con contador que aumenta si la palabra aparece | `(1 o 0)` + conteo del resto | La iterativa es más fácil de leer y depurar | Una palabra vacía coincidiría con todos los archivos (se valida) |

## Tabla 3. Pruebas de recursividad

Las pruebas se ejecutan desde la opción 7 del menú.

| Prueba | Entrada | Resultado esperado | Resultado obtenido | Observación |
|---|---|---|---|---|
| Caso base | `Factorial(0)` | 1 | 1 | OK |
| Caso recursivo simple | `Factorial(5)` | 120 | 120 | OK |
| Lista vacía | Buscar `N2024001` en lista vacía | -1 | -1 | OK |
| Código existente | Buscar `N2024004` | 3 | 3 | OK |
| Código inexistente | Buscar `N9999999` | -1 | -1 | OK |
| Comparación iterativa | Sumatoria recursiva vs. iterativa | iguales | iguales | OK |
| Sumatoria de puntajes | Las 8 entregas | 122.5 | 122.5 | OK |
| Entrada inválida (negativo) | `Factorial(-1)` | Rechazado | Rechazado | OK |
| Búsqueda vacía | Buscar `""` | Rechazado | Rechazado | OK |

## Capturas de ejecución

[ Están guardadas en la carpeta `capturas/`]


## Riesgos detectados y correcciones aplicadas

- **Condición de parada incorrecta:** el caso base usa `indice >= Count` en lugar de `==`. Con `==`, si el índice se pasara del tamaño de la lista, la función nunca se detendría y produciría un desbordamiento de pila.
- **Exceso de llamadas:** el factorial se limita a `n <= 20`, porque desde 21! el resultado ya no cabe en un `long`. Además, cada llamada recursiva queda pendiente en la pila de memoria.
- **Búsqueda o palabra vacía:** `Contains("")` es verdadero para cualquier texto, así que una palabra vacía contaría todos los archivos. Se valida antes de buscar o contar.
- **Dificultad de depuración:** hay que seguir varias llamadas abiertas a la vez; por eso cada función tiene su caso base y recursivo comentados en el código.
## Análisis de resultados

### Reflexión técnica

**¿Cómo identificaste el caso base de cada función?**
Me pregunté en qué momento ya no queda nada por revisar o calcular. En las funciones sobre la lista, eso ocurre cuando el índice llega al final (`indice >= Count`). En el factorial ocurre cuando `n <= 1`. En la búsqueda hay un segundo caso base: cuando se encuentra el código.

**¿Qué ocurrió cuando el problema no se redujo correctamente en una llamada recursiva?**
Si el índice no avanza o el caso base nunca se cumple, la función se llama una y otra vez hasta desbordar la pila (`StackOverflow`). Por eso la llamada recursiva siempre usa `indice + 1` o `n - 1`, y el caso base usa `>=` o `<=`.

**¿Qué función fue más clara de forma recursiva y cuál fue más clara de forma iterativa?**
La búsqueda y el factorial se leen bien de forma recursiva, porque los casos base describen directamente la situación. La sumatoria y el conteo fueron más claros con `for`, porque solo hay que recorrer la lista y acumular.

**¿Qué pruebas demuestran que tu búsqueda recursiva funciona?**
Código existente (`N2024004` → posición 3), código inexistente (-1), lista vacía (-1), búsqueda vacía (rechazada) y que el resultado coincide con la versión iterativa.

**¿Qué limitaciones tiene la recursividad en programas grandes?**
Consume más memoria porque cada llamada queda pendiente en la pila, puede desbordarse con muchos elementos y es más difícil de depurar que un bucle.

### Reflexión ética y aprendizaje permanente

**¿Por qué sería irresponsable usar una función recursiva que no entiendes solo porque la sugirió una IA?**
Si falla (por ejemplo, con recursión infinita) no sabría encontrar el error ni corregirlo, y tampoco podría explicar mi trabajo. La responsabilidad académica y técnica del código es mía, no de la IA.

**¿Cómo validaste que la IA o documentación consultada no reemplazó tu razonamiento?**
Ejecuté el código y probé entradas válidas e inválidas, comparé el resultado recursivo con el iterativo.

**¿Qué estrategia usarías para aprender a depurar una función recursiva?**
Probar primero con valores muy pequeños (0, 1, 2), seguir las llamadas a mano en papel, usar puntos de interrupción en VS Code para ver cómo cambian los parámetros en cada llamada y revisar siempre primero el caso base.

**¿Cómo explicarías la recursividad a un compañero usando el caso base y recursivo?**
Es como contar las personas de una fila: "si no hay nadie delante, son 0 (caso base); si hay alguien, cuento 1 más lo que cuente la persona de adelante (caso recursivo)". Cada persona resuelve un problema más pequeño hasta llegar a la primera.

**¿Qué evidencia demuestra que aplicaste conocimiento nuevo y no solo copiaste un ejemplo?**
Validaciones de entradas (palabra vacía, negativos, límite 20), versiones iterativas para comparar, tabla de pruebas con casos propios, menú interactivo, cambios que hice después de probar.

## Conclusiones

1. Una función recursiva correcta necesita un caso base que detenga las llamadas y un caso recursivo que reduzca el problema; en este laboratorio, el índice o el número avanzan en cada llamada hasta llegar al caso base.
2. Las pruebas mostraron que las versiones recursiva e iterativa dan los mismos resultados; la iterativa es más simple para recorrer listas planas, mientras que la recursiva expresa mejor problemas definidos por casos, como la búsqueda o el factorial.
3. Los riesgos principales (condición de parada incorrecta, exceso de llamadas y dificultad de depuración) se controlan con validación de entradas, caso base con `>=` / `<=` y pruebas con casos límite.

## Declaración de uso responsable de inteligencia artificial

| Aspecto | Respuesta |
|---|---|
| 1. ¿Utilicé IA? | Sí |
| 2. Herramienta | Claude |
| 3. ¿Para qué la utilicé? | Ideas, errores, análisis |
| 4. ¿En qué parte? | Resultados, análisis, reporte |
| 5. ¿Cómo validé lo que la IA me proporcionó? | Ejecuté el código, comparé resultados, corregí errores |

**Declaración ética:** confirmo que revisé el contenido final, que apliqué pensamiento crítico frente a los resultados proporcionados por la IA, que no ingresé datos personales o sensibles en herramientas externas de IA y que asumo la responsabilidad por el trabajo presentado.

| Nombre(s) | Firma |
|---|---|
| Anthony | Anthony |

**Fecha (25/11/2026):** 
