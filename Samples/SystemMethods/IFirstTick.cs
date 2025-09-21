namespace Massive.QoL.Samples
{
	public interface IFirstTick : IRunMethod<IFirstTick>
	{
		void FirstTick();

		void IRunMethod<IFirstTick>.Run() => FirstTick();
	}
}
