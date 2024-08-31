using Fusion;
using Game.Domain;
using UnityEngine;

namespace Game
{
	public class PlayerInput : NetworkBehaviour, IBeforeTick, IAfterTick
	{
		private GameplayInput _gameplayInput;

		public Vector2 Direction => _gameplayInput.Direction;

		[Networked] public NetworkButtons ButtonsPrevious { get; private set; }

		public void AfterTick()
		{
			ButtonsPrevious = GetInput<GameplayInput>().GetValueOrDefault().Buttons;
		}

		public void BeforeTick()
		{
			if (HasInputAuthority == false)
				return;

			var moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
			_gameplayInput.Direction = moveDirection.normalized;

			_gameplayInput.Buttons.Set(InputButton.Fire, Input.GetButton("Fire1"));
		}


		public override void Spawned()
		{
			if (HasInputAuthority == false)
				return;

			var networkEvents = Runner.GetComponent<NetworkEvents>();
			networkEvents.OnInput.AddListener(OnInput);
		}

		public override void Despawned(NetworkRunner runner, bool hasState)
		{
			if (runner == null)
				return;

			var networkEvents = runner.GetComponent<NetworkEvents>();

			if (networkEvents != null)
				networkEvents.OnInput.RemoveListener(OnInput);
		}

		private void OnInput(NetworkRunner runner, NetworkInput networkInput)
		{
			networkInput.Set(_gameplayInput);
		}
	}
}