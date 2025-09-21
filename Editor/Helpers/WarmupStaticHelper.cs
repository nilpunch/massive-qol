#if UNITY_EDITOR
using UnityEditor;

namespace Massive.QoL.Editor
{
	[InitializeOnLoad]
	internal static class WarmupStaticHelper
	{
		static WarmupStaticHelper()
		{
			StaticWorlds.WarmupAll();
		}
	}
}
#endif
