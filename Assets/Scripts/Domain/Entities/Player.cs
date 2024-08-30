using Fusion;
using UnityEngine;

namespace Game.Domain.Entities
{
	public class Player : NetworkBehaviour
	{
		// private readonly IMovement _movement;
		private readonly float _speed = 10f;
		private GameplayInput _input;

		public override void FixedUpdateNetwork()
		{
			_input = GetInput<GameplayInput>().GetValueOrDefault();

			Move();
		}

		private void Move()
		{
			var direction = _input.Direction * _speed * Time.deltaTime;
			transform.Translate(direction);
		}
	}
}