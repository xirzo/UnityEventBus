using Game.Domain.Movement;
using UnityEngine;

namespace Game.Domain.Inputs
{
	public class PlayerInput : IMovementInput
	{
		public Vector2 GetMovement()
		{
			return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		}
	}
}