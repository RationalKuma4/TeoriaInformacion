using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Practica2
{
    internal class Program
    {
        public static List<string> Abecedario { get; } = new List<string> { "0", "1" };
        //public List<string> Abecedario { get; } = new List<string>
        //{
        //    "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"
        //};

        private static void Main()
        {
            var folder = Environment.CurrentDirectory + "\\Textos\\";
            var pathTexto = $"{folder}muestra1.txt";
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
                    //ProbabilidadSinMemoria(transiciones);
                    break;
                case 2:
                    ProbabilidadConMemoria(transiciones);
                    break;
            }
            Console.ReadKey();
        }

        private static void ProbabilidadConMemoria(List<TipoTransicion> transiciones)
        {
            foreach (var letra in Abecedario)
            {
                foreach (var letter in Abecedario)
                {
                    decimal nominador = transiciones.First(t => t.Transicion.Equals(letra + letter)).Cantidad;
                    decimal denominador = transiciones
                        .FindAll(t => t.Transicion.StartsWith(letra))
                        .Sum(t => t.Cantidad);
                    Console.WriteLine($"Probabilidad de trasmitir {letter} dado {letra} {nominador / denominador}");
                }
            }
        }

        //private static void ProbabilidadSinMemoria(IReadOnlyCollection<TipoTransicion> transiciones)
        //{

        //}

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
            var rgx = new Regex("[^a-zA-Z0-9_]+");
            texto = File.ReadAllText(pathTexto).ToLower();
            texto = rgx.Replace(texto, string.Empty);
            File.WriteAllText(pathTextoProcesado, texto);
        }
    }

    internal class TipoTransicion
    {
        public string Transicion { get; set; }
        public int Cantidad { get; set; }
    }
}
