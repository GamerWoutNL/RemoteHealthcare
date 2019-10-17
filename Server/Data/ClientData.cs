﻿using Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
	public class ClientData
	{
		private List<TimeData> _elapsedTime;
		private List<TimeData> _distanceTravelled;
		private List<TimeData> _speed;
		private List<TimeData> _heartRate;
		private List<TimeData> _eventCount;
		private List<TimeData> _instanteousCadance;
		private List<TimeData> _accumulatedPower;
		private List<TimeData> _instanteousPower;

		public ClientData()
		{
			this._elapsedTime = new List<TimeData>();
			this._distanceTravelled = new List<TimeData>();
			this._speed = new List<TimeData>();
			this._heartRate = new List<TimeData>();
			this._eventCount = new List<TimeData>();
			this._instanteousCadance = new List<TimeData>();
			this._accumulatedPower = new List<TimeData>();
			this._instanteousPower = new List<TimeData>();
		}

        public override string ToString()
        {
			return $"<ET>{_elapsedTime.Last()}<DT>{_distanceTravelled.Last()}<SP>{_speed.Last()}<HR>{_heartRate.Last()}<EC>{_eventCount.Last()}<IC>{_instanteousCadance.Last()}<AC>{_accumulatedPower.Last()}<IP>{_instanteousPower.Last()}<TS>{_elapsedTime.Last()}<EOF>"; ;
        }

		public void AddET(string et, string datetime)
		{
			this._elapsedTime.Add(new TimeData(et, datetime));
		}

		public void AddDT(string dt, string datetime)
		{
			this._distanceTravelled.Add(new TimeData(dt, datetime));
		}

		public void AddSP(string sp, string datetime)
		{
			this._speed.Add(new TimeData(sp, datetime));
		}

		public void AddHR(string hr, string datetime)
		{
			this._heartRate.Add(new TimeData(hr, datetime));
		}

		public void AddEC(string ec, string datetime)
		{
			this._eventCount.Add(new TimeData(ec, datetime));
		}

		public void AddIC(string ic, string datetime)
		{
			this._instanteousCadance.Add(new TimeData(ic, datetime));
		}

		public void AddAP(string ap, string datetime)
		{
			this._accumulatedPower.Add(new TimeData(ap, datetime));
		}

		public void AddIP(string ip, string datetime)
		{
			this._instanteousPower.Add(new TimeData(ip, datetime));
		}
	}
}