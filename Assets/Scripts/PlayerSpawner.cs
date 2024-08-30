using System;
using System.Collections.Generic;
using Fusion;
using Fusion.Sockets;
using UnityEngine;

namespace Game
{
	public class PlayerSpawner : MonoBehaviour, INetworkRunnerCallbacks
	{
		[SerializeField] private NetworkPrefabRef _playerPrefab;
		[SerializeField] private Transform _playerParent;

		private readonly Dictionary<PlayerRef, NetworkObject> _spawnedCharacters = new();


		public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
		{
		}

		public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
		{
		}

		public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
		{
			if (!runner.IsServer) return;

			var spawnPosition = new Vector3(player.RawEncoded % runner.Config.Simulation.PlayerCount * 3, 1, 0);
			var networkPlayerObject =
				runner.Spawn(_playerPrefab, spawnPosition, Quaternion.identity, player);
			networkPlayerObject.gameObject.transform.SetParent(_playerParent);
			_spawnedCharacters.Add(player, networkPlayerObject);
		}

		public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
		{
			if (!_spawnedCharacters.TryGetValue(player, out var networkObject)) return;

			runner.Despawn(networkObject);
			_spawnedCharacters.Remove(player);
		}

		public void OnInput(NetworkRunner runner, NetworkInput input)
		{
		}

		public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
		{
		}

		public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
		{
		}

		public void OnConnectedToServer(NetworkRunner runner)
		{
		}

		public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
		{
		}

		public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request,
			byte[] token)
		{
		}

		public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
		{
		}

		public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
		{
		}

		public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
		{
		}

		public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
		{
		}

		public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
		{
		}

		public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key,
			ArraySegment<byte> data)
		{
		}

		public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
		{
		}

		public void OnSceneLoadDone(NetworkRunner runner)
		{
		}

		public void OnSceneLoadStart(NetworkRunner runner)
		{
		}
	}
}