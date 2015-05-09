using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using SciaSquash.Model.Infrastructure;

namespace SciaSquash.Web.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel m_ninjectKernel;
        public NinjectControllerFactory()
        {
            m_ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                   ? null
                   : (IController)m_ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            ModuleRegistrator.AddBindings(m_ninjectKernel);
        }
    }
}