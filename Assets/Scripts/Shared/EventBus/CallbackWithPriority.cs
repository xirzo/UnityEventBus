namespace Game.Shared.EventBus
{
	public class CallbackWithPriority
	{
		public CallbackWithPriority(int priority, object callback)
		{
			Priority = priority;
			Callback = callback;
		}

		public int Priority { get; }
		public object Callback { get; }
	}
}