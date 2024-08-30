using Fusion;
using Game.Domain.Movement;
using UnityEngine;
using Zenject;

namespace Game.View.Movement
{
	[RequireComponent(typeof(NetworkTransform))]
	public class MoveableView : NetworkBehaviour
	{
		private IMovement _movement;

		private void Awake()
		{
			Debug.Log("Started {0}", this);
		}

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