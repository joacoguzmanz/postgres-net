namespace guzman.joaquin.MP06.UF04.NET.Acces.Dades.Postgres
{
    class Program
    {
        static void Main()
        {
            var connectionString = "Host=localhost;Port=5432;Username=joacoguzman;Password=;Database=mp06_uf02_aea1";
            var vehicleRepository = new VehicleRepository(connectionString);
            
            MenuLogic(vehicleRepository);
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\n---- Menu ----");
            Console.WriteLine("1. Crear vehicle");
            Console.WriteLine("2. Listar vehicles");
            Console.WriteLine("3. Actualitzar vehicle");
            Console.WriteLine("4. Borrar vehicle");
            Console.WriteLine("5. Sortir");
            Console.Write("Tria una opció: ");
        }

        private static void MenuLogic(VehicleRepository vehicleRepository)
        {
            bool exit = false;
            while (!exit)
            {
                DisplayMenu();
                string input = Console.ReadLine() ?? "";
                switch (input)
                {
                    case "1":
                        Vehicle vehicle = new Vehicle();
                        Console.WriteLine("\n---- Crear vehicle ----");
                        Console.Write("Introdueix marca: ");
                        vehicle.Marca = Console.ReadLine() ?? "";
                        Console.Write("Introdueix model: ");
                        vehicle.Model = Console.ReadLine() ?? "";
                        Console.Write("Introdueix capacitat del maleter: ");
                        vehicle.CapacitatMaleter = int.Parse(Console.ReadLine() ?? "");
                        vehicleRepository.Crear(vehicle);
                        break;
                    case "2":
                        List<Vehicle> vehiclesList = vehicleRepository.ListarTodos();
                        Console.WriteLine("\n---- Listar vehicles ----");
                        foreach (Vehicle vehicleActual in vehiclesList)
                        {
                            Console.WriteLine(vehicleActual.Id + " | " + vehicleActual.Marca + " " + vehicleActual.Model + " | Capacitat: " + vehicleActual.CapacitatMaleter);
                        }
                        break;
                    case "3":
                        Vehicle vehicleActualitzat = new Vehicle();
                        Console.WriteLine("\n---- Actualitzar vehicle ----");
                        Console.Write("Introdueix Id: ");
                        vehicleActualitzat.Id = int.Parse(Console.ReadLine() ?? "");
                        Console.Write("Introdueix marca: ");
                        vehicleActualitzat.Marca = Console.ReadLine() ?? "";
                        Console.Write("Introdueix model: ");
                        vehicleActualitzat.Model = Console.ReadLine() ?? "";
                        Console.Write("Introdueix capacitat del maleter: ");
                        vehicleActualitzat.CapacitatMaleter = int.Parse(Console.ReadLine() ?? "");
                        vehicleRepository.Actualitzar(vehicleActualitzat);
                        break;
                    case "4":
                        Console.WriteLine("\n---- Borrar vehicle ----");
                        Console.Write("Introdueix Id: ");
                        int vehicleId = int.Parse(Console.ReadLine() ?? "");
                        vehicleRepository.Eliminar(vehicleId);
                        break;
                    case "5":
                        exit = true;
                        Console.WriteLine("Sortint del programa");
                        break;
                    default:
                        Console.WriteLine("Elecció invàlida");
                        break;
                }
            }
        }
    }
}
