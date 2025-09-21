namespace Massive.QoL.Samples
{
	public class DeathSystem : SystemBase, IUpdate
	{
		public void Update()
		{
			World.ForEach((Entity entity, ref Health health) =>
			{
				if (health.Value <= 0)
				{
					entity.Destroy();
				}
			});
		}
	}
}
