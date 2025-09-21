namespace Massive.QoL.Samples
{
	public class DamageSystem : SystemBase, IUpdate, IInitinalize
	{
		private BitSet TakeDamageSelf;

		public void Initialize()
		{
			TakeDamageSelf = World.BitSet<TakeDamageSelf>();
		}

		public void Update()
		{
			World.ForEach(this, (int entityId, ref Health health, ref TakeDamageSelf damageSelf, DamageSystem system) =>
			{
				health.Value -= damageSelf.Value;
				system.TakeDamageSelf.Remove(entityId);
			});
		}
	}
}
