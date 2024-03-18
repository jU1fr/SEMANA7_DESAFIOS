using System;

class Program
{
    static void Main(string[] args)
    {
        char[,] tablero = new char[3, 3]; // Creamos un arreglo bidimensional de 3x3 para representar el tablero
        int turno = 1; // 1 para X, 2 para O
        bool finalizado = false;

        while (!finalizado)
        {
            DibujarTablero(tablero);
            Console.WriteLine($"Turno del jugador {(turno == 1 ? "X" : "O")}");
            int fila, columna;
            do
            {
                Console.Write("Ingresa la fila (0-2): ");
            } while (!int.TryParse(Console.ReadLine(), out fila) || fila < 0 || fila > 2);
            do
            {
                Console.Write("Ingresa la columna (0-2): ");
            } while (!int.TryParse(Console.ReadLine(), out columna) || columna < 0 || columna > 2);

            if (tablero[fila, columna] != '\0')
            {
                Console.WriteLine("Esa posición ya está ocupada. Intenta de nuevo.");
            }
            else
            {
                tablero[fila, columna] = (turno == 1) ? 'X' : 'O';
                turno = (turno == 1) ? 2 : 1;
                finalizado = VerificarGanador(tablero);
            }
        }

        DibujarTablero(tablero);
        Console.WriteLine("¡Juego terminado!");
    }

    static void DibujarTablero(char[,] tablero)
    {
        Console.Clear();
        Console.WriteLine("   0  1  2");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(" " + (tablero[i, j] == '\0' ? "." : tablero[i, j]) + " ");
            }
            Console.WriteLine();
        }
    }

    static bool VerificarGanador(char[,] tablero)
    {
        // Verificar filas
        for (int i = 0; i < 3; i++)
        {
            if (tablero[i, 0] != '\0' && tablero[i, 0] == tablero[i, 1] && tablero[i, 1] == tablero[i, 2])
                return true;
        }

        // Verificar columnas
        for (int i = 0; i < 3; i++)
        {
            if (tablero[0, i] != '\0' && tablero[0, i] == tablero[1, i] && tablero[1, i] == tablero[2, i])
                return true;
        }

        // Verificar diagonales
        if (tablero[0, 0] != '\0' && tablero[0, 0] == tablero[1, 1] && tablero[1, 1] == tablero[2, 2])
            return true;
        if (tablero[0, 2] != '\0' && tablero[0, 2] == tablero[1, 1] && tablero[1, 1] == tablero[2, 0])
            return true;

        // Si no hay ganador, verificar si hay empate
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (tablero[i, j] == '\0')
                    return false; // Aún hay casillas vacías
            }
        }

        // Si no hay ganador ni casillas vacías, hay empate
        return true;
    }
}