using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppElComercio
{
    public class MoneyParts
    {
        public Decimal[][] build(Decimal dIngreso)
        {
            //Declaración de variables
            List<Decimal[]> listaSalida = new List<Decimal[]>();
            Decimal[] Monedas = new Decimal[] { 0.05m, 0.1m, 0.2m, 0.5m, 1, 2, 5, 10, 20, 50, 100, 200 };
            Decimal[] monedasMenores = Monedas.Where(x => x <= dIngreso).ToArray();

            //Se toman las monedas <= a la moneda ingresada
            monedasMenores = monedasMenores.OrderBy(x => x).ToArray();

            //Se recorren las monedas menores
            foreach (Decimal n in monedasMenores)
            {
                //Si la moneda es igual a la moneda ingresada entonces se agrega al resultado
                if (n == dIngreso)
                    listaSalida.Add(new Decimal[] { n });
                else
                {//Caso contrario se inicia una busqueda recursiva
                    List<Decimal> inferiores = monedasMenores.Where(x => x <= n).ToList();
                    List<Decimal> numeros = new List<Decimal>();
                    numeros.Add(n);
                    listaSalida.AddRange(Comparar(numeros, inferiores, dIngreso));
                }
            }

            return listaSalida.ToArray();
        }

        //Metodo que busca los valores que equivalen a la moneda solicitada.
        private List<Decimal[]> Comparar(List<Decimal> numeros, List<Decimal> inferiores, Decimal ValorBuscado)
        {
            List<Decimal[]> listaSalida = new List<Decimal[]>();
            Decimal Suma = numeros.Sum();

            foreach (Decimal n in inferiores)
            {
                List<Decimal> numerosCorrectos = new List<Decimal>();
                Decimal[] Copia = new Decimal[numeros.Count()];
                if ((Suma + n) == ValorBuscado)
                {
                    numeros.CopyTo(Copia);
                    numerosCorrectos = Copia.ToList();
                    numerosCorrectos.Add(n);
                    listaSalida.Add(numerosCorrectos.ToArray());
                }
                else if ((Suma + n) < ValorBuscado)
                {
                    List<Decimal> inferiores1 = inferiores.Where(x => x <= n).ToList();
                    numeros.CopyTo(Copia);
                    List<Decimal> numeros1 = Copia.ToList();
                    numeros1.Add(n);
                    listaSalida.AddRange(Comparar(numeros1, inferiores1, ValorBuscado));
                }
            }
            return listaSalida;
        }
    }
}
