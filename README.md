# Practica_final_-10.


En este programa se usa un enum llamado EstadoSolicitud para manejar los estados de cada solicitud, como Pendiente, EnProceso, Completada y Cancelada. Esto ayuda bastante porque en vez de escribir los estados a mano (y equivocarse con cosas como “pendient” o “procesando”), el sistema solo deja elegir opciones válidas. Así todo queda más organizado y sin errores raros.

En general, el programa es un sistema sencillo donde se pueden registrar solicitudes de clientes, verlas, buscarlas por ID y cambiarles el estado. Todo se maneja con una lista y un menú en consola, usando clases ETC.....

imagenes:
<img width="960" height="540" alt="1" src="https://github.com/user-attachments/assets/b815468c-75dd-4475-aa2d-9eb77017386b" />
<img width="960" height="540" alt="2" src="https://github.com/user-attachments/assets/39a0a4eb-0420-416b-94c7-42e1edb0a2a0" />
<img width="960" height="540" alt="3" src="https://github.com/user-attachments/assets/6d837ed0-03cb-46df-8a37-b5c90a6925ec" />
<img width="960" height="540" alt="4" src="https://github.com/user-attachments/assets/1111af99-d3c6-4cd2-b3fa-d9ba1311a339" />
<img width="960" height="540" alt="5" src="https://github.com/user-attachments/assets/ce3e4704-317e-4bbb-bdcd-01a06dec3624" />
<img width="960" height="540" alt="6" src="https://github.com/user-attachments/assets/1ba2ff80-ea30-4d7e-9ebd-3b02030e6828" />

codigo fuente :

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



