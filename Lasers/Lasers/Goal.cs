using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lasers
{
    /// <summary>
    /// Класс цели
    /// </summary>
    [Serializable]
    class Goal
    {
        /// <summary>
        /// Положение цели
        /// </summary>
        private Point _Position;

        /// <summary>
        /// Флаг пересечения цели лучем
        /// </summary>
        private bool _Crossed;

        /// <summary>
        /// Конструктор класс
        /// </summary>
        /// <param name="parPos">Положение цели</param>
        public Goal(Point parPos)
        {
            _Position = parPos;
            _Crossed = false;
        }

        /// <summary>
        /// Флаг пересечения цели лучем
        /// </summary>
        public bool Crossed
        {
            get { return _Crossed; }
            set { _Crossed = value; }
        }

        /// <summary>
        /// Положение цели
        /// </summary>
        public Point Position
        {
            get { return _Position; }
            set { _Position = value; }
        }
    }
}
