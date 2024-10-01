using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snowfall
{
    public partial class Snowfall : Form
    {
        private const int SnowflakeCount = 100;
        private Timer timer;
        private SnowFlake[] snowflakes;
        private Image snowflakeImage = Properties.Resources.snowflake;

        public Snowfall()
        {
            InitializeComponent();
            InitializeSnowfall();
        }

        private void InitializeSnowfall()
        {
            DoubleBuffered = true;
            snowflakes = new SnowFlake[SnowflakeCount];

            for (var i = 0; i < SnowflakeCount; i++)
            {
                snowflakes[i] = new SnowFlake(Width, Height);
            }

            timer = new Timer { Interval = 16 };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var snowflake in snowflakes)
            {
                snowflake.Fall(Width, Height);
            }
            Invalidate();
        }

        /// <summary>
        /// Отрисовка фона и снежинок
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            foreach (var snowflake in snowflakes)
            {
                g.DrawImage(snowflakeImage, snowflake.X, snowflake.Y, SnowFlake.ShowWidth, SnowFlake.ShowHeight);
            }
        }
    }
}
