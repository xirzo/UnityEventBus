using UnityEngine;

namespace Game.Domain.Movement
{
	public interface IMovementInput
	{
		public Vector2 GetMovement();
	}
}