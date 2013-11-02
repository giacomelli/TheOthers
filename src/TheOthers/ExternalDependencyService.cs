using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HelperSharp;

namespace TheOthers
{
    /// <summary>
    /// The external dependency domain service.
    /// </summary>
    public static class ExternalDependencyService
    {
        #region Fields
        private static IList<IExternalDependency> s_othersCache;
        #endregion

        /// <summary>
        /// Gets all external dependencies.
        /// </summary>
        /// <returns>The all others.</returns>
        public static IList<IExternalDependency> GetAllExternalDepencies()
        {
            if (s_othersCache == null)
            {
                var result = new List<IExternalDependency>();
                var interfaceType = typeof(IExternalDependency);

                var canditateAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                var types = new List<Type>();

                foreach (var a in canditateAssemblies)
                {
                    try
                    {
                        types.AddRange(a.GetTypes());
                    }
                    catch (ReflectionTypeLoadException)
                    {
                        continue;
                    }
                }

                var externalInterfaceTypes = types.Where(t => interfaceType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

                foreach (var type in externalInterfaceTypes)
                {
                    try
                    {
                        var externalInterface = Activator.CreateInstance(type) as IExternalDependency;
                        result.Add(externalInterface);
                    }
                    catch (MissingMethodException)
                    {
                        continue;
                    }
                    catch (TargetInvocationException ex)
                    {
                        throw new InvalidOperationException("An error occurred while trying to create an instance of this external dependency type:  {0}. {1}".With(type.Name, ex.Message), ex);
                    }
                }

                s_othersCache = result.OrderBy(r => r.Name).ToList();
            }

            return s_othersCache;
        }

        /// <summary>
        /// Checks all external dependencies status.
        /// </summary>
        /// <returns>The all external dependencies with checked status.</returns>
        public static IList<IExternalDependency> CheckAllExternalDependenciesStatus()
        {
            foreach (var other in GetAllExternalDepencies())
            {
                other.CheckStatus();
            }

            return s_othersCache;
        }
    }
}