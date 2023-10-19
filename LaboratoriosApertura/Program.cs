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
        case "1":
            estacionamiento.ListarVehiculos();
            break;
        case "2":
            Vehiculo vehiculo = new Vehiculo();
            estacionamiento.AgregarVehiculo(vehiculo);
            break;
        case "3": 
            Console.WriteLine("Ingrese la matrícula del vehículo a remover: ");
            string matricula = Console.ReadLine();
            estacionamiento.RemoverVehiculo(matricula);
            break;
        case "4":  
            Console.WriteLine("Ingrese el dni del dueño del vehículo a remover");
            string dni = Console.ReadLine();
            estacionamiento.RemoverVehiculo(dni);
            break;
        case "5": 
            estacionamiento.RemoverVehiculosAleatorios();
            break;
        case "6": 
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




