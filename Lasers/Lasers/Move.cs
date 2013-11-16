using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lasers
{
    /// <summary>
    /// Класс хода
    /// </summary>
    public class Move
    {
        /// <summary>
        /// Из какой позиции перемещаем зеркало
        /// </summary>
        private Point _FromPos;

        public Point FromPos
        {
            get { return _FromPos; }
        }
        /// <summary>
        /// В какую позицию перемещаем зеркало
        /// </summary>
        private Point _ToPos;

        public Point ToPos
        {
            get { return _ToPos; }
        }

        /// <summary>
        /// зеркала
        /// </summary>
        private List<Square> _Mirrors;

        public List<Square> Mirrors
        {
            get { return _Mirrors; }
            set { _Mirrors = value; }
        }


        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parFromPoint">из какой точки передвигаем зеркало</param>
        /// <param name="parToPoint">в какую точку перемещаем зеркало</param>
        public Move(Point parFromPoint, Point parToPoint)
        {
            _FromPos = parFromPoint;
            _ToPos = parToPoint;
        }

        public Move(Point parFromPoint, Point parToPoint, List<Square> parMirrors)
        {
            _FromPos = parFromPoint;
            _ToPos = parToPoint;
            _Mirrors = parMirrors;
        }
    }
}
