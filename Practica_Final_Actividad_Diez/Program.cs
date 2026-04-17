namespace Practica_Final_Actividad_Diez
{
  
        // Enumerador 
        public enum EstadoSolicitud
        {
            Pendiente = 1,
            EnProceso,
            Completada,
            Cancelada
        }

    // Clase Solicitud
    public class Solicitud
        {
            public int Id { get; set; }
            public string NombreCliente { get; set; }
            public string Descripcion { get; set; }
            public EstadoSolicitud Estado { get; set; }

            public void MostrarInfo()
            {
                Console.WriteLine($"ID: {Id}");
                Console.WriteLine($"Cliente: {NombreCliente}");
                Console.WriteLine($"Descripción: {Descripcion}");
                Console.WriteLine($"Estado: {Estado}");
                Console.WriteLine("...........................");
            }
        }
    
        internal class Program
        {
            static List<Solicitud> solicitudes = new List<Solicitud>();
            static int contadorId = 1;

            static void Main(string[] args)
            {
                int opcion;

                do
                {
                    Console.WriteLine("....... SISTEMA........");
                    Console.WriteLine("1. Registrar");
                    Console.WriteLine("2. Mostrar");
                    Console.WriteLine("3. Cambiar estado");
                    Console.WriteLine("4. Buscar");
                    Console.WriteLine("5. Salir");

                    opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Registrar();
                            break;
                        case 2:
                            Mostrar();
                            break;
                        case 3:
                            CambiarEstado();
                            break;
                        case 4:
                            Buscar();
                            break;
                    }

                } while (opcion != 5);
            }

            static void Registrar()
            {
                Solicitud s = new Solicitud();

                s.Id = contadorId++;
                Console.Write("Cliente: ");
                s.NombreCliente = Console.ReadLine();

                Console.Write("Descripción: ");
                s.Descripcion = Console.ReadLine();

                s.Estado = EstadoSolicitud.Pendiente;

                solicitudes.Add(s);
            }

            static void Mostrar()
            {
                foreach (var s in solicitudes)
                {
                    s.MostrarInfo();
                }
            }

            static void CambiarEstado()
            {
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine());

                var s = solicitudes.Find(x => x.Id == id);

                if (s == null)
                {
                    Console.WriteLine("No encontrado");
                    return;
                }

                Console.WriteLine("Estados:");
                foreach (var estado in Enum.GetValues(typeof(EstadoSolicitud)))
                {
                    Console.WriteLine($"{(int)estado}. {estado}");
                }

                int op = int.Parse(Console.ReadLine());

                if (Enum.IsDefined(typeof(EstadoSolicitud), op))
                {
                    s.Estado = (EstadoSolicitud)op;
                }
            }

            static void Buscar()
            {
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine());

                var s = solicitudes.Find(x => x.Id == id);

                if (s != null)
                    s.MostrarInfo();
                else
                    Console.WriteLine("No existe");
            }
        }
    }
