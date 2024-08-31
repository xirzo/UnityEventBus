using System;
using UnityEngine;

namespace Game.Domain.Inputs
{
	[Serializable]
	public class MoveMap
	{
		[SerializeField] private KeyCode _upKey;
		[SerializeField] private KeyCode _downKey;
		[SerializeField] private KeyCode _rightKey;
		[SerializeField] private KeyCode _leftKey;

		public KeyCode UpKey => _upKey;
		public KeyCode DownKey => _downKey;
		public KeyCode RightKey => _rightKey;
		public KeyCode LeftKey => _leftKey;
	}
}