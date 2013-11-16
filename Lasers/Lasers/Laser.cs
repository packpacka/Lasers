using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lasers
{
    /// <summary>
    /// Класс лазер
    /// </summary>
    [Serializable]
    class Laser
    {
        /// <summary>
        /// Сегменты лазерного луча
        /// </summary>
        private List<LaserSource> _LaserSegments;

        /// <summary>
        /// Источник лазерного луча
        /// </summary>
        private LaserSource _LaserSource;
               
        /// <summary>
        /// Количество сегментов луча
        /// </summary>
        private int _SegmentsCount;       

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parLaserSource">сегмент лазерного луча</param>
        public Laser(LaserSource parLaserSource)
        {
            _LaserSegments = new List<LaserSource>();
            _LaserSegments.Add(parLaserSource);
            _LaserSource = parLaserSource;
            _SegmentsCount = _LaserSegments.Count;
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parSourcePos">Положение источника сегмента лазерного луча</param>
        /// <param name="parSoursVector">Вектор направления сегмента лазерного луча</param>
        public Laser(Point parSourcePos, Point parSoursVector)
        {
            _LaserSegments = new List<LaserSource>();
            _LaserSegments.Add(new LaserSource(parSourcePos, parSoursVector));
            _LaserSource = _LaserSegments[0];
            _SegmentsCount = _LaserSegments.Count;
        }

        /// <summary>
        /// Добавить новый сегмент луча
        /// </summary>
        /// <param name="parLaserSource">Новый сегмент луча</param>
        public void AddSegment(LaserSource parLaserSource)
        {
            _LaserSegments.Add(parLaserSource);
            _LaserSource = _LaserSegments[0];
            _SegmentsCount = _LaserSegments.Count;
        }

        /// <summary>
        /// Добавить новый сегмент луча 
        /// </summary>
        /// <param name="parSourcePos">Положение источника лазерного луча</param>
        /// <param name="parSoursVector">Вектор направления лазерного луча</param>
        public void AddSegment(Point parSourcePos, Point parSoursVector)
        {
            _LaserSegments.Add(new LaserSource(parSourcePos, parSoursVector));
            _LaserSource = _LaserSegments[0];
            _SegmentsCount = _LaserSegments.Count;
        }

        /// <summary>
        /// Удалить сегмент луча и все следующие за ним сегменты
        /// </summary>
        /// <param name="parLaserSource">Удаляемый сегмент cегмент луча</param>
        public void RemoveSegment(LaserSource parLaserSource)
        {
            _LaserSegments.RemoveRange(_LaserSegments.IndexOf(parLaserSource), _SegmentsCount - _LaserSegments.IndexOf(parLaserSource));
            _LaserSource = _LaserSegments[0];
            _SegmentsCount = _LaserSegments.Count;
        }

        /// <summary>
        /// Удалить сегмент луча и все следующие за ним сегменты
        /// </summary>
        /// <param name="parSourcePos">Положение источника лазерного луча</param>
        /// <param name="parSoursVector">Вектор направления лазерного луча</param>
        public void RemoveSegment(Point parSourcePos, Point parSoursVector)
        {
            _LaserSegments.RemoveRange(_LaserSegments.IndexOf(new LaserSource(parSourcePos, parSoursVector)), - _SegmentsCount - _LaserSegments.IndexOf(new LaserSource(parSourcePos, parSoursVector)));
            _LaserSource = _LaserSegments[0];
            _SegmentsCount = _LaserSegments.Count;
        }

        /// <summary>
        /// Удалить сегмент луча и все следующие за ним сегменты
        /// </summary>
        /// <param name="parIndex">Индекс удаляемого егмента луча</param>
        public void RemoveSegment(int parIndex)
        {
            _LaserSegments.RemoveRange(parIndex, _SegmentsCount - parIndex);
            _LaserSource = _LaserSegments[0];
            _SegmentsCount = _LaserSegments.Count;
        }

        /// <summary>
        /// Удалить все сегменты лазера кроме источника
        /// </summary>
        public void ClearLaser()
        {
            RemoveSegment(1);
        }

        /// <summary>
        /// Отразить луч горизонтально в последнем сегменте
        /// </summary>
        public void FlipHorizontal()
        {
            Point newVector = new Point(_LaserSegments[_SegmentsCount - 1].Vector.X, -_LaserSegments[_SegmentsCount - 1].Vector.Y);
            _LaserSegments[_SegmentsCount - 1].Vector = newVector;
        }

        /// <summary>
        /// Отразить луч вертикально в последнем сегменте
        /// </summary>
        public void FlipVertical()
        {
            Point newVector = new Point(-_LaserSegments[_SegmentsCount - 1].Vector.X, _LaserSegments[_SegmentsCount - 1].Vector.Y);
            _LaserSegments[_SegmentsCount - 1].Vector = newVector;
        }

        /// <summary>
        /// Определение зацикленности луча
        /// </summary>
        /// <returns> флаг зацикленности луча</returns>
        public bool IsLoop()
        {
            bool isLoop = false;

            for (int i = 0; (i < _SegmentsCount) && (!isLoop); i++)
            {
                for (int j = 0; (j < i) && (!isLoop); j++)
                {
                    if ((_LaserSegments[i].Position == _LaserSegments[j].Position) && (i - j < i))
                        if (_LaserSegments[j - 1].Position == _LaserSegments[i - 1].Position)
                        {
                            isLoop = true;
                        }
                }
            }
            return isLoop;
        }

        /// <summary>
        /// Количество сегментов луча
        /// </summary>
        public List<LaserSource> LaserSegments
        {
            get { return _LaserSegments; }
            set { _LaserSegments = value; }
        }

        /// <summary>
        /// Источник лазерного луча
        /// </summary>
        public LaserSource LaserSource
        {
            get { return _LaserSource; }
            set { _LaserSource = value; }
        }

        /// <summary>
        /// Сегменты лазерного луча
        /// </summary>
        public int SegmentsCount
        {
            get { return _SegmentsCount; }
            set { _SegmentsCount = value; }
        }


    }
}
