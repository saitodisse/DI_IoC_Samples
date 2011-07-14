using System;
using ndiTeste1;
using ndiTeste2;
using ndiTeste3;
using ndiTeste4;

namespace ndiTeste
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var program1SemInjecao = new Program1SemInjecao();
            program1SemInjecao.Main(null);

            Console.Write("\r\n\r\n");

            var program2ComInjecaoSemInversao = new Program2ComInjecaoSemInversao();
            program2ComInjecaoSemInversao.Main(null);

            Console.Write("\r\n\r\n");

            var program3ComWindsor = new Program3ComWindsor();
            program3ComWindsor.Main(null);

            Console.Write("\r\n\r\n");

            var program4ComWindsorAutoMapping = new Program4ComWindsorAutoMapping();
            program4ComWindsorAutoMapping.Main(null);

            Console.ReadKey();
        }
    }
}