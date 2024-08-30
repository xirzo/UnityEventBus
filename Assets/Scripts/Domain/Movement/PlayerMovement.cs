using UnityEngine;
using Zenject;

namespace Game.Domain.Movement
{
	public class PlayerMovement : IMovement, ITickable
	{
		private readonly GameplayInput _input;

		public PlayerMovement(GameplayInput input, Vector3 initialPosition)
		{
			_input = input;
			Position = initialPosition;
		}

		public float Speed { get; } = 5f;
		public Vector3 Direction { get; private set; }
		public Vector3 Velocity { get; private set; }
		public Vector3 Position { get; private set; }

		public bool IsMoving()
		{
			return Velocity.magnitude >= 0.01f;
		}

		public void Tick()
		{
			Move();
		}

		private void Move()
		{
			Direction = _input.Direction.normalized;
			Velocity = Direction * (Speed * Time.deltaTime);
			Position += Velocity;
		}
	}
}