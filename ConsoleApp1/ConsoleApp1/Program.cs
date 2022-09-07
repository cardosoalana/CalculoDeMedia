
using System;

namespace ConsoleApp1
{
    class Program
    {
        private static String nomeAluno;
        private static String primeiraNota;
        private static String segundaNota;
        private static double firstGrade;
        private static double secondGrade;
        private static double media;

        static void Main(string[] args)
        {
            groupName();
            registerStudentData();
        }

        private static void groupName()
        {
            Console.WriteLine("Alana Gabrieli Cardoso (2022100399);");
            Console.WriteLine("Carlos Eduardo Krueger da Silva (2022101785);");
            Console.WriteLine("Gustavo Almeida de Freitas (2022202287);");
            Console.WriteLine("Nathan Moraes Correa (2022101394);\n");
        }

        private static void registerStudentData()
        {
            Console.WriteLine("\nEscreva o nome do Aluno: ");
            nomeAluno = Console.ReadLine();

            Console.WriteLine("Insira a primeira nota do Aluno: ");
            primeiraNota = Console.ReadLine();

            Console.WriteLine("Insira a segunda nota do Aluno: ");
            segundaNota = Console.ReadLine();

            if (verifyStudentData())
            {
                initGrade();
            } else
            {
                registerStudentData();
            }
        }

        private static void initGrade()
        {
            firstGrade = validateGrade(primeiraNota);
            secondGrade = validateGrade(segundaNota);

            calculateGrade(firstGrade, secondGrade);
            report();
        }

        private static bool verifyStudentData()
        {
            if (string.IsNullOrEmpty(nomeAluno))
            {
                return false;
            }

            if (string.IsNullOrEmpty(primeiraNota))
            {
                return false;
            }

            if (string.IsNullOrEmpty(segundaNota))
            {
                return false;
            }

            return true;
        }
       
        private static double validateGrade(String grade)
        {
            double validGrade;
            
            if (double.TryParse(grade, out validGrade) == false)
            {
                Console.WriteLine("Insira uma nota válida do Aluno: ");

                return validateGrade(Console.ReadLine());
            }

            return validGrade;
        }

        private static double calculateGrade(double firstGrade, double secondGrade)
        {
            media = (firstGrade + secondGrade) / 2;
            return media;
        }

        private static bool isStudentApproved()
        {
            return (media >= 6);
        }

        private static void report()
        {
            Console.WriteLine($"A média do Aluno {nomeAluno} foi {media}.");

            if (isStudentApproved())
            {
                Console.WriteLine("O aluno foi aprovado!");
            } else
            {
                Console.WriteLine("O aluno foi reprovado.");
            }
        }
    }
}
