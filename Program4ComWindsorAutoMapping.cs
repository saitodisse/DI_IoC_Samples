﻿using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ndiTeste2;

namespace ndiTeste4
{
    public class Program4ComWindsorAutoMapping
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
            container.Register(AllTypes.FromThisAssembly().Pick().WithService.DefaultInterface());
            return container;
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
        public void Repositoriar()
        {
            Console.WriteLine("Eu sou o repositório MeuRepositorio 1");
        }
    }
}