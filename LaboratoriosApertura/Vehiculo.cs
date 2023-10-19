using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LaboratoriosApertura
{
    public class Vehiculo
    {
        public string modelo;
        public Persona dueño;
        public string matricula;
        public string tamaño;
        public float[] dimensiones;

        public Vehiculo()
        {
            Console.WriteLine("Ingrese el modelo: ");
            modelo = Console.ReadLine();
            dueño = new Persona();
            Console.WriteLine("Ingrese la matrícula: ");
            matricula = Console.ReadLine();
            tamaño = Funciones.GenerarTamaño();
            dimensiones = GenerarDimensiones(tamaño);
        }

        private float[] GenerarDimensiones(string tamaño)
        {
            float[] anchosMax = { 1.5f, 2f, 4f };
            float[] dimensiones = new float[2];
            float largo = 0;
            float ancho = 0;
            string[] nombresEnum = Enum.GetNames(typeof(Tamaños));
            Tamaños[] tamañosEnum = (Tamaños[])Enum.GetValues(typeof(Tamaños));
            for (int i = 0; i < nombresEnum.Length; i++)
            {
                if (nombresEnum[i] == tamaño)
                {
                    if (i > 0)
                    {
                        largo = (float)(new Random().NextDouble() * ((int)tamañosEnum[i]- (int)tamañosEnum[i - 1])) + (int)tamañosEnum[i - 1];
                        ancho = (float)(new Random().NextDouble() * (anchosMax[i] - anchosMax[i - 1]) + anchosMax[i - 1]);
                    }
                    else
                    {
                        largo = (float)(new Random().NextDouble() * (int)tamañosEnum[i]);
                        ancho = (float)(new Random().NextDouble() * anchosMax[i]);
                    }
                }
            }
            dimensiones[0] = largo;
            dimensiones[1] = ancho;
            return dimensiones;
        }
    }
}
