using System;
using System.Threading;

namespace Examen2_Ejercicio_1
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Timer Espacial");

            int horas, minutos, segundos;

            do
            {
                Console.Write("Ingrese las horas (0-24): ");
            } while (!int.TryParse(Console.ReadLine(), out horas) || horas < 0 || horas > 24);

            do
            {
                Console.Write("Ingrese los minutos (0-59): ");
            } while (!int.TryParse(Console.ReadLine(), out minutos) || minutos < 0 || minutos > 59);

            do
            {
                Console.Write("Ingrese los segundos (0-59): ");
            } while (!int.TryParse(Console.ReadLine(), out segundos) || segundos < 0 || segundos > 59);

            if (horas == 0 && minutos == 0 && segundos == 0)
            {
                Console.WriteLine("¡Tiempo ingresado igual a 0! Cerrando el programa.");
                return;
            }



            while (horas > 0 || minutos > 0 || segundos > 0)
            {
                Console.Clear();

                MostrarFondoAleatorio();

                Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
                Console.WriteLine($"{horas:D2}:{minutos:D2}:{segundos:D2}");

                Thread.Sleep(1000);

                if (segundos > 0)
                    segundos--;
                else if (minutos > 0)
                {
                    minutos--;
                    segundos = 59;
                }
                else if (horas > 0)
                {
                    horas--;
                    minutos = 59;
                    segundos = 59;
                }

                Console.Beep(1200, 200);
            }

            Console.Clear();
            Console.WriteLine("El Tiempo a Finalizado");
            Console.Beep(1200, 1000);

            for (int i = 0; i < 9; i++)
            {
                Thread.Sleep(1000);
                Console.Beep(1200, 1000);
            }

            Console.Clear();
            Main(); // Reiniciar el programa
        }

        static void MostrarFondoAleatorio()
        {
            Random random = new Random();

            for (int i = 0; i < Console.WindowHeight; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    switch (random.Next(2))
                    {
                        case 0:
                            Console.Write("*");
                            break;
                        case 1:
                            Console.Write("+");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}