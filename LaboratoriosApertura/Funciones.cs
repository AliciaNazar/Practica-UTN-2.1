using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoriosApertura
{
    public  class Funciones
    {
        public static void MostrarVehiculos(Vehiculo vehiculo)
        {
            if (vehiculo != null)
            {
                //Console.WriteLine("mini: 4x1.5 --- standard: 4a5 x 1.5a2---- max: >5 x >2");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine($"Modelo: {vehiculo.modelo} - Dueño: {vehiculo.dueño.nombre} {vehiculo.dueño.apellido} - DNI: {vehiculo.dueño.dni} - Matrícula: {vehiculo.matricula}");
                Console.WriteLine($"El tamaño es: {vehiculo.tamaño}");
                Console.WriteLine($"Dimensiones: {vehiculo.dimensiones[0]} de largo por {vehiculo.dimensiones[1]} de ancho");
            }
        }

        public static void Menu()
        {
            Console.WriteLine("Qué desea hacer?: \n" +
                "1 - Listar todos los vehículos \n" +
                "2 - Agregar un nuevo vehículo \n" +
                "3 - Remover un vehículo en especial, dado su número de matrícula \n" +
                "4 - Remover un vehículo en especial, dado el dni de su dueño \n" +
                "5 - Remover una cantidad aleatoria de vehículos \n" +
                "6 - Optimizar el espacio \n" +
                "7 - Salir");
        }

        public static string GenerarTamaño()
        {
            List<string> listaTamaños = new List<string>();
            Tamaños[] tamañosEnum = (Tamaños[])Enum.GetValues(typeof(Tamaños));
            for (int i = 0; i < Enum.GetValues(typeof(Tamaños)).Length; i++)
            {
                listaTamaños.Add(Enum.GetName(typeof(Tamaños), tamañosEnum[i]));
            }
            int posicionEnum = new Random().Next(listaTamaños.Count);
            string tamaño = listaTamaños[posicionEnum];
            return tamaño;
        }

        public static List<string> GenerarListaTamaños()
        {
            List<string> listaTamaños = new List<string>();
            Tamaños[] tamañosEnum = (Tamaños[])Enum.GetValues(typeof(Tamaños));
            for (int i = 0; i < Enum.GetValues(typeof(Tamaños)).Length; i++)
            {
                listaTamaños.Add(Enum.GetName(typeof(Tamaños), tamañosEnum[i]));
            }
            return listaTamaños;
        }

        

        public static void OptimizarAlmacenamiento(List<EspacioEstacionamiento2> estacionamiento2)
        {
            List<Vehiculo> espacioTemporal = GenerarCopiaDeLista(estacionamiento2);
            ReubicarVehiculos(espacioTemporal,estacionamiento2);
        }


        private static void ReubicarVehiculos(List<Vehiculo> espacioTemporal, List<EspacioEstacionamiento2> estacionamiento2)
        {
            foreach (Vehiculo vehiculo in espacioTemporal)
            {
                bool continuar=true;
                int j = 0;
                while (j < estacionamiento2.Count && continuar)
                {
                    if (estacionamiento2[j].vehiculo == null && estacionamiento2[j].tamaño == vehiculo.tamaño)
                    {
                        estacionamiento2[j].vehiculo = vehiculo;
                        continuar = false;
                    }
                    j++;
                }
            }
        }
        private static List<Vehiculo> GenerarCopiaDeLista(List<EspacioEstacionamiento2> listaACopiar)
        {
            List<Vehiculo> espacioTemporal = new List<Vehiculo>();
            for (int i = 0; i < listaACopiar.Count; i++) // Extraigo los vehículos del estacionamiento2
            {
                if (listaACopiar[i].vehiculo != null)
                {
                    espacioTemporal.Add(listaACopiar[i].vehiculo);
                    listaACopiar[i].vehiculo = null; // Libero el espacio en el estacionamiento2
                }
            }
            return espacioTemporal;
        }

        public static bool PrimerValorMayorIgual(string tamaño1, string tamaño2)
        {
            List<string> lista = GenerarListaTamaños();
            int valorRelativo1 = 0;
            int valorRelativo2 = 0;

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i] == tamaño1)
                {
                    valorRelativo1 = i;
                }
                if (lista[i] == tamaño2)
                {
                    valorRelativo2 = i;
                }
            }
            if (valorRelativo1 >= valorRelativo2)
            {
                return true;
            }
            else { return false; }
        }
    }
}
