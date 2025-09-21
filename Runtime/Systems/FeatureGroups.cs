using System;
using System.Collections.Generic;

namespace Massive.QoL
{
	public class FeatureGroups
	{
		private readonly Dictionary<Type, FastList<Feature>> _groupedFeatures = new Dictionary<Type, FastList<Feature>>();

		public void AddFeature<TGroup>(Feature feature)
		{
			if (!_groupedFeatures.TryGetValue(typeof(TGroup), out var featureList))
			{
				featureList = new FastList<Feature>();
				_groupedFeatures[typeof(TGroup)] = featureList;
			}

			featureList.Add(feature);
		}

		public void Run<TGroup, TRunMethod>() where TRunMethod : IRunMethod<TRunMethod>
		{
			if (_groupedFeatures.TryGetValue(typeof(TGroup), out var featureList))
			{
				foreach (var feature in featureList)
				{
					feature.Run<TRunMethod>();
				}
			}
		}
	}
}
