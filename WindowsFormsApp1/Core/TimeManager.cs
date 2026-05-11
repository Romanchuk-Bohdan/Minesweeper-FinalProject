using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Core
{
    // Техніка: Extract Class
    // Принцип: Single Responsibility Principle (Клас відповідає лише за час)
    public class TimeManager
    {
        private Timer _timer;
        private Label _timerLabel;

        public int ElapsedSeconds { get; private set; }

        public TimeManager(Label timerLabel)
        {
            _timerLabel = timerLabel;
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public void Reset(int startingSeconds = 0)
        {
            Stop();
            ElapsedSeconds = startingSeconds;
            UpdateLabel();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ElapsedSeconds++;
            UpdateLabel();
        }

        private void UpdateLabel()
        {
            _timerLabel.Text = $"Час: {ElapsedSeconds} с";
        }
    }
}