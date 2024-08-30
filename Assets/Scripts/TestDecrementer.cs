using Game.Domain.Score;
using UnityEngine;
using Zenject;

namespace Game
{
	public class TestDecrementer : MonoBehaviour
	{
		private ScoreCounter _scoreCounter;

		private void Update()
		{
			if (_scoreCounter != null)

				_scoreCounter.Increment();
		}

		[Inject]
		private void Construct(ScoreCounter scoreCounter)
		{
			_scoreCounter = scoreCounter;
		}
	}
}