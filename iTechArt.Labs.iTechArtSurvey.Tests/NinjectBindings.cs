using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Repository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.Tests
{
    class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            var context = new SurveyContext();
            context.Roles.ToList().ForEach(e => Console.WriteLine(e));
            Bind<IRepository<Role>>().To<GenericRepository<Role>>().WithConstructorArgument("context", context);

        }
    }
}
