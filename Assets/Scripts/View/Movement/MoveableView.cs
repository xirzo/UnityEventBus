using Game.Domain.Movement;
using UnityEngine;
using Zenject;

namespace Game.View.Movement
{
	public class MoveableView : MonoBehaviour
	{
		private IMovement _movement;

		private void Update()
		{
			if (_movement == null)
				return;

			transform.position = _movement.Position;
		}

		[Inject]
		private void Construct(IMovement movement)
		{
			_movement = movement;
		}
	}
}