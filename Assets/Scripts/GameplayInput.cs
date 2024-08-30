using Fusion;
using UnityEngine;

namespace Game
{
	public struct GameplayInput : INetworkInput
	{
		public Vector2 Direction { get; set; }
		public NetworkButtons Buttons { get; }
	}
}