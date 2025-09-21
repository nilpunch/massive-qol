using NotImplementedException = System.NotImplementedException;

namespace Massive.QoL.Samples
{
	public class Program
	{
		private readonly Feature _damageFeature;

		public Program()
		{
			_damageFeature = new FeatureFactory()
				.AddInstance(new SpawnSystem(spawnAmount: 20))
				.AddNew<DamageSystem>()
				.AddNew<HealingBuffSystem>()
				.AddNew<DeathSystem>()
				.CreateFeature(new World());

			_damageFeature.Run<IInitinalize>();
		}

		public void UpdateLoop(int tick)
		{
			if (tick == 0)
			{
				_damageFeature.Run<IFirstTick>();
			}

			_damageFeature.Run<IUpdate>();
		}
	}
}
