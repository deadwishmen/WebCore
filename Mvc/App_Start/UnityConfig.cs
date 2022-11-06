using AutoMapper;
using Business.IBusiness;
using Business.Implements;
using Business.Mapping;
using Repositori.Repositories;
using Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace Mvc.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<ICategoryFilmRepository, CategoryFilmRepository>();
            container.RegisterType<IFilmRepository, FilmRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IFileRepository, FileRepository>();
            container.RegisterType<IRateRepository, RateRepository>();
            container.RegisterType<ICategoryFilmBusiness, CategoryFilmBusiness>();
            container.RegisterType<IFileBusiness, FileBusiness>();
            container.RegisterType<IRateBusiness, RateBusiness>();
            container.RegisterType<IUserBusiness, UserBusiness>();
            container.RegisterType<IFilmBusiness, FilmBusiness>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}