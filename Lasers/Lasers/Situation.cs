using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lasers
{
    /// <summary>
    /// класс ситуации на поле
    /// </summary>
    public class Situation
    {
        /// <summary>
        /// Занятые ячейки поля
        /// </summary>
        private List<Point> _OcceupedCells;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parMirrors"></param>
        public Situation(List<Square> parMirrors)
        {
            _OcceupedCells = new List<Point>();

            for (int i = 0; i < parMirrors.Count; i++)
            {
                _OcceupedCells.Add(new Point(parMirrors[i].Left, parMirrors[i].Top));
            }
        }

        /// <summary>
        /// Занятые ячейки поля
        /// </summary>
        public List<Point> OcceupedCells
        {
            get { return _OcceupedCells; }
            set { _OcceupedCells = value; }
        }
    }
}
