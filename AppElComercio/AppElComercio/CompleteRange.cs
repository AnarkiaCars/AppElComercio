using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppElComercio
{
    public class CompleteRange
    {
        public Int32[] build(Int32[] iIngreso)
        {
            //Declaramos variables
            List<Int32> listaFinal;
            
            //Ordenamos el array
            Array.Sort(iIngreso);

            //Convertimos el array a list para manipularlo mejor
            listaFinal = iIngreso.ToList();

            //Recorremos la lista y comparamos cada valor para insertar los necesarios
            for (int i = 0; i < iIngreso.Max(); i++)
            {
                if (!listaFinal[i].Equals(i + 1)) listaFinal.Insert(i, i + 1);
            }

            return listaFinal.ToArray();
        }
    }
}
