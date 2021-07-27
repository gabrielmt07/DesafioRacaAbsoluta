using System;
using System.Collections.Generic;

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

            Escrever("");
            Escrever("--------------------------------------------");
            Escrever("");

            Escrever("Quantas vezes quer jogar os dados?: ");
            int jogarDados = StringToInt();
            var jogadas = Jogadas(jogarDados, numeroLados);
            Escrever($"A soma das jogadas foi de {SomarJogadas(jogadas)} ");
        }

        public static int SomarJogadas(List<int> jogadas)
        {
            int soma = 0;
            foreach(int jogada in jogadas)
            {
                soma += jogada;
            }
            return soma;
        }

        public static List<int> Jogadas(int jogarDados, int numeroLados)
        {
            List<int> jogadas = new List<int>();
            for (int i=1; i <= jogarDados; i++)
            {
                jogadas.Add(RolarDados(numeroLados));
                Escrever($"Jogada {i}: {jogadas[i-1]}");
            }
            return jogadas;
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