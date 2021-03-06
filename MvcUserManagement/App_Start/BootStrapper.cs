﻿using MvcDataManager;
using MvcUserManagement.data;
using MvcUserManagement.data.EmployeeRespository;
using System.Reflection;
using LightInject;


namespace MvcUserManagement.App_Start
{
    public static class BootStrapper
    {
        public static void Run()
        {
            SetAutoFacContainer();
        }

        private static void SetAutoFacContainer()
        {
            var dbcontext = new MvcUserManagementDbContext();
            var container = new ServiceContainer();
            container.RegisterControllers(Assembly.GetExecutingAssembly());
            container.Register<IUnitOfWork>((factory) => new UnitOfWork(dbcontext));
            container.Register(typeof(IRepository<>), typeof(RepositoryBase<>));
            container.Register<IEmployeeRepository, EmployeeRepository>(new PerRequestLifeTime());
            container.EnableMvc();
        }
    }
}