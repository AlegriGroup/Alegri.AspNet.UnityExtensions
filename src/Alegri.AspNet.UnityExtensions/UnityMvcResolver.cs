using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace Alegri.AspNet.UnityExtensions
{
    public class UnityMvcResolver : IDependencyResolver
    {
        private readonly IUnityContainer _container;

        private readonly IDependencyResolver _resolver;

        public UnityMvcResolver(IUnityContainer container, IDependencyResolver resolver)
        {
            this._container = container;
            this._resolver = resolver;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this._container.Resolve(serviceType);
            }
            catch
            {
                return this._resolver.GetService(serviceType);
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this._container.ResolveAll(serviceType);
            }
            catch
            {
                return this._resolver.GetServices(serviceType);
            }
        }
    }
}