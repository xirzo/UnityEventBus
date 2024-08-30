namespace Game.Shared.EventBus.Signals.Score
{
	public class ScoreChangedSignal
	{
		public ScoreChangedSignal(int score)
		{
			Score = score;
		}

		public int Score { get; }
	}
}