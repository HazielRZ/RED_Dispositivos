namespace Red_del_Hogar;

public class Habitacion
{
    public string Nombre { get; set; }
    public double Area { get; set; }
    public int Enchufes { get; set; } // Nuevo atributo
    public bool Luz { get; set; }
    public List<Dispositivos> Dispositivos { get; set; }

    public Habitacion(string nombre, double area, int enchufes)
    {
        Nombre = nombre;
        Area = area;
        Enchufes = enchufes;
        Dispositivos = new List<Dispositivos>();
        Luz = false;
    }

    public void EncenderLuz()
    {
        Luz = true;
        Console.WriteLine($"La luz de la habitación {Nombre} ha sido encendida.");
    }

    public void ApagarLuz()
    {
        Luz = false;
        Console.WriteLine($"La luz de la habitación {Nombre} ha sido apagada.");
    }
  
    public void AgregarDispositivo(Dispositivos dispositivo)
    {
        Dispositivos.Add(dispositivo);
    }

    public void EncenderDispositivo(Dispositivos dispositivo)
    {
        if (Dispositivos.Contains(dispositivo))
        {
            dispositivo.Encender();
        }
    }

    public void ConectarDispositivo(Dispositivos dispositivo)
    {
        if (Dispositivos.Contains(dispositivo))
        {
            dispositivo.Conectado = true;
            Console.WriteLine($"{dispositivo.Marca} {dispositivo.Modelo} está conectado.");
        }
        else
        {
            Console.WriteLine($"El dispositivo no está en la habitación.");
        }
    }

    }