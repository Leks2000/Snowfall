using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snowfall
{
    public partial class Snowfall : Form
    {
        private const int SnowflakeCount = 10;
        private Timer timer;
        private SnowFlake[] snowflakes;
        private Image backGroundImage = Properties.Resources.background_with_snow;
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
            g.DrawImage(backGroundImage, 0, 0);

            foreach (var snowflake in snowflakes)
            {
                g.DrawImage(snowflakeImage, snowflake.X, snowflake.Y, SnowFlake.ShowWidth, SnowFlake.ShowHeight);
            }
        }
    }
}
