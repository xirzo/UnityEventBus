using Fusion;

namespace Game
{
	public class Player : NetworkBehaviour
	{
		private GameplayInput _input;
		private PlayerMovement _movement;

		private void Construct(PlayerMovement movement)
		{
			_movement = movement;
		}


		public override void FixedUpdateNetwork()
		{
			_input = GetInput<GameplayInput>().GetValueOrDefault();

			_movement?.Move(_input.Direction);
		}
	}
}