using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoriosApertura
{
    public class Persona
    {
        public string nombre;
        public string apellido;
        public string dni;
        public bool vip;
        public Persona()
        {
            Console.WriteLine("Ingrese el nombre: ");
            nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido: ");
            apellido = Console.ReadLine();
            Console.WriteLine("Ingrese el dni: ");
            dni = Console.ReadLine();

            Console.WriteLine("Es una persona VIP? \n1 - sí\n2 - no");
            string opcion=Console.ReadLine();
            if (opcion == "1") { vip = true; }
            else if (opcion == "2") {  vip = false; }
            else {
                Console.WriteLine("Error al ingresar la opción!");
                Console.WriteLine("Por defecto no se lo asignará como VIP");
                vip = false; }
        }
    }
}
