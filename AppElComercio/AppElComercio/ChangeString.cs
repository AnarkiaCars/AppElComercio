using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppElComercio
{
    public class ChangeString
    {
        public static String build(String sIngreso)
        {
            //Declaración de variables
            String[] Abecedario = new String[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            Int32 iIndice = 0, iIndiceMax = 0;
            StringBuilder sSalida = new StringBuilder();

            //Obtenemos el índice máximo
            iIndiceMax = Array.IndexOf(Abecedario,"z");

            //Recorremos el teto ingresado como array
            foreach (char cLetra in sIngreso.ToArray())
            {
                String Valor = cLetra.ToString(); String ValorAgregar = Valor;
                Boolean esMayuscula = Char.IsUpper(cLetra);
                //Verificamos que el caracter es una letra
                iIndice = Array.IndexOf(Abecedario, Valor.ToLower());
                
                //Si es letra obtenemos la letra posterior
                if (!iIndice.Equals(-1)) ValorAgregar = Abecedario[(iIndice.Equals(iIndiceMax) ? 0 : ++iIndice)];

                iIndice = 0;
                
                //Se va creando el texto de salida
                sSalida.Append(esMayuscula?ValorAgregar.ToUpper():ValorAgregar);
            }

            return sSalida.ToString();
        }

    }
}
