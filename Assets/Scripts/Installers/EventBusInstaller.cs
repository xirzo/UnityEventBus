using Game.Shared.EventBus;
using Zenject;

namespace Game.Installers
{
	public class EventBusInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<EventBus>().AsSingle();
		}
	}
}