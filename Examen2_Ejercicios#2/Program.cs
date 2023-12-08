using System;
using System.Collections.Generic;


namespace Examen2_Ejercicios_2
{
    class Program
    {
        static List<Alumno> alumnos = new List<Alumno>();

        static void Main()
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("1. Agregar alumno");
                Console.WriteLine("2. Editar alumno");
                Console.WriteLine("3. Borrar alumno");
                Console.WriteLine("4. Mostrar lista de alumnos");
                Console.WriteLine("5. Salir");

                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarAlumno();
                        break;
                    case "2":
                        EditarAlumno();
                        break;
                    case "3":
                        BorrarAlumno();
                        break;
                    case "4":
                        MostrarListaAlumnos();
                        break;
                    case "5":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                        break;
                }
            }
        }

        static void AgregarAlumno()
        {
            Console.Clear();

            Console.Write("Número de cuenta: ");
            int numeroCuenta = int.Parse(Console.ReadLine());

            Console.Write("Nombre del alumno: ");
            string nombre = Console.ReadLine();

            Console.Write("Nota 1er parcial (0-20): ");
            double nota1 = ValidarNota();

            Console.Write("Nota 2do parcial (0-30): ");
            double nota2 = ValidarNota(30);

            Console.Write("Nota 3er parcial (0-20): ");
            double nota3 = ValidarNota();

            Console.Write("Nota 4to parcial (0-30): ");
            double nota4 = ValidarNota(30);

            double notaFinal = CalcularNotaFinal(nota1, nota2, nota3, nota4);

            alumnos.Add(new Alumno
            {
                NumeroCuenta = numeroCuenta,
                Nombre = nombre,
                Nota1 = nota1,
                Nota2 = nota2,
                Nota3 = nota3,
                Nota4 = nota4,
                NotaFinal = notaFinal
            });

            Console.WriteLine("Alumno agregado correctamente.");
        }

        static void EditarAlumno()
        {
            Console.Clear();

            Console.Write("Número de cuenta del alumno a editar: ");
            int numeroCuenta = int.Parse(Console.ReadLine());

            Alumno alumno = alumnos.Find(a => a.NumeroCuenta == numeroCuenta);

            if (alumno != null)
            {
                Console.WriteLine($"Editando datos del alumno {alumno.Nombre} (Número de cuenta: {alumno.NumeroCuenta})");

                Console.Write("Nuevo nombre del alumno: ");
                alumno.Nombre = Console.ReadLine();

                Console.Write("Nueva nota 1er parcial (0-20): ");
                alumno.Nota1 = ValidarNota();

                Console.Write("Nueva nota 2do parcial (0-30): ");
                alumno.Nota2 = ValidarNota(30);

                Console.Write("Nueva nota 3er parcial (0-20): ");
                alumno.Nota3 = ValidarNota();

                Console.Write("Nueva nota 4to parcial (0-30): ");
                alumno.Nota4 = ValidarNota(30);

                alumno.NotaFinal = CalcularNotaFinal(alumno.Nota1, alumno.Nota2, alumno.Nota3, alumno.Nota4);

                Console.WriteLine("Datos del alumno editados correctamente.");
            }
            else
            {
                Console.WriteLine($"No se encontró un alumno con el número de cuenta {numeroCuenta}.");
            }
        }

        static void BorrarAlumno()
        {
            Console.Clear();
            Console.Write("Número de cuenta del alumno a borrar: ");
            int numeroCuenta = int.Parse(Console.ReadLine());

            Alumno alumno = alumnos.Find(a => a.NumeroCuenta == numeroCuenta);

            if (alumno != null)
            {
                alumnos.Remove(alumno);
                Console.WriteLine($"Alumno {alumno.Nombre} (Número de cuenta: {alumno.NumeroCuenta}) borrado correctamente.");
            }
            else
            {
                Console.WriteLine($"No se encontró un alumno con el número de cuenta {numeroCuenta}.");
            }
        }

        static void MostrarListaAlumnos()
        {
            Console.Clear(); 

            Console.WriteLine("Lista de alumnos:");
            Console.WriteLine("Número de cuenta\tNombre\t1er parcial\t2do parcial\t3er parcial\t4to parcial\tNota Final");

            foreach (var alumno in alumnos)
            {
                Console.WriteLine($"{alumno.NumeroCuenta,-16}{alumno.Nombre,-16}{alumno.Nota1,-16}{alumno.Nota2,-16}{alumno.Nota3,-16}{alumno.Nota4,-16}{alumno.NotaFinal,-16}");
            }

            Console.ReadLine();
        }

        static double ValidarNota(double maximo = 20)
        {
            double nota;
            while (!double.TryParse(Console.ReadLine(), out nota) || nota < 0 || nota > maximo)
            {
                Console.Write($"Ingrese una nota válida (0-{maximo}): ");
            }
            return nota;
        }

        static double CalcularNotaFinal(double nota1, double nota2, double nota3, double nota4)
        {
            double notaFinal = nota1 + nota2 + nota3 + nota4;
            return notaFinal > 100 ? 100 : notaFinal;
        }
    }

    class Alumno
    {
        public int NumeroCuenta { get; set; }
        public string Nombre { get; set; }
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double Nota3 { get; set; }
        public double Nota4 { get; set; }
        public double NotaFinal { get; set; }
    }
}