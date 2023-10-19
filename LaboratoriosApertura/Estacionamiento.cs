using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoriosApertura
{
    public class Estacionamiento
    {
        public Vehiculo[] estacionamiento1 = new Vehiculo[12];
        public List<EspacioEstacionamiento2> estacionamiento2 = new List<EspacioEstacionamiento2>();

        public void AgregarVehiculo(Vehiculo vehiculo)
        {
            if (EspaciosVipDisponibles() && vehiculo.dueño != null && vehiculo.dueño.vip) //reviso si es vip
            {
                EstacionarEnEspacioVip(vehiculo);
            }
            else if (EspaciosEst1NoVipsDisponibles() && vehiculo.dueño != null) //Si no es vip o se acabaron los espacios vip
            {
                EstacionarEnEst1NoVip(vehiculo);
            }
            else if (!EspaciosEst1NoVipsDisponibles() && vehiculo.dueño != null) //si no se pudo estacionar en el 1
            {
                EstacionarEnEstacionamiento2(vehiculo);
            }
        }

        private bool EspaciosVipDisponibles()
        {
            bool espaciosVipDisponibles = true;
            if (estacionamiento1[2] != null && estacionamiento1[6] != null && estacionamiento1[11] != null)
            {
                espaciosVipDisponibles = false;
            }
            return espaciosVipDisponibles;
        }

        private bool EspaciosEst1NoVipsDisponibles()
        {
            bool espaciosDisponibles = true;
            int espacioOcupado = 0;
            for (int i = 0; i < estacionamiento1.Length; i++)
            {
                if (estacionamiento1[i] != null && (i != 2 && i != 6 && i != 11))
                {
                    espacioOcupado++;
                }
            }
            if (espacioOcupado + 3 == estacionamiento1.Length) // +3 porque son tres los lugares vip que no estoy contemplando
            {
                espaciosDisponibles = false;
            }
            return espaciosDisponibles;
        }

        private void EstacionarEnEspacioVip(Vehiculo vehiculo)
        {
            bool vehiculoEstacionado = false;
            for (int i = 0; i < estacionamiento1.Length; i++) //trato de estacionarlo en los lugares vip
            {
                if ((i == 2 || i == 6 || i == 11) && estacionamiento1[i] == null && vehiculoEstacionado == false)
                {
                    estacionamiento1[i] = vehiculo;
                    vehiculoEstacionado = true;
                }
            }
        }

        private void EstacionarEnEst1NoVip(Vehiculo vehiculo)
        {
            bool vehiculoEstacionado = false;
            for (int i = 0; i < estacionamiento1.Length; i++) // si no pude en los vip, trato en los vacios del estacionamiento1
            {
                if (i != 2 && i != 6 && i != 11 && estacionamiento1[i] == null && vehiculoEstacionado == false)
                {
                    estacionamiento1[i] = vehiculo;
                    vehiculoEstacionado = true;
                }
            }
        }

        private void EstacionarEnEstacionamiento2(Vehiculo vehiculo)
        {
            bool vehiculoEstacionado = false;
            do
            {
                EspacioEstacionamiento2 espacioNuevo = new EspacioEstacionamiento2(vehiculo); //genera una instancia de un espacio del estacionamiento2
                estacionamiento2.Add(espacioNuevo);
                for (int i = 0; i < estacionamiento2.Count; i++)
                {
                    if (estacionamiento2[i].vehiculo == null && estacionamiento2[i].tamaño == vehiculo.tamaño && vehiculoEstacionado == false)
                    {
                        estacionamiento2[i].vehiculo = vehiculo;
                        vehiculoEstacionado = true;
                    }
                }
            }
            while (estacionamiento2[estacionamiento2.Count - 1].vehiculo == null);
        }



        public void ListarVehiculos()
        {
            MostrarEstacionamiento1();
            MostrarEstacionamiento2();
        }
        private void MostrarEstacionamiento1()
        {
            Console.WriteLine($"ESTACIONAMIENTO 1\n");
            for (int i = 0; i < estacionamiento1.Length; i++)
            {
                if (estacionamiento1[i] != null)
                {
                    Console.WriteLine($"\n***************************************************");
                    Console.WriteLine($"Posición en el estacionamiento: {i + 1}");
                    Funciones.MostrarVehiculos(estacionamiento1[i]);
                    Console.WriteLine($"---------------------------------------------------");
                }
            }
        }
        private void MostrarEstacionamiento2()
        {
            Console.WriteLine($"\nESTACIONAMIENTO 2\n");
            for (int i = 0; i < estacionamiento2.Count; i++)
            {
                Console.WriteLine($"\n***************************************************");
                Console.WriteLine($"Posición {i} - Tamaño del espacio: {estacionamiento2[i].tamaño}");
                Funciones.MostrarVehiculos(estacionamiento2[i].vehiculo);
            }
            Console.WriteLine("");
        }



        public void RemoverVehiculo(string valor)
        { 
            bool vehiculoRemovido = RemoverVehiculoDeEst1(valor);
            if (vehiculoRemovido == false) { RemoverVehiculoDeEst2(valor); }
        }
        private bool RemoverVehiculoDeEst1(string valor)
        {
            bool vehiculoRemovido = false;
            for (int i = 0; i < estacionamiento1.Length; i++)
            {
                if (estacionamiento1[i] != null && (estacionamiento1[i].matricula == valor || estacionamiento1[i].dueño.dni == valor))
                {
                    estacionamiento1[i] = null;
                    vehiculoRemovido = true;
                }
            }
           return vehiculoRemovido;
        }
        private void RemoverVehiculoDeEst2(string valor)
        {
            for (int i = estacionamiento2.Count - 1; i >= 0; i--)
            {
                if (estacionamiento2[i].vehiculo != null && (estacionamiento2[i].vehiculo.matricula == valor || estacionamiento2[i].vehiculo.dueño.dni == valor))
                {
                    estacionamiento2[i].vehiculo = null;
                }
            }
        }



        public void RemoverVehiculosAleatorios()
        {
            RemoverVehiculosAleatoriosEstacionamiento1();
            RemoverVehiculosAleatoriosEstacionamiento2();
        }
        private void RemoverVehiculosAleatoriosEstacionamiento1()
        {
            int vehiculosDisponiblesEnEst1 = CantVehiculosEnEst1();
            if (vehiculosDisponiblesEnEst1 > 0)
            {
                int cantAEliminarDelEstacionamiento1 = new Random().Next(1, vehiculosDisponiblesEnEst1);
                List<int> indicesAEliminarEnEst1 = new List<int>();
                for (int i = 0; i < cantAEliminarDelEstacionamiento1; i++) // aquí voy a determinar qué índices voy a eliminar
                {
                    int indiceAEliminar = new Random().Next(estacionamiento1.Length);
                    if (estacionamiento1[indiceAEliminar] != null && !indicesAEliminarEnEst1.Contains(indiceAEliminar)) //esto es para no eliminar un espacio que ya esté vacío o que ya se iba a eliminar
                    {
                        indicesAEliminarEnEst1.Add(indiceAEliminar);
                    }
                    else { i--; }
                }
                foreach (int indiceAEliminar in indicesAEliminarEnEst1) //Elimina los índices seleccionados del estacionamiento1
                {
                    estacionamiento1[indiceAEliminar] = null;
                }
            }
        }
        private void RemoverVehiculosAleatoriosEstacionamiento2()
        {
            if (estacionamiento2.Count > 0)
            {
                int cantAEliminarDelEstacionamiento2 = new Random().Next(1, estacionamiento2.Count);

                for (int i = 0; i < cantAEliminarDelEstacionamiento2; i++)
                {
                    int indiceAEliminar = new Random().Next(estacionamiento2.Count);
                    estacionamiento2[indiceAEliminar].vehiculo = null;
                }
            }
        }
        private int CantVehiculosEnEst1()
        {
            int vehiculosDisponiblesEnEst1 = 0;
            for (int i = 0; i < estacionamiento1.Length; i++) { if (estacionamiento1[i] != null) { vehiculosDisponiblesEnEst1++; } }
            return vehiculosDisponiblesEnEst1;
        }
    }
} 
