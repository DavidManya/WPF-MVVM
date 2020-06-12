using Common.Lib.Infrastructure;
using Common.Lib.Infrastructure.Interfaces;
using System;
using AcademyMVVM.DbContextFactory;
using AcademyMVVM.Lib.DAL;
using Common.Lib.Core;
using AcademyMVVM.Lib.Models;
using Common.Lib.Core.Context.Interfaces;

namespace AcademyMVVM.App
{
    public class Bootstrapper
    {
        public IDependencyContainer Init()
        {
            var depCon = new SimpleDependencyContainer();

            RegisterRepositories(depCon);

            Entity.DepCon = depCon;

            return depCon;
        }

        public void RegisterRepositories(IDependencyContainer depCon)
        {
            var subjectsRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new GenericRepository<Subjects>(GetDbConstructor());
            });

            var examsRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new GenericRepository<Exams>(GetDbConstructor());
            });

            var studentsRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new GenericRepository<Students>(GetDbConstructor());
            });


            var coursesRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new GenericRepository<Courses>(GetDbConstructor());
            });

            depCon.Register<IRepository<Students>, GenericRepository<Students>>(studentsRepoBuilder);
            depCon.Register<IRepository<Subjects>, GenericRepository<Subjects>>(subjectsRepoBuilder);
            depCon.Register<IRepository<Exams>, GenericRepository<Exams>>(examsRepoBuilder);
            depCon.Register<IRepository<Courses>, GenericRepository<Courses>>(coursesRepoBuilder);
        }

        private static ProjectDBContext GetDbConstructor()
        {
            var factory = new AcademyContextFactory();
            return factory.CreateDbContext(null);
        }
    }
}
