using Game.Domain.Movement;
using Zenject;

namespace Game.Domain.Entities
{
	public class Player : IEntity
	{
		private readonly IMovement _movement;

		[Inject]
		public Player(IMovement movement, string name)
		{
			_movement = movement;
			Name = name;
		}

		public string Name { get; }
	}
}