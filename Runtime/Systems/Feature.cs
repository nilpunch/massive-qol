using System;
using System.Collections.Generic;

namespace Massive.QoL
{
	public class Feature
	{
		private readonly FastList<ISystem> _systems = new FastList<ISystem>();
		private readonly Dictionary<Type, object> _runMedthodsLists = new Dictionary<Type, object>();

		public World World { get; }

		public Feature(World world)
		{
			World = world;
		}

		public void AddSystem(ISystem system)
		{
			system.World = World;

			_systems.Add(system);
		}

		public void Run<TRunMethod>() where TRunMethod : IRunMethod<TRunMethod>
		{
			var type = typeof(TRunMethod);
			List<TRunMethod> runMethods;

			if (_runMedthodsLists.TryGetValue(type, out var runMethodsList))
			{
				runMethods = (List<TRunMethod>)runMethodsList;
			}
			else
			{
				runMethods = new List<TRunMethod>();
				foreach (var system in _systems)
				{
					if (system is TRunMethod runMethod)
					{
						runMethods.Add(runMethod);
					}
				}
				_runMedthodsLists[type] = runMethods;
			}

			foreach (var runMethod in runMethods)
			{
				runMethod.Run();
			}
		}
	}
}
