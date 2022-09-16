using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Stopwatch.ViewModel;
namespace Stopwatch.View
{
    class StopwatchView
    {

        private StopwatchViewModel _viewModel = new StopwatchViewModel();
        private bool _quit = false;

        public StopwatchView()
        {
            ClearScreenAndAddHelpMessage();
            TimerCallback timerCallback = UpdateTimeCallback;
            var _timer = new Timer(timerCallback, null, 0, 10);
            while (!_quit)
            {
                Thread.Sleep(100);
            }
            Console.CursorVisible = true;

        }

        private void WriteCurrentTime()
        {

            Console.CursorTop = 1;
            Console.CursorLeft = 23;
            var time= $"{_viewModel.Hours}:{_viewModel.Minutes}:{_viewModel.Seconds}.{_viewModel.Tenths}";
            var lapTime = $"{_viewModel.LapHours}:{_viewModel.LapMinutes}:{_viewModel.LapSeconds}.{_viewModel.LapTenths}";

            Console.Write($"{time} - lap time {lapTime}");

        }

        private static void ClearScreenAndAddHelpMessage()
        {
            Console.Clear();
            Console.CursorTop = 3;
            Console.WriteLine("Space to start or stop, R to reset, L for lap time, and any other key to quit.");
            Console.CursorVisible = false;
        }

        private void UpdateTimeCallback(object? state)
        {

            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).KeyChar.ToString().ToUpper())
                {
                    case " ":
                        _viewModel.StartStop();
                        break;
                    case "R":

                        _viewModel.Reset();
                        break;
                    case "L":

                        _viewModel.LapTime();
                        break;
                    default:

                        Console.CursorVisible = true;
                        Console.CursorTop = 0;
                        Console.CursorLeft = 5;
                        _quit = true;
                        break;
                }
            }
            WriteCurrentTime();
        }

    }
}
