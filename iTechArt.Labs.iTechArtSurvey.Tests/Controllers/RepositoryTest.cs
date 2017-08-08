using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Repository;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.DomainModel;
using Ninject;
using System.Reflection;
using System.Linq;
using System.Threading.Tasks;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Migrations;
using System.Data.Entity;
using iTechArt.Labs.iTechArtSurvey.DataAccessLayer.EF;
namespace iTechArt.Labs.iTechArtSurvey.Tests.Controllers
{
    [TestClass]
    public class RepositoryTest
    {
        private IRepository<Role> repository;

        [TestInitialize]
        public void Initialize()
        {
            var kernel = new StandardKernel(new NinjectBindings());
            kernel.Load(Assembly.GetExecutingAssembly());
            repository = kernel.Get<IRepository<Role>>();
        }
        [TestMethod]
        public async Task RepositoryFindRole()
        {
            var actual = await repository.FindAsync(m=>m.Name =="Admin");

            Assert.AreEqual("Admin", actual.FirstOrDefault().Name);

        }

        [TestMethod]
        public async Task RepositoryCreateRole()
        {
            var createdRole = new Role() { Name = "Queen" };
            await repository.CreateAsync(createdRole);

            var allRoles = await repository.GetAllAsync();
            var queen = allRoles.FirstOrDefault(r => r.Name == "Queen");

            Assert.AreEqual("Queen", queen.Name);

        }
    }
}
