using Fusion;
using UnityEngine;

namespace Game.Domain.Movement
{
	public interface IMovementInput
	{
		public Vector2 Direction { get; set; }
		public NetworkButtons Buttons { get; set; }
	}
}