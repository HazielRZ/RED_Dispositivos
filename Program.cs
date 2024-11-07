namespace Red_del_Hogar;

internal class Program
    {
        private static List<Habitacion> _habitaciones = new List<Habitacion>();
        private static List<Dispositivos> _dispositivos = new List<Dispositivos>();

        static void Main(string[] args)
        {
            // Agregar habitaciones
            _habitaciones.Add(new Habitacion("Sala", 30.0, 5));
            _habitaciones.Add(new Habitacion("Cocina", 20.0, 3));
            _habitaciones.Add(new Habitacion("Dormitorio", 25.0, 4));

            // Agregar dispositivos
            _dispositivos.Add(new Telefono("Samsung", "Galaxy S21", "6.2 pulgadas", "Smartphone"));
            _habitaciones[0].AgregarDispositivo(_dispositivos[0]);

            _dispositivos.Add(new Laptop("Dell", "XPS 13", "Ultrabook", 16));
            _habitaciones[0].AgregarDispositivo(_dispositivos[1]);
            _habitaciones[0].Dispositivos[1].Conectado = true;

            Menu();
        }

        static void Menu()
        {
            // Seleccionar acción a realizar 
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Agregar Dispositivos nuevos (disponible)");
            Console.WriteLine("2. Agregar Habitaciones(disponible)");
            Console.WriteLine("3. Encender o Apagar Dispositivos");
            Console.WriteLine("4. Conectar o Desconectar Dispositivos(disponible)");
            Console.WriteLine("5. Encender o Apagar la luz de la Habitación");
            Console.WriteLine("6. Mostrar estado de las Habitaciones(disponible)");
            Console.WriteLine("7. Mostrar estado de los Dispositivos sin Habitación");
            Console.WriteLine("8. Mover Dispositivo");
            Console.WriteLine("9. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine() ?? throw new InvalidOperationException();

            switch (opcion)
            {
                case "1":
                    AgregarDispositivo();
                    Console.WriteLine("-----------------");
                    break;
                case "2":
                    AgregarHabitacion();
                    Console.WriteLine("-----------------");
                    break;
                case "3":
                    EncenderApagarDispositivo();
                    Console.WriteLine("-----------------");
                    break;
                case "4":
                    ConectarDesconectarDispositivo();
                    Console.WriteLine("-----------------");
                    break;
                case "5":
                    EncenderApagarLuzHabitacion();
                    Console.WriteLine("-----------------");
                    break;
                case "6":
                    MostrarEstadoHabitaciones();
                    Console.WriteLine("-----------------");
                    break;
                case "7":
                    //Mostrar dispositivos que no pertenecen a ninguna habitación
                    MostrarDispositivosNull();
                    Console.WriteLine("-----------------");
                    break;
                case "8":
                    MoverDispositivo();
                    Console.WriteLine("-----------------");
                    break;
                case "9":
                    return; 
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    Console.WriteLine("-----------------");
                    break;
            }
        }

        private static void MoverDispositivo()
        {
            int dispositivoSeleccionado = MostrarYSeleccionarDispositivos();
            if (dispositivoSeleccionado != -1)
            {
               //
            }

           

            
            int habitacionDestino = MostrarYSeleccionarHabitaciones();
            if (habitacionDestino != -1)
            {
                // mover el dispositivo a la habitación destino
            }
      

        
        }


        private static void EncenderApagarDispositivo()
        {
            Console.WriteLine("Selecciona el dispositivo a encender/apagar:");
            int dispositivoSeleccionado = MostrarYSeleccionarDispositivos();
            if (dispositivoSeleccionado != -1)
            {
                int dispositivoIndex = int.Parse(Console.ReadLine());

                _dispositivos[dispositivoIndex].Encendido = !_dispositivos[dispositivoIndex].Encendido;
                Console.WriteLine("Estado del dispositivo cambiado.");
            }

        }

        private static void MostrarDispositivosNull()
        {
            Console.WriteLine("Dispositivos sin habitación:");
            foreach (var dispositivo in _dispositivos)
            {
               //mostrar
            }
        }

        private static void EncenderApagarLuzHabitacion()
        {
            Console.WriteLine("Selecciona la habitación:");
            int habitacionDestino = MostrarYSeleccionarHabitaciones();
            if (habitacionDestino != -1)
            {
                //validar estado de luz y cambiarla
                
            }
           

           

            
        }

        private static void AgregarHabitacion()
        {
            Console.WriteLine("Ingrese el nombre de la habitacion:");
            string nombre = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.WriteLine("Ingrese el area de la habitacion:");
            double area = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine("Ingrese la cantidad de enchufes");
            int enchufes = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());         

            _habitaciones.Add(new Habitacion(nombre, area, enchufes));
            Menu();

        }

        private static void AgregarDispositivo()
        {
            Console.Write("Ingrese la marca del dispositivo: ");
            string marca = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.Write("Ingrese el modelo del dispositivo: ");
            string modelo = Console.ReadLine() ?? throw new InvalidOperationException();

            Console.WriteLine("Seleccione el tipo de dispositivo:");
            Console.WriteLine("1. Teléfono");
            Console.WriteLine("2. Laptop");
            Console.WriteLine("3. Refrigerador");
            string tipo = Console.ReadLine() ?? throw new InvalidOperationException();

            Dispositivos nuevoDispositivo = null;

            switch (tipo)
            {
                case "1":
                    Console.Write("Ingrese el tamaño de pantalla: ");
                    string tamanoPantalla = Console.ReadLine() ?? throw new InvalidOperationException();
                    Console.Write("Ingrese el tipo: ");
                    string tipoTelefono = Console.ReadLine() ?? throw new InvalidOperationException();
                    nuevoDispositivo = new Telefono(marca, modelo, tamanoPantalla, tipoTelefono);
                    break;
                case "2":
                    Console.Write("Ingrese el tipo de laptop: ");
                    string tipoLaptop = Console.ReadLine() ?? throw new InvalidOperationException();
                    Console.Write("Ingrese la RAM (en GB): ");
                    int ram = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                    nuevoDispositivo = new Laptop(marca, modelo, tipoLaptop, ram);
                    break;
                case "3":
                    Console.Write("Ingrese la capacidad: ");
                    double capacidad = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                    nuevoDispositivo = new Refrigerador(marca, modelo, "Eléctrico", capacidad);
                    break;
                default:
                    Console.WriteLine("Tipo de dispositivo no válido.");
                    return;
            }

            Console.WriteLine("Seleccione la habitación para el dispositivo:");
            for (int i = 0; i < _habitaciones.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_habitaciones[i].Nombre}");
            }

            int habitacionSeleccionada = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException()) - 1;
            if (habitacionSeleccionada >= 0 && habitacionSeleccionada < _habitaciones.Count)
            {
                _habitaciones[habitacionSeleccionada].AgregarDispositivo(nuevoDispositivo);
                _dispositivos.Add(nuevoDispositivo);
            }
            else
            {
                Console.WriteLine("Habitación no válida.");
            }

            Menu();
        }

        private static void ConectarDesconectarDispositivo()
        {
            Console.WriteLine("Seleccione un dispositivo:");
            for (int i = 0; i < _dispositivos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_dispositivos[i].Marca} {_dispositivos[i].Modelo}");
            }

            int dispositivoSeleccionado = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException()) - 1;
            if (dispositivoSeleccionado >= 0 && dispositivoSeleccionado < _dispositivos.Count)
            {
                Console.WriteLine("1. Conectar");
                Console.WriteLine("2. Desconectar");
                string accion = Console.ReadLine() ?? throw new InvalidOperationException();
                if (accion == "1")
                {
                    _habitaciones.Find(h => h.Dispositivos.Contains(_dispositivos[dispositivoSeleccionado]))!.ConectarDispositivo(_dispositivos[dispositivoSeleccionado]);
                }
                else if (accion == "2")
                {
                    _habitaciones.Find(h => h.Dispositivos.Contains(_dispositivos[dispositivoSeleccionado]))!.ConectarDispositivo(_dispositivos[dispositivoSeleccionado]);
                    _dispositivos[dispositivoSeleccionado].Conectado = false; // Desconectar el dispositivo (faltaba)
                    Console.WriteLine($"{_dispositivos[dispositivoSeleccionado].Marca} {_dispositivos[dispositivoSeleccionado].Modelo} está desconectado.");
                }
                else
                {
                    Console.WriteLine("Acción no válida.");
                }
            }
            else
            {
                Console.WriteLine("Dispositivo no válido.");
            }

            Menu();
        }

        private static void MostrarEstadoHabitaciones()
        {
            foreach (var habitacion in _habitaciones)
            {
                Console.WriteLine($"{habitacion.Nombre}:");
                foreach (var dispositivo in habitacion.Dispositivos)
                {
                    string estadoConectado = dispositivo.Conectado ? "Conectado" : "Desconectado";
                    Console.WriteLine($" - {dispositivo.Marca} {dispositivo.Modelo}: {estadoConectado} / (Encendido o Apagado)");
                }
            }

            Menu();
        }
        private static int MostrarYSeleccionarDispositivos()
        {
            Console.WriteLine("Selecciona un dispositivo:");
            for (int i = 0; i < _dispositivos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_dispositivos[i].Marca} {_dispositivos[i].Modelo}");
            }

            int dispositivoSeleccionado = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException()) - 1;

            // Validar la selección
            if (dispositivoSeleccionado >= 0 && dispositivoSeleccionado < _dispositivos.Count)
            {
                return dispositivoSeleccionado;
            }
            else
            {
                Console.WriteLine("Dispositivo no válido.");
                return -1; 
            }
        }
        private static int MostrarYSeleccionarHabitaciones()
        {
            Console.WriteLine("Selecciona una habitación:");
            for (int i = 0; i < _habitaciones.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_habitaciones[i].Nombre}");
            }

            int habitacionSeleccionada = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException()) - 1;

            // Validar la selección
            if (habitacionSeleccionada >= 0 && habitacionSeleccionada < _habitaciones.Count)
            {
                return habitacionSeleccionada;
            }
            else
            {
                Console.WriteLine("Habitación no válida.");
                return -1; 
            }
        }
    }