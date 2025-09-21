namespace Massive.QoL.Samples
{
	public interface IUpdate : IRunMethod<IUpdate>
	{
		void Update();

		void IRunMethod<IUpdate>.Run() => Update();
	}
}
