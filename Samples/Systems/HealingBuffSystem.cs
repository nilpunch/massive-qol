namespace Massive.QoL.Samples
{
	public class HealingBuffSystem : System, IUpdate
	{
		public void Update()
		{
			World.Include<HealingBuff>().ForEach((ref Health health) =>
			{
				health.Value += 1;
			});
		}
	}
}
