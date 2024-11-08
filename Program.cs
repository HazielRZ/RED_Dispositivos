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
        _habitaciones[0].Dispositivos[0].Conectado = true;
        _habitaciones[0].Dispositivos[0].Encendido = true;

        _dispositivos.Add(new Laptop("Dell", "XPS 13", "Ultrabook", 16));
        _habitaciones[0].AgregarDispositivo(_dispositivos[1]);
        _habitaciones[0].Dispositivos[1].Conectado = true;
        _habitaciones[0].Dispositivos[1].Encendido = true;


        _dispositivos.Add(new Laptop("Asus", "Pro", "Ultrabook", 4));
        _habitaciones[0].AgregarDispositivo(_dispositivos[2]);
        _habitaciones[0].Dispositivos[2].Conectado = true;
        _habitaciones[0].Dispositivos[2].Encendido = true;

        _dispositivos.Add(new Laptop("Lenvo", "Pro1000", "Chafabook", 2));
        _habitaciones[0].AgregarDispositivo(_dispositivos[3]);
        _habitaciones[0].Dispositivos[3].Conectado = true;
        _habitaciones[0].Dispositivos[3].Encendido = false;

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
                MostrarDispositivosSinHabitacion();
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
        if (dispositivoSeleccionado == -1) return;

        Habitacion habitacionActual = null;
        foreach (var habitacion in _habitaciones)
        {
            if (habitacion.Dispositivos.Contains(_dispositivos[dispositivoSeleccionado]))
            {
                habitacionActual = habitacion;
                break;
            }
        }

        //Mostrar y seleccionar destino
        Console.WriteLine("Seleccione la habitación destino:");
        int habitacionDestino = MostrarYSeleccionarHabitaciones(_habitaciones);
        if (habitacionDestino == -1 || habitacionActual == _habitaciones[habitacionDestino]) return;

        if (_habitaciones[habitacionDestino].Dispositivos.Count >= _habitaciones[habitacionDestino].Enchufes)
        {
            Console.WriteLine("No hay suficientes enchufes en la habitación destino.");
            Menu();
        }

        if (habitacionActual != null)
        {
            habitacionActual.Dispositivos.Remove(_dispositivos[dispositivoSeleccionado]);
        }
        _habitaciones[habitacionDestino].AgregarDispositivo(_dispositivos[dispositivoSeleccionado]);
        _dispositivos[dispositivoSeleccionado].Conectado = false;
        _dispositivos[dispositivoSeleccionado].Encendido = false;

        Console.WriteLine($"El dispositivo {_dispositivos[dispositivoSeleccionado].Marca} {_dispositivos[dispositivoSeleccionado].Modelo} ha sido movido a la habitación {_habitaciones[habitacionDestino].Nombre}.");
        Menu();
    }


    private static void EncenderApagarDispositivo()
    {
        Console.WriteLine("Selecciona el dispositivo a encender/apagar:");
        int dispositivoSeleccionado = MostrarYSeleccionarDispositivos();

        
        if (dispositivoSeleccionado >= 0 && dispositivoSeleccionado < _dispositivos.Count)
        {
            var dispositivo = _dispositivos[dispositivoSeleccionado];

           
            if (dispositivo.Conectado)
            {
                
                if (!dispositivo.Encendido)
                {
                    // Contar los dispositivos encendidos
                    int dispositivosEncendidos = _dispositivos.Count(d => d.Encendido);

                    // Solo encender si hay menos de 3 dispositivos encendidos
                    if (dispositivosEncendidos < 3)
                    {
                        dispositivo.Encendido = true;
                        Console.WriteLine($"Dispositivo {dispositivo.Marca} {dispositivo.Modelo} encendido.");
                    }
                    else
                    {
                        Console.WriteLine("No se puede encender: ya hay 3 dispositivos encendidos.");
                    }
                }
                else
                {
                    // Si el dispositivo ya está encendido, se apaga
                    dispositivo.Encendido = false;
                    Console.WriteLine($"Dispositivo {dispositivo.Marca} {dispositivo.Modelo} apagado.");
                }
            }
            else
            {
                Console.WriteLine($"{dispositivo.Marca} {dispositivo.Modelo} no está conectado.");
            }
        }
        else
        {
            Console.WriteLine("Dispositivo no válido.");
        }

        Menu();
    }


    private static void MostrarDispositivosSinHabitacion()
    {
        Console.WriteLine("Dispositivos sin habitación:");
        foreach (var dispositivo in _dispositivos)
        {
            if (dispositivo.Habitacion == null)
            {
                Console.WriteLine(dispositivo.Marca + " " + dispositivo.Modelo);
            }
        }

        Menu();
    }

    private static void EncenderApagarLuzHabitacion()
    {
        Console.WriteLine("Selecciona la habitación:");
        int habitacionDestino = MostrarYSeleccionarHabitaciones(_habitaciones);

        // Si la selección es válida
        if (habitacionDestino != -1)
        {
            Habitacion habitacion = _habitaciones[habitacionDestino];

            // Evaluar el estado de la luz y cambiarlo
            if (habitacion.Luz)
            {
                habitacion.ApagarLuz();
            }
            else
            {
                habitacion.EncenderLuz();
            }
        }
        else
        {
            Console.WriteLine("Selección inválida. Inténtalo de nuevo.");
            Menu();
        }

        Menu();
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

        Dispositivos nuevoDispositivo = 
            null;

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
                break;
        }

        Console.WriteLine("Seleccione la habitación para el dispositivo:");
        for (int i = 0; i < _habitaciones.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_habitaciones[i].Nombre}");
        }

        int habitacionSeleccionada = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException()) - 1;
        if (habitacionSeleccionada >= 0 && habitacionSeleccionada < _habitaciones.Count)
        {
            _habitaciones[habitacionSeleccionada].AgregarDispositivo(nuevoDispositivo ?? throw new InvalidOperationException());
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
                _habitaciones.Find(h => h.Dispositivos.Contains(_dispositivos[dispositivoSeleccionado]))
                    ?.ConectarDispositivo(_dispositivos[dispositivoSeleccionado]);
            }
            else if (accion == "2")
            {
                _habitaciones.Find(h => h.Dispositivos.Contains(_dispositivos[dispositivoSeleccionado]))
                    ?.ConectarDispositivo(_dispositivos[dispositivoSeleccionado]);
                _dispositivos[dispositivoSeleccionado].Conectado = false; // Desconectar el dispositivo (faltaba)
                
                Console.WriteLine(
                    $"{_dispositivos[dispositivoSeleccionado].Marca} {_dispositivos[dispositivoSeleccionado].Modelo} está desconectado.");
                       _dispositivos[dispositivoSeleccionado].Encendido = false;
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
               
                string estadoEncendido = dispositivo.Encendido ? "Encendido" : "Apagado";
                Console.WriteLine(
                    $" - {dispositivo.Marca} {dispositivo.Modelo}:{estadoConectado} :{estadoEncendido} ");
            }
        }

        Menu();
    }

    private static int MostrarYSeleccionarDispositivos()
    {
        Console.WriteLine("Selecciona un dispositivo:");
        for (int i = 0; i < _dispositivos.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_dispositivos[i].Marca} {_dispositivos[i].Modelo} {_dispositivos[i].Habitacion}");
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

    private static int MostrarYSeleccionarHabitaciones(List<Habitacion> habitaciones)
    {
        if (habitaciones.Count == 0)
        {
            Console.WriteLine("No hay habitaciones disponibles.");
            return -1;
        }

        for (int i = 0; i < habitaciones.Count; i++)
        {
            Console.WriteLine(
                $"{i}. {habitaciones[i].Nombre} (Luz: {(habitaciones[i].Luz ? "Encendida" : "Apagada")})");
        }

        Console.Write("Ingresa el número de la habitación que deseas seleccionar: ");
        if (int.TryParse(Console.ReadLine(), out int seleccion) && seleccion >= 0 && seleccion < habitaciones.Count)
        {
            return seleccion;
        }

        return -1; 
    }



}