using System;
using Game.Shared.EventBus;
using Game.Shared.EventBus.Signals.Score;
using Zenject;

namespace Game.Domain.Score
{
	public class ScoreCounter : IDisposable
	{
		private readonly EventBus _eventBus;

		private readonly int _incrementValue = 1;
		private readonly int _decrementValue = 1;
		private int _score;

		[Inject]
		public ScoreCounter(EventBus eventBus)
		{
			_eventBus = eventBus;
			_eventBus.Subscribe<IncrementScoreSignal>(Increment);
			_eventBus.Subscribe<DecrementScoreSignal>(Decrement);
		}

		public void Dispose()
		{
			_eventBus.Unsubscribe<IncrementScoreSignal>(Increment);
			_eventBus.Unsubscribe<DecrementScoreSignal>(Decrement);
		}


		public void Increment()
		{
			_score += _incrementValue;
			_eventBus.Invoke(new ScoreChangedSignal(_score));
		}

		public void Decrement()
		{
			if (_score - _decrementValue < 0)
				return;

			_score -= _decrementValue;
			_eventBus.Invoke(new ScoreChangedSignal(_score));
		}

		private void Decrement(DecrementScoreSignal obj)
		{
			Decrement();
		}

		private void Increment(IncrementScoreSignal signal)
		{
			Increment();
		}
	}
}