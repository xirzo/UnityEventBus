using Game.Domain.Score;
using Zenject;

namespace Game.Installers
{
	public class ScoreInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<ScoreCounter>().AsSingle();
		}
	}
}