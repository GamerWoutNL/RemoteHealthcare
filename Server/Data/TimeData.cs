namespace Server.Data
{
	public class TimeData
	{
		public string time { get; }
		public string data { get; }

		public TimeData(string data, string time)
		{
			this.time = time;
			this.data = data;
		}

		public override string ToString()
		{
			return this.data;
		}
	}
}
