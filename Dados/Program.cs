using System;

namespace Dados
{
    class Program
    {
        static void Main(string[] args)
        {
            Escrever("Digite o número de lados do dado: ");
            int numeroLados = LadosDado(StringToInt());
            Escrever($"O dado possui {numeroLados} lados!");
            int dadoRolado = RolarDados(numeroLados);
            Escrever($"Dado rolado parou no número {dadoRolado} e é um número '{ParOuImpar(dadoRolado)}'");
        }

        public static int LadosDado(int numero)
        {
            if (ChecaNumero(numero))
                return numero;
            else
            {
                Escrever("Entre com um número entre 2 e 100");
                return LadosDado(StringToInt());
            };             
        }

        public static bool ChecaNumero(int numero)
        {
            return (numero > 1 && numero <= 100);
        }

        private static int StringToInt()
        {
            try
            {
                int numero = Convert.ToInt32(Console.ReadLine());
                return numero;
            }
            catch
            {
                Console.WriteLine("Algarismo inválido! Entre com um número inteiro");
                return StringToInt();
            }
        }

        public static int RolarDados(int facesDado)
        {
            Random dado = new Random();
            return dado.Next(1, facesDado + 1);
        }

        public static string ParOuImpar (int numero)
        {
            return numero % 2 == 0 ? "Par" : "Ímpar";
        }

        public static void Escrever(string texto)
        {
            Console.WriteLine(texto);
        }
    }
}