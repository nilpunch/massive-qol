#if UNITY_EDITOR
using UnityEngine;

namespace Massive.QoL
{
	internal static class StaticWorldsWarmupHelper
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void WarmupStaticWorlds()
		{
			StaticWorlds.WarmupAll();
		}
	}
}
#endif
