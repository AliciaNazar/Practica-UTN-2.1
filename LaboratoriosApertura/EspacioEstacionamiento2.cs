using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoriosApertura
{
    public class EspacioEstacionamiento2
    {
        public Vehiculo vehiculo;
        public string tamaño;
        
        public EspacioEstacionamiento2(Vehiculo vehiculo)
        {
            tamaño = Funciones.GenerarTamaño();
            if (Funciones.PrimerValorMayorIgual(tamaño,vehiculo.tamaño))
            {
                this.vehiculo = vehiculo;
            }
        }

        
    }
}

