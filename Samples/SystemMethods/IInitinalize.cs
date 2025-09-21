namespace Massive.QoL.Samples
{
	public interface IInitinalize : IRunMethod<IInitinalize>
	{
		void Initialize();

		void IRunMethod<IInitinalize>.Run() => Initialize();
	}
}
