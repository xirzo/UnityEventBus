using System.Collections.Generic;
using Fusion;
using Game.Domain.Entities;
using UnityEngine;

namespace Game
{
	public class PlayerSpawner : NetworkBehaviour, IPlayerJoined, IPlayerLeft
	{
		[SerializeField] private NetworkPrefabRef _playerPrefab;
		[SerializeField] private Transform _playerParent;

		private readonly Dictionary<PlayerRef, NetworkObject> _spawnedCharacters = new();
		public Player LocalPlayer { get; private set; }

		public void PlayerJoined(PlayerRef player)
		{
			if (Runner.IsServer == false) return;

			var spawnPosition = new Vector3(player.RawEncoded % Runner.Config.Simulation.PlayerCount * 3, 1, 0);
			var networkPlayerObject =
				Runner.Spawn(_playerPrefab, spawnPosition, Quaternion.identity, player);
			networkPlayerObject.gameObject.transform.SetParent(_playerParent);
			_spawnedCharacters.Add(player, networkPlayerObject);
		}

		public void PlayerLeft(PlayerRef player)
		{
			if (!_spawnedCharacters.TryGetValue(player, out var networkObject)) return;

			Runner.Despawn(networkObject);
			_spawnedCharacters.Remove(player);
		}

		public override void Render()
		{
			if (LocalPlayer != null) return;

			var playerObject = Runner.GetPlayerObject(Runner.LocalPlayer);
			LocalPlayer = playerObject != null ? playerObject.GetComponent<Player>() : null;
		}

		public override void Despawned(NetworkRunner runner, bool hasState)
		{
			LocalPlayer = null;
		}
	}
}