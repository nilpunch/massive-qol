namespace Massive.QoL.Samples
{
	public interface IInitinalize : ISystemMethod<IInitinalize>
	{
		void Initialize();

		void ISystemMethod<IInitinalize>.Run() => Initialize();
	}
}
