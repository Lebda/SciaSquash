using System;
using System.Linq;
using Ninject;
using SciaSquash.Model.Abstract;
using SciaSquash.Model.Concrete;

namespace SciaSquash.Model.Infrastructure
{
    public static class ModuleRegistrator
    {
        public static void AddBindings(IKernel ninjectKernel)
        {
            ninjectKernel.Bind(typeof(IResolver<>)).To(typeof(Resolver<>));
            ninjectKernel.Bind<IScore4Rival>().To<Score4Rival>();
            ninjectKernel.Bind<IMatchDayRepository>().To<MatchDayRepository>();
            ninjectKernel.Bind<IMatchRepository>().To<MatchRepository>();
            ninjectKernel.Bind<IPlayerReposiroty>().To<PlayerReposiroty>();
            ninjectKernel.Bind<IPlayerResult>().To<PlayerResult>();
            ninjectKernel.Bind<IResultsCalculator>().To<ResultsCalculator>();
        }
    }
}
