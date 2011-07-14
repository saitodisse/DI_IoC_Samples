using System;

namespace ndiTeste1
{
    public class Program1SemInjecao
    {
        public void Main(string[] args)
        {
            var servico = new MeuServico();
            servico.Executar();
        }
    }


    public class MeuServico
    {
        private MeuServicoUtil _meuServicoUtil;

        public void Executar()
        {
            Console.WriteLine("Sou o serviço principal e chamo o serviço utilitário");
            _meuServicoUtil = new MeuServicoUtil();
            _meuServicoUtil.Executar();
        }
    }


    public class MeuServicoUtil
    {
        private MeuRepositorio _meuRepositorio;

        public void Executar()
        {
            Console.WriteLine("Sou o serviço utilitário que executa o repositório abaixo");
            _meuRepositorio = new MeuRepositorio();
            _meuRepositorio.Repositoriar();
        }
    }


    public class MeuRepositorio
    {
        public void Repositoriar()
        {
            Console.WriteLine("Eu sou o repositório");
        }
    }
}