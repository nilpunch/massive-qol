namespace Massive.QoL.Samples
{
	public class HealingBuffSystem : SystemBase, IUpdate
	{
		public void Update(float deltaTime)
		{
			World.Include<HealingBuff>().ForEach((ref Health health) =>
			{
				health.Value += 1;
			});
		}
	}
}
