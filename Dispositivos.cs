namespace Red_del_Hogar;

public class Dispositivos
{

    public string Marca { get; set; }
    public string Modelo { get; set; }
    public bool Conectado { get; set; } // Nuevo atributo
    public bool Encendido { get; set; }

    public Dispositivos(string marca, string modelo)
    {
        Marca = marca;
        Modelo = modelo;
        Conectado = false; // Inicialmente desconectado
        Encendido = false; // Inicialmenete apagado

    }
    public virtual void Encender()
    {
        if (Conectado)
        {
            if (!Encendido)
            {
            
                Encendido = true;
                Console.WriteLine($"{Marca} {Modelo} se ha encendido.");
            }
            else
            {
                Console.WriteLine($"{Marca} {Modelo} ya está encendido.");
            }
        }
        else
        {
            Console.WriteLine($"{Marca} {Modelo} no puede encenderse porque no está conectado.");
        }
    }

    
}


public class DispositivoMovil : Dispositivos
    {
        public string TamanoPantalla { get; set; }

        public DispositivoMovil(string marca, string modelo, string tamanoPantalla)
            : base(marca, modelo)
        {
            TamanoPantalla = tamanoPantalla;
        }
    }

    public class Telefono : DispositivoMovil
    {
        public string Tipo { get; set; }

        public Telefono(string marca, string modelo, string tamanoPantalla, string tipo)
            : base(marca, modelo, tamanoPantalla)
        {
            Tipo = tipo;
        }
    }

    // Definición de la clase DispositivoDeEscritorio
    public class DispositivoDeEscritorio : Dispositivos
    {
        public string Tipo { get; set; }

        public DispositivoDeEscritorio(string marca, string modelo, string tipo)
            : base(marca, modelo)
        {
            Tipo = tipo;
        }
    }

    public class Laptop : DispositivoDeEscritorio
    {
        public int RAM { get; set; }

        public Laptop(string marca, string modelo, string tipo, int ram)
            : base(marca, modelo, tipo)
        {
            RAM = ram;
        }
    }

    // Definición de la clase DispositivoElectrodomestico
    public class DispositivoElectrodomestico : Dispositivos
    {
        public string Energia { get; set; }

        public DispositivoElectrodomestico(string marca, string modelo, string energia)
            : base(marca, modelo)
        {
            Energia = energia;
        }
    }

    public class Refrigerador : DispositivoElectrodomestico
    {
        public double Capacidad { get; set; }

        public Refrigerador(string marca, string modelo, string energia, double capacidad)
            : base(marca, modelo, energia)
        {
            Capacidad = capacidad;
        }
    }

