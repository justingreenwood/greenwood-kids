using System;
using System.Collections.Generic;
using System.Text;

namespace Stopwatch.Model
{
    public class StopwatchModel
    {
        private bool _paused;
        private DateTime _pausedAt;
        private TimeSpan _totalPausedTime;

        public TimeSpan LapTime { get; private set; }
        public void SetLapTime() => LapTime = Elapsed;

        private DateTime _startedTime;

        public StopwatchModel() => Reset();

        public bool Running
        {
            get => (_startedTime != DateTime.MinValue) && !_paused;
            set
            {
                if(value)
                {
                    _paused = false;
                    if (_pausedAt != DateTime.MinValue)
                    {
                        _totalPausedTime += DateTime.Now - _pausedAt;
                    }
                    if (_startedTime == DateTime.MinValue)
                    {
                        _startedTime = DateTime.Now;
                    }
                }
                else
                {
                    _paused = true;
                    _pausedAt = DateTime.Now;
                }
            }
        }

        public TimeSpan Elapsed => _paused ? _pausedAt - _startedTime - _totalPausedTime
            : _startedTime != DateTime.MinValue ? DateTime.Now - _startedTime - _totalPausedTime : TimeSpan.Zero;

        public void Reset()
        {
            _startedTime = DateTime.MinValue;
            _paused = false;
            _pausedAt = DateTime.MinValue;
            _totalPausedTime = TimeSpan.Zero;
            LapTime = TimeSpan.Zero;
        }
    }
}
