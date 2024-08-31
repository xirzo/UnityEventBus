using UnityEngine;

namespace Game.Domain.Movement
{
	public interface IMovement
	{
		float Speed { get; }
		Vector3 Direction { get; }
		Vector3 Velocity { get; }
		Vector3 Position { get; }
		bool IsMoving();
	}
}