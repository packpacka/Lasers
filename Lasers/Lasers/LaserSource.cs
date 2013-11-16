using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lasers
{
    /// <summary>
    /// Класс источник лазера
    /// </summary>
    [Serializable]
    class LaserSource
    {
         /// <summary>
        /// положение лезера
        /// </summary>
        private Point _Position;

       
        /// <summary>
        /// Вектор направления источника лазера
        /// </summary>
        private Point _Vector;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parPos">Положение источника</param>
        /// <param name="parVector">Вектор направления источника</param>
        public LaserSource(Point parPos, Point parVector)
        {
            _Position = parPos;
            _Vector = parVector;
        }

        /// <summary>
        /// положение лазера
        /// </summary>
        public Point Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        /// <summary>
        /// Вектор направления источника лазера
        /// </summary>
        public Point Vector
        {
            get { return _Vector; }
            set { _Vector = value; }
        }
    }
}
