using Game.Shared.EventBus;
using Game.Shared.EventBus.Signals.Score;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.View.Score
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class ScoreCounterUI : MonoBehaviour
	{
		private EventBus _eventBus;
		private TextMeshProUGUI _textfield;

		private void OnDestroy()
		{
			_eventBus.Unsubscribe<ScoreChangedSignal>(Render);
		}

		[Inject]
		private void Construct(EventBus eventBus)
		{
			_eventBus = eventBus;
			TryGetComponent(out _textfield);
			_eventBus.Subscribe<ScoreChangedSignal>(Render);
		}

		private void Render(ScoreChangedSignal signal)
		{
			_textfield.text = signal.Score.ToString();
		}
	}
}