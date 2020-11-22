using ArabaSatisOtomasyon.Controllers;
using ArabaSatisOtomasyon.Data;
using Ninject;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace ArabaSatisOtomasyon.NinjectController
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();

            AllBindings();
        }

        private void AllBindings()
        {
            ninjectKernel.Bind<ApplicationDbContext>().ToSelf();
            
            //ninjectKernel.Bind<ApplicationUserManager>().To<KullaniciController>().WithConstructorArgument("userManager", new ApplicationUserManager());
            //ninjectKernel.Bind<IKullaniciService>().To<KullaniciManager>().WithConstructorArgument("kullaniciDal", new EFKullaniciRepository());
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
    }
}