using System;
using System.Collections.Generic;
using System.Data.Entity;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF;
using Ninject;

namespace iTechArt.Labs.iTechArtSurvey.BusinessLayer.Config
{
    public class NinjectDependencyResolver
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
        }
    }
}