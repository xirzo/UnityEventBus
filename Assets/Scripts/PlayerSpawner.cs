using System.Collections.Generic;
using Fusion;
using UnityEngine;

namespace Game
{
	public class PlayerSpawner : NetworkBehaviour, IPlayerJoined, IPlayerLeft
	{
		[SerializeField] private NetworkPrefabRef _playerPrefab;
		[SerializeField] private Transform _playerParent;

		private readonly Dictionary<PlayerRef, NetworkObject> _spawnedCharacters = new();

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
	}
}