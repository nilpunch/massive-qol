using System;

namespace Massive.QoL
{
	[AttributeUsage(AttributeTargets.Struct)]
	public class StaticWorldTypeAttribute : Attribute
	{
		public readonly int PageSize;

		public readonly bool StoreEmptyTypesAsDataSets;

		public StaticWorldTypeAttribute(int pageSize = Constants.PageSize, bool storeEmptyTypesAsDataSets = false)
		{
			PageSize = pageSize;
			StoreEmptyTypesAsDataSets = storeEmptyTypesAsDataSets;
		}
	}
}
