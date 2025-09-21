using System;

namespace Massive.QoL
{
	public interface IRunMethod<T> : ISystem where T : IRunMethod<T>
	{
		void Run() => throw new NotImplementedException();
	}
}
