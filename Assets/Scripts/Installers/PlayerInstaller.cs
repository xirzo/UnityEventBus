using Game.Domain.Entities;
using Game.Domain.Inputs;
using Game.Domain.Movement;
using Game.View.Movement;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
	public class PlayerInstaller : MonoInstaller
	{
		[SerializeField] private MoveMap _moveMap;

		public override void InstallBindings()
		{
			Container.Bind<IEntity>().To<Player>().AsSingle();
			Container.Bind<MoveMap>().FromInstance(_moveMap).AsSingle();
			Container.Bind<IMovementInput>().To<PlayerInput>().AsSingle();
			Container.BindInterfacesAndSelfTo<PlayerMovement>().AsSingle();
			Container.Bind<MoveableView>().FromComponentsInHierarchy().AsSingle();
		}
	}
}