using System;

namespace ndiTeste2
{
    public class Program2ComInjecaoSemInversao
    {
        private IMeuServico _servico;

        public void Main(string[] args)
        {
            IMeuRepositorio _meuRepositorio = new MeuRepositorio();
            IMeuServicoUtil _meuServicoUtil = new MeuServicoUtil(_meuRepositorio);
            _servico = new MeuServico(_meuServicoUtil);

            _servico.Executar();
        }
    }

    public interface IMeuServico
    {
        void Executar();
    }

    public class MeuServico : IMeuServico
    {
        private readonly IMeuServicoUtil _meuServicoUtil;

        public MeuServico(IMeuServicoUtil meuServicoUtil)
        {
            _meuServicoUtil = meuServicoUtil;
        }

        public void Executar()
        {
            Console.WriteLine("Sou o serviço principal e chamo o serviço utilitário");
            _meuServicoUtil.Executar();
        }
    }


    public interface IMeuServicoUtil
    {
        void Executar();
    }

    public class MeuServicoUtil : IMeuServicoUtil
    {
        private readonly IMeuRepositorio _meuRepositorio;

        public MeuServicoUtil(IMeuRepositorio meuRepositorio)
        {
            _meuRepositorio = meuRepositorio;
        }

        #region IMeuServicoUtil Members

        public void Executar()
        {
            Console.WriteLine("Sou o serviço utilitário que executa o repositório abaixo");
            _meuRepositorio.Repositoriar();
        }

        #endregion
    }


    public interface IMeuRepositorio
    {
        void Repositoriar();
    }

    public class MeuRepositorio : IMeuRepositorio
    {
        #region IMeuRepositorio Members

        public void Repositoriar()
        {
            Console.WriteLine("Eu sou o repositório");
        }

        #endregion
    }
}