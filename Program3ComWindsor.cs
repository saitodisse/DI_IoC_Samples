using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace ndiTeste3
{
    public class Program3ComWindsor
    {
        private IMeuServico _servico;

        public void Main(string[] args)
        {
            var container = InicializarContainer();
            _servico = container.Resolve<IMeuServico>();

            _servico.Executar();
        }

        private static WindsorContainer InicializarContainer()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IMeuServico>().ImplementedBy<MeuServico>());
            container.Register(Component.For<IMeuServicoUtil>().ImplementedBy<MeuServicoUtil>());
            container.Register(Component.For<IMeuRepositorio>().ImplementedBy<MeuRepositorio>());
            return container;
        }
    }

    public interface IMeuServico
    {
        void Executar();
    }

    public class MeuServico : IMeuServico
    {
        private IMeuServicoUtil _meuServicoUtil;
        private IMeuRepositorio _meuRepositorio;

        public MeuServico(IMeuServicoUtil meuServicoUtil,
                          IMeuRepositorio meuRepositorio)
        {
            _meuServicoUtil = meuServicoUtil;
            _meuRepositorio = meuRepositorio;
        }

        #region IMeuServico Members

        public void Executar()
        {
            Console.WriteLine("Sou o serviço principal e chamo o serviço utilitário");
            _meuServicoUtil.Executar();
            _meuRepositorio.Repositoriar();
        }

        #endregion
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
        public MeuRepositorio()
        {
            
        }
        #region IMeuRepositorio Members

        public void Repositoriar()
        {
            Console.WriteLine("Eu sou o repositório");
        }

        #endregion
    }
}