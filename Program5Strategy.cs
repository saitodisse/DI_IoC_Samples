using System;
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;

namespace ndiTeste5
{
    public class Program5Strategy
    {
        private IMeuServico _servico;

        public void Main(string[] args)
        {
            var container = new WindsorContainer();
            
            container.Register(Component.For<IMeuServico>().ImplementedBy<MeuServico>());
            container.Register(Component.For<IMeuServicoUtil>().ImplementedBy<MeuServicoUtil>());

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            container.Register(Component.For<IMeuRepositorio>().ImplementedBy<MeuRepositorio1>());
            container.Register(Component.For<IMeuRepositorio>().ImplementedBy<MeuRepositorio2>());

            _servico = container.Resolve<IMeuServico>();
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

        #region IMeuServico Members

        public void Executar()
        {
            Console.WriteLine("Sou o serviço principal e chamo o serviço utilitário");
            _meuServicoUtil.Executar();
        }

        #endregion
    }


    public interface IMeuServicoUtil
    {
        void Executar();
    }

    public class MeuServicoUtil : IMeuServicoUtil
    {
        private IEnumerable<IMeuRepositorio> _meuRepositoriosLista;

        public MeuServicoUtil(IEnumerable<IMeuRepositorio> meuRepositoriosLista)
        {
            _meuRepositoriosLista = meuRepositoriosLista;
        }

        #region IMeuServicoUtil Members

        public void Executar()
        {
            Console.WriteLine("Sou o serviço utilitário que executa o repositório abaixo");
            foreach (var meuRepositorio in _meuRepositoriosLista)
            {
                meuRepositorio.Repositoriar();
            }
        }

        #endregion
    }


    public interface IMeuRepositorio
    {
        void Repositoriar();
    }

    public class MeuRepositorio1 : IMeuRepositorio
    {
        private IMeuRepositorio _meuRepositorio2;
        public MeuRepositorio1(IMeuRepositorio meuRepositorio2)
        {
            _meuRepositorio2 = meuRepositorio2;
        }

        public void Repositoriar()
        {
            _meuRepositorio2.Repositoriar();
            Console.WriteLine("Eu sou o repositório 1");
        }
    }

    public class MeuRepositorio2 : IMeuRepositorio
    {
        public void Repositoriar()
        {
            Console.WriteLine("Eu sou o repositório MeuRepositorio 2");
        }
    }

}