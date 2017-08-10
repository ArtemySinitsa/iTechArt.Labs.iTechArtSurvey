using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Repository;
using Ninject;

namespace iTechArt.Labs.iTechArtSurvey.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<DbContext>().To<SurveyContext>();
            kernel.Bind<IRepository<User>>().To<GenericRepository<User>>();
        }
    }
}