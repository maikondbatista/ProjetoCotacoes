using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidaNumerosImpares();
            ValidaArrayStringsDuplicadas();
        }

        private static void ValidaArrayStringsDuplicadas()
        {
            Console.WriteLine("Palavras sem letras duplicadas: " + String.Join(" ", Duplicados(new string[] { "abracadabra", "allottee", "assessee" })));//=["abracadabra", "alote", "asese"]
            Console.WriteLine("Palavras sem letras duplicadas: " + String.Join(" ", Duplicados(new string[] { "kelless", "keenness" })));//=["keles", "kenes"]
            Console.ReadKey();

        }
        
        public static List<string> Duplicados(string[] palavras)
        {
            List<string> novasPalavras = new List<string>();
            foreach(string palavra in palavras)
            {
                StringBuilder sb = new StringBuilder();
                char ultimaLetra = '\0';
                foreach (char letra in palavra)
                {
                    if (ultimaLetra != letra)
                        sb.Append(letra);
                    ultimaLetra = letra;
                }
                novasPalavras.Add(sb.ToString());
            }
            return novasPalavras;
        }

        private static void ValidaNumerosImpares()
        {
            const string Positivo = "Todos os números são impares";
            const string Negativo = "Nem todos os números são impares, números pares: ";
            int[] numeros = { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };

            var numerosPares = (from numero in numeros
                                where numero % 2 == 0
                                select numero);
            var todosImpares = numerosPares.Count() == 0;
            Console.WriteLine(todosImpares ? Positivo : Negativo + String.Join(", ", numerosPares));
            Console.ReadKey();
        }
    }
}
