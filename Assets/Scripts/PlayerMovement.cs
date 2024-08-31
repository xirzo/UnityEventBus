using UnityEngine;

namespace Game
{
	public class PlayerMovement
	{
		public PlayerMovement(Vector3 position)
		{
			Position = position;
		}

		public float Speed { get; } = 5f;
		public Vector3 Direction { get; private set; }
		public Vector3 Velocity { get; private set; }
		public Vector3 Position { get; private set; }

		public bool IsMoving()
		{
			return Velocity.magnitude >= 0.01f;
		}

		public void Move(Vector3 direction)
		{
			Direction = direction.normalized;
			Velocity = Direction * (Speed * Time.deltaTime);
			Position += Velocity;
		}
	}
}