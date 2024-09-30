using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowfall
{
    public class SnowFlake
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Speed { get; set; }

        public const int ShowWidth = 20, ShowHeight = 20;

        private static Random random = new Random();

        public SnowFlake(int formWidth, int formHeight)
        {
            X = random.Next(0, formWidth);
            Y = random.Next(-formHeight, 0);
            Speed = random.Next(2, 10);
        }
        /// <summary>
        /// Передаем ширину и высоту формы
        /// </summary>
        /// <param name="formWidth">Ширина</param>
        /// <param name="formHeight">Высота</param>
        public void Fall(int formWidth, int formHeight)
        {
            X += random.Next(-1, 2);
            Y += Speed;

            if (Y > formHeight)
            {
                Y = -10;
                X = random.Next(0, formWidth);
                Speed = random.Next(2, 10);
            }

            if (X < 0)
            {
                X = 0;
            }
            if (X > formWidth - ShowWidth)
            {
                X = formWidth - ShowWidth;
            }
        }
    }
}
