using System;

class Program
{
    static void Main(string[] args)
    {
        // Ejemplo de arreglo bidimensional con los montos de las últimas 5 compras de 5 clientes
        decimal[,] montos = {
            {100, 150, 200, 250, 300},
            {80, 120, 160, 200, 240},
            {300, 350, 400, 450, 500},
            {50, 100, 150, 200, 250},
            {120, 180, 240, 300, 360}
        };

        AplicarDescuento(montos);
    }

    static void AplicarDescuento(decimal[,] montos)
    {
        // Definir el porcentaje de descuento según las reglas
        const decimal DESCUENTO_ALTO = 0.1m; // 10% de descuento para compras mayores a 300
        const decimal DESCUENTO_BAJO = 0.05m; // 5% de descuento para compras menores o iguales a 300

        // Recorrer cada fila (cliente)
        for (int i = 0; i < montos.GetLength(0); i++)
        {
            decimal totalCompraCliente = 0;

            // Calcular el total de compras del cliente actual
            for (int j = 0; j < montos.GetLength(1); j++)
            {
                totalCompraCliente += montos[i, j];
            }

            // Aplicar descuento según el total de compras
            decimal descuento = totalCompraCliente > 300 ? DESCUENTO_ALTO : DESCUENTO_BAJO;

            // Calcular el total con descuento
            decimal totalConDescuento = totalCompraCliente * (1 - descuento);

            Console.WriteLine($"Cliente {i + 1}: Total de compras = {totalCompraCliente:C}, Descuento = {descuento:P}, Total con descuento = {totalConDescuento:C}");
        }
    }
}

