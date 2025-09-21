using NotImplementedException = System.NotImplementedException;

namespace Massive.QoL.Samples
{
	public class SpawnSystem : System, IFirstTick
	{
		private readonly int _spawnAmount;

		public SpawnSystem(int spawnAmount)
		{
			_spawnAmount = spawnAmount;
		}

		public void FirstTick()
		{
			for (var i = 0; i < _spawnAmount; i++)
			{
				var entity = World.CreateEntity<Health>();

				if (i % 2 == 0)
				{
					entity.Add<HealingBuff>();
				}
			}
		}
	}
}
