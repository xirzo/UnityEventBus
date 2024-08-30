namespace Game.Shared
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