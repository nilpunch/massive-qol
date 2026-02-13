namespace Massive.QoL
{
#if UNITY_EDITOR
	public class StaticWorldSelectorAttribute : UnityEngine.PropertyAttribute
	{
	}
#else
	[System.AttributeUsage(System.AttributeTargets.Field)]
	public class StaticWorldSelectorAttribute : System.Attribute
	{
	}
#endif
}
