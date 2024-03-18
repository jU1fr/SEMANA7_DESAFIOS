using System;
using System.Collections.Generic;

class DESAFIO_3
{
    static List<string> tareas = new List<string>();

    static void Main(string[] args)
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("----- Menú -----");
            Console.WriteLine("1. Agregar una nueva tarea");
            Console.WriteLine("2. Ver todas las tareas");
            Console.WriteLine("3. Marcar una tarea como completada");
            Console.WriteLine("4. Eliminar una tarea");
            Console.WriteLine("5. Salir del programa");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarTarea();
                    break;
                case "2":
                    VerTareas();
                    break;
                case "3":
                    MarcarComoCompletada();
                    break;
                case "4":
                    EliminarTarea();
                    break;
                case "5":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void AgregarTarea()
    {
        Console.Write("Ingrese la nueva tarea: ");
        string nuevaTarea = Console.ReadLine();
        tareas.Add(nuevaTarea);
        Console.WriteLine("Tarea agregada exitosamente.");
    }

    static void VerTareas()
    {
        Console.WriteLine("----- Lista de Tareas -----");
        if (tareas.Count == 0)
        {
            Console.WriteLine("No hay tareas por realizar.");
        }
        else
        {
            for (int i = 0; i < tareas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tareas[i]}");
            }
        }
    }

    static void MarcarComoCompletada()
    {
        VerTareas();
        Console.Write("Ingrese el número de la tarea que desea marcar como completada: ");
        int indice = int.Parse(Console.ReadLine()) - 1;
        if (indice >= 0 && indice < tareas.Count)
        {
            Console.WriteLine($"La tarea '{tareas[indice]}' ha sido marcada como completada.");
            tareas.RemoveAt(indice);
        }
        else
        {
            Console.WriteLine("Índice de tarea no válido.");
        }
    }

    static void EliminarTarea()
    {
        VerTareas();
        Console.Write("Ingrese el número de la tarea que desea eliminar: ");
        int indice = int.Parse(Console.ReadLine()) - 1;
        if (indice >= 0 && indice < tareas.Count)
        {
            Console.WriteLine($"La tarea '{tareas[indice]}' ha sido eliminada.");
            tareas.RemoveAt(indice);
        }
        else
        {
            Console.WriteLine("Índice de tarea no válido.");
        }
    }
}
