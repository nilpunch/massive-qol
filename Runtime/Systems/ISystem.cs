namespace Massive.QoL
{
	public interface ISystem
	{
		World World { get; set; }

		int Order => 0;
	}
}
