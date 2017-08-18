using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Practica2
{
    internal class Program
    {
        private static void Main()
        {
            var folder = Environment.CurrentDirectory + "\\Textos\\";
            var pathTexto = $"{folder}cooldark.txt";
            var pathTextoProcesado = $"{folder}textoProcesado.txt";
            string texto;
            if (!File.Exists(pathTextoProcesado)) ProcesarTexto(pathTexto, pathTextoProcesado, out texto);
            texto = File.ReadAllText(pathTextoProcesado);

            var transiciones = RegistraTransiciones(texto);

            Console.WriteLine("1. Probabilidades sin memoria");
            Console.WriteLine("2. Probabilidades con memoria");
            var opc = int.Parse(Console.ReadLine() ?? "0");
            switch (opc)
            {
                case 1:
                    ProbabilidadSinMemoria(transiciones);
                    break;
                case 2:
                    ProbabilidadConMemoria(transiciones);
                    break;
            }
            Console.ReadKey();
        }

        private static void ProbabilidadConMemoria(List<TipoTransicion> transiciones)
        {

        }

        private static void ProbabilidadSinMemoria(IReadOnlyCollection<TipoTransicion> transiciones)
        {
            var totalTransiciones = transiciones.Count;
            foreach (var transicion in transiciones)
            {
                Console.WriteLine($"{transicion.Transicion} {(double)transicion.Cantidad / totalTransiciones}");
                if (transicion.Cantidad > totalTransiciones)
                    ;
            }
        }

        /// <summary>
        /// Cuenta y registra las transiciones en una lista
        /// </summary>
        /// <param name="texto">Texto descompuesto</param>
        private static List<TipoTransicion> RegistraTransiciones(string texto)
        {
            var textoDescompuesto = texto.ToCharArray();
            var transiciones = new List<TipoTransicion>();

            for (var i = 0; i < textoDescompuesto.Length; i++)
            {
                if (i + 1 >= textoDescompuesto.Length) break;
                var transicion = textoDescompuesto[i].ToString() + textoDescompuesto[i + 1];
                if (transiciones.Any(t => t.Transicion.Equals(transicion)))
                {
                    transiciones.First(t => t.Transicion.Equals(transicion))
                        .Cantidad++;
                }
                else
                {
                    transiciones.Add(new TipoTransicion
                    {
                        Transicion = transicion,
                        Cantidad = 1
                    });
                }
            }

            return transiciones;
        }

        /// <summary>
        /// Elimina los caracteres no deseados
        /// </summary>
        /// <param name="pathTexto">Archivo original</param>
        /// <param name="pathTextoProcesado">Texto procesado</param>
        /// <param name="texto">Texto a asignar</param>
        private static void ProcesarTexto(string pathTexto, string pathTextoProcesado, out string texto)
        {
            texto = File.ReadAllText(pathTexto)
                .Replace("!", string.Empty)
                .Replace("#", string.Empty)
                .Replace("$", string.Empty)
                .Replace("%", string.Empty)
                .Replace("&", string.Empty)
                .Replace("/", string.Empty)
                .Replace("(", string.Empty)
                .Replace(")", string.Empty)
                .Replace("=", string.Empty)
                .Replace("?", string.Empty)
                .Replace("'", string.Empty)
                .Replace("¡", string.Empty)
                .Replace("¿", string.Empty)
                .Replace("<", string.Empty)
                .Replace(">", string.Empty)
                .Replace("<", string.Empty)
                .Replace("´", string.Empty)
                .Replace("¨", string.Empty)
                .Replace("*", string.Empty)
                .Replace("+", string.Empty)
                .Replace("~", string.Empty)
                .Replace("{", string.Empty)
                .Replace("}", string.Empty)
                .Replace("[", string.Empty)
                .Replace("]", string.Empty)
                .Replace("`", string.Empty)
                .Replace(",", string.Empty)
                .Replace(";", string.Empty)
                .Replace(".", string.Empty)
                .Replace(":", string.Empty)
                .Replace("-", string.Empty)
                .Replace("_", string.Empty)
                .Replace("\t", string.Empty)
                .Replace("\n", string.Empty)
                .Replace("‘", string.Empty)
                .Replace("’", string.Empty)
                .Replace(" ", string.Empty)
                .Replace("*", string.Empty)
                .Replace("\"", string.Empty)
                .Replace(" ", string.Empty)
                .Replace("|", string.Empty)
                .Replace("^", string.Empty)
                .Replace(Environment.NewLine, string.Empty);

            File.WriteAllText(pathTextoProcesado, texto);
        }
    }

    internal class TipoTransicion
    {
        public string Transicion { get; set; }
        public int Cantidad { get; set; }
    }
}
