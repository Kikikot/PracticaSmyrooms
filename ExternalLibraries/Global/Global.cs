using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace ExternalLibraries.Global
{
    public static class Global
    {
        private static IServiceCollection _collection = new ServiceCollection();
        private static IServiceProvider _provider;
        private static Dictionary<string, string> _registeredInterfaces = new Dictionary<string, string>();

        public static void Reset()
        {
            _collection = new ServiceCollection();
            _provider = null;
            _registeredInterfaces = new Dictionary<string, string>();
        }

        public static void Register<I,C>()
            where I : class
            where C : class, I
        {
            if (_provider != null)
                throw new Exception("Global Depency Injection is ready. Imposible to register more interfaces.");

            string registeringInterface = typeof(I).FullName;

            if (!_registeredInterfaces.ContainsKey(registeringInterface))
            {
                _collection.AddScoped<I, C>();
                _registeredInterfaces.Add(registeringInterface, registeringInterface);
            }
        }

        public static void Prepare()
        {
            _provider = _collection.BuildServiceProvider();
        }

        public static I Resolve<I>()
            where I : class
        {
            if (_provider == null)
                throw new Exception("Global Depency Injection not ready. Imposible to resolve any interface.");

            return _provider.GetService<I>();
        }
    }
}
