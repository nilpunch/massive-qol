﻿namespace Massive.QoL.Samples
{
	public interface IUpdate : ISystemMethod<IUpdate, float>
	{
		void Update(float deltaTime);

		void ISystemMethod<IUpdate, float>.Run(float deltaTime) => Update(deltaTime);
	}
}
