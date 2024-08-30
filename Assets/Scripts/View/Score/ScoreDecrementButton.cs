using Game.Shared.EventBus;
using Game.Shared.EventBus.Signals.Score;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.View.Score
{
	public class ScoreDecrementButton : MonoBehaviour
	{
		private Button _button;
		private EventBus _eventBus;

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(Increment);
		}

		[Inject]
		private void Construct(EventBus eventBus)
		{
			_eventBus = eventBus;
			TryGetComponent(out _button);
			_button.onClick.AddListener(Increment);
		}

		private void Increment()
		{
			_eventBus.Invoke(new DecrementScoreSignal());
		}
	}
}