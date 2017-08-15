using System;
using System.IO;

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
            if (!File.Exists(pathTextoProcesado))
            {
                ProcesarTexto(pathTexto, pathTextoProcesado, out texto);
            }
            texto = File.ReadAllText(pathTextoProcesado);
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
               .Replace(Environment.NewLine, string.Empty);

            File.WriteAllText(pathTextoProcesado, texto);
        }
    }
}
