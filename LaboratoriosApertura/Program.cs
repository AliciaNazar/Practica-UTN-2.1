//Nazar, Alicia

using LaboratoriosApertura;
using System.Collections.Generic;

Estacionamiento estacionamiento = new Estacionamiento();

bool continuar=true;
while (continuar)
{
    //Console.Clear();
    Funciones.Menu();
    string opcion = Console.ReadLine();
    switch (opcion)
    {
        case "1": //Listar todos los vehículos
            estacionamiento.ListarVehiculos();
            break;
        case "2": //Agregar un nuevo vehículo
            Vehiculo vehiculo = new Vehiculo();
            estacionamiento.AgregarVehiculo(vehiculo);
            break;
        case "3": //Remover un vehículo en especial, dado su número de matrícula
            Console.WriteLine("Ingrese la matrícula del vehículo a remover: ");
            string matricula = Console.ReadLine();
            estacionamiento.RemoverVehiculo(1, matricula);
            break;
        case "4": //Remover un vehículo en especial, dado el dni de su dueño  
            Console.WriteLine("Ingrese el dni del dueño del vehículo a remover");
            string dni = Console.ReadLine();
            estacionamiento.RemoverVehiculo(2, dni);
            break;
        case "5": //Remover una cantidad aleatoria de vehículos.
            estacionamiento.RemoverVehiculosAleatorios();
            break;
        case "6": //Optimizar el espacio  
            Funciones.OptimizarAlmacenamiento(estacionamiento.estacionamiento2);
            break;
        case "7": //salir
            continuar = false;
            break;
        default:
            Console.WriteLine("Opción inválida!");
            break;
    }
}




