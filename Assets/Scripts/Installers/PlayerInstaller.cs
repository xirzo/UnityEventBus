using Game.Domain.Entities;
using Game.Domain.Inputs;
using Game.Domain.Movement;
using Game.View.Movement;
using Zenject;

namespace Game.Installers
{
	public class PlayerInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<IEntity>().To<Player>().AsSingle();
			var playerInput = new PlayerInput();
			Container.Bind<IMovementInput>().FromInstance(playerInput).AsSingle();
			Container.BindInterfacesAndSelfTo<PlayerMovement>().AsSingle();
			Container.Bind<MoveableView>().FromComponentsInHierarchy().AsSingle();
		}
	}
}