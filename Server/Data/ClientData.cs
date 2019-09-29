using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
	public class ClientData
	{
		private List<String> _elapsedTime;
		private List<String> _distanceTravelled;
		private List<String> _speed;
		private List<String> _heartRate;
		private List<String> _eventCount;
		private List<String> _instanteousCadance;
		private List<String> _accumulatedPower;
		private List<String> _instanteousPower;
        private List<String> _timeStamp;

		public ClientData()
		{
			this._elapsedTime = new List<String>();
			this._distanceTravelled = new List<String>();
			this._speed = new List<String>();
			this._heartRate = new List<String>();
			this._eventCount = new List<String>();
			this._instanteousCadance = new List<String>();
			this._accumulatedPower = new List<String>();
			this._instanteousPower = new List<String>();
            this._timeStamp = new List<String>();
		}

        public override string ToString()
        {
            string sizes = $"Elapsed Time: {_elapsedTime.Count()} \nDistance Travelled: {_distanceTravelled.Count()} \nSpeed: {_speed.Count()} \nHeartrate: {_heartRate.Count()} \nEvent count: {_eventCount.Count()} \nInstanteous cadence: {_instanteousCadance.Count()} \nAccumulated power: {_accumulatedPower.Count()} \nInstanteous power: {_instanteousPower.Count()} \nTimestamp: {_timeStamp.Count()}";
            return sizes;
        }

		public void AddET(string et)
		{
			this._elapsedTime.Add(et);
		}

		public void AddDT(string dt)
		{
			this._distanceTravelled.Add(dt);
		}

		public void AddSP(string sp)
		{
			this._speed.Add(sp);
		}

		public void AddHR(string hr)
		{
			this._heartRate.Add(hr);
		}

		public void AddEC(string ec)
		{
			this._eventCount.Add(ec);
		}

		public void AddIC(string ic)
		{
			this._instanteousCadance.Add(ic);
		}

		public void AddAP(string ap)
		{
			this._accumulatedPower.Add(ap);
		}

		public void AddIP(string ip)
		{
			this._instanteousPower.Add(ip);
		}

        public void AddTS(string ts)
        {
            this._timeStamp.Add(ts);
        }
	}
}
