using System;
using System.Runtime.CompilerServices;

namespace Massive.QoL
{
	[Serializable, Component]
	public struct ViewAsset : IEquatable<ViewAsset>
	{
		public int IdMinusOne;

		/// <summary>
		/// Negative view ID is invalid.
		/// </summary>
		public int Id
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => IdMinusOne + 1;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => IdMinusOne = value - 1;
		}

		public ViewAsset(int id)
		{
			IdMinusOne = id - 1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ViewAsset other)
		{
			return IdMinusOne == other.IdMinusOne;
		}

		public override bool Equals(object obj)
		{
			return obj is ViewAsset other && Equals(other);
		}

		public override int GetHashCode()
		{
			return IdMinusOne;
		}
	}
}
