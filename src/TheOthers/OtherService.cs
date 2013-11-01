using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TheOthers
{
	/// <summary>
	/// The Other domain service.
	/// </summary>
	public static class OtherService
	{
		#region Fields
		private static IList<IOther> s_othersCache;
		#endregion

		/// <summary>
		/// Gets all others.
		/// </summary>
		/// <returns>The all others.</returns>
		public static IList<IOther> GetAllOthers ()
		{
			if (s_othersCache == null) {
				var result = new List<IOther> ();
				var interfaceType = typeof(IOther);

				var canditateAssemblies = AppDomain.CurrentDomain.GetAssemblies ();
				var types = new List<Type> ();

				foreach (var a in canditateAssemblies) {
					try{
						types.AddRange(a.GetTypes());
					}
					catch(ReflectionTypeLoadException) {
						continue;
					}
				}

				var externalInterfaceTypes = types.Where (t => interfaceType.IsAssignableFrom (t) && !t.IsInterface && !t.IsAbstract);

				foreach (var type in externalInterfaceTypes) {
					try 
					{
						var externalInterface = Activator.CreateInstance (type) as IOther;
						result.Add (externalInterface);
					}
					catch(MissingMethodException)
					{
						continue;
					}
				}

				s_othersCache = result.OrderBy (r => r.Name).ToList ();
			}

			return s_othersCache;
		}

		/// <summary>
		/// Checks all others status.
		/// </summary>
		/// <returns>The all others with checked status.</returns>
		public static IList<IOther> CheckAllOthersStatus()
		{
			foreach (var other in GetAllOthers()) {
				other.CheckStatus ();
			}

			return s_othersCache;
		}
	}
}