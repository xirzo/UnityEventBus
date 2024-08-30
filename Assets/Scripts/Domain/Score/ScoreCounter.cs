using Game.Shared.EventBus;
using Game.Shared.EventBus.Signals.Score;
using Zenject;

namespace Game.Domain.Score
{
	public class ScoreCounter
	{
		private readonly EventBus _eventBus;

		private readonly int _incrementValue = 1;
		private readonly int _decrementValue = 1;
		private int _score;

		[Inject]
		public ScoreCounter(EventBus eventBus)
		{
			_eventBus = eventBus;
		}

		public void Increment()
		{
			_score += _incrementValue;
			_eventBus.Invoke(new ScoreChangedSignal(_score));
		}

		public void Decrement()
		{
			if (_score - _decrementValue <= 0)
				return;

			_score -= _decrementValue;
			_eventBus.Invoke(new ScoreChangedSignal(_score));
		}
	}
}