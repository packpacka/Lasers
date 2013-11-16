using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Lasers;

namespace Lasers
{
    /// <summary>
    /// Класс задачи "Лазеры"
    /// </summary>
    [Serializable]
    class LasersGame : Task
    {
        /// <summary>
        /// Координатный множитель
        /// </summary>
        public const int COORDINATE_RATIO = 10;

        /// <summary>
        /// Зеркала
        /// </summary>
        private List<Square> _Mirrors;

        /// <summary>
        /// Зеркала
        /// </summary>
        internal List<Square> Mirrors
        {
            get { return _Mirrors; }
            set { _Mirrors = value; }
        }

        /// <summary>
        /// "Дыры"
        /// </summary>
        private List<Square> _Holes;

        /// <summary>
        /// "Дыры"
        /// </summary>
        internal List<Square> Holes
        {
            get { return _Holes; }
        }
        
        /// <summary>
        /// Лазер
        /// </summary>
        private Laser _Laser;

        /// <summary>
        /// Лазер
        /// </summary>
        internal Laser Laser
        {
            get { return _Laser; }
        }

        /// <summary>
        /// Массив целевых точек
        /// </summary>
        private List<Goal> _Goals;
        
        /// <summary>
        /// Массив целевых точек
        /// </summary>
        internal List<Goal> Goals
        {
            get { return _Goals; }
        }
        
        /// <summary>
        /// Ширина поля
        /// </summary>
        private int _FieldWidth;
        
        /// <summary>
        /// Высота поля
        /// </summary>
        private int _FieldHeight;
      
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parFieldWidth">Ширина поля</param>
        /// <param name="parFieldHeight">Выста поля</param>
        /// <param name="parLaser">Лазер</param>
        /// <param name="parGoal">Целевая точка</param>
        /// <param name="parMirrors">Зеркала</param>
        public LasersGame(int parFieldWidth, int parFieldHeight, LaserSource parLaser, List<Goal> parGoals, List<Square> parMirrors, List<Square> parHoles)
        {
            _FieldHeight = parFieldHeight;
            _FieldWidth = parFieldWidth;

            parLaser.Vector = new Point(parLaser.Vector.X * COORDINATE_RATIO / (2 * Math.Abs(parLaser.Vector.X)) , 
                                        parLaser.Vector.Y * COORDINATE_RATIO / (2 * Math.Abs(parLaser.Vector.Y)));
            
            _Laser = new Laser(parLaser);
            
            _Goals = parGoals;
            
            _Mirrors = parMirrors;

            _Holes = parHoles;
        }

        /// <summary>
        /// Конструктор класса;
        /// </summary>
        public LasersGame(int parFieldWidth, int parFieldHeight)
        {
            _FieldHeight = parFieldHeight;
            _FieldWidth = parFieldWidth;
            _Laser = new Laser(new Point(0, 0), new Point(- COORDINATE_RATIO / 2, COORDINATE_RATIO / 2));
            
            _Goals = new List<Goal>();

            _Mirrors = new List<Square>();

            _Holes = new List<Square>();
        }

        /// <summary>
        /// Установить лазер
        /// </summary>
        /// <param name="parPos">Положение лазера</param>
        /// <param name="parVector">Вектор направления лазера</param>
        public void SetUpLaser(Point parPos, Point parVector)
        {
            if (PointInField(parPos))
            {
                parVector.X = parVector.X * COORDINATE_RATIO / (2 * Math.Abs(parVector.X));
                parVector.Y = parVector.Y * COORDINATE_RATIO / (2 * Math.Abs(parVector.Y));

                _Laser = new Laser(parPos, parVector);

                CalculateLaser();
            }
        }

        /// <summary>
        /// Установить лазер
        /// </summary>
        /// <param name="parPos">Положение лазера</param>
        /// <param name="parVector">Вектор направления лазера</param>
        public void SetUpLaser(LaserSource parLaserSource)
        {
            if (PointInField(parLaserSource.Position))
            {
                Point vector = parLaserSource.Vector;

                vector.X = parLaserSource.Vector.X * COORDINATE_RATIO / (2 * Math.Abs(parLaserSource.Vector.X));
                vector.Y = parLaserSource.Vector.Y * COORDINATE_RATIO / (2 * Math.Abs(parLaserSource.Vector.Y));
                parLaserSource.Vector = vector;

                _Laser = new Laser(parLaserSource);

                CalculateLaser();
            }

        }

        /// <summary>
        /// Добавить зеркало на поле
        /// </summary>
        /// <param name="parPos">координата верхнего левого угла</param>
        public void AddMirror(Point parPos)
        {
            if (PointInField(parPos))
            {
                bool isExists = false;
                //смортрим все существующие зеркала
                for (int i = 0; i < _Mirrors.Count; i++)
                {
                    //если найдется зеркало с такими же координатами как у добавляемого
                    if ((_Mirrors[i].Left == parPos.X) && (_Mirrors[i].Top == parPos.Y))
                    {
                        //отмечаем, существование
                        isExists = true;
                    }
                }
                //если зеркало с такими координатами не существует
                if (!isExists)
                {
                    //добавляем зеркало
                    _Mirrors.Add(new Square(parPos.Y, parPos.Y + COORDINATE_RATIO, parPos.X, parPos.X + COORDINATE_RATIO));
                }

                //проверяем дыры
                for (int i = 0; i < _Mirrors.Count; i++)
                {
                    //если найдется дыра с такими же координатами как у добавляемго зеркала
                    if ((_Holes[i].Left == parPos.X) && (_Holes[i].Top == parPos.Y))
                    {
                        //удаляем ее
                        _Holes.RemoveAt(i);
                    }
                }
            }

            //пересчитываем траекторию лазера
            CalculateLaser();
        }

        /// <summary>
        /// Добавить зеркало на поле
        /// </summary>
        /// <param name="parPos">Список координат зеркал</param>
        public void AddMirror(List<Point> parMirrors)
        {
            for (int j = 0; j < parMirrors.Count; j++)
            {
                if (PointInField(parMirrors[j]))
                {
                    bool isExists = false;
                    //смортрим все существующие зеркала
                    for (int i = 0; i < _Mirrors.Count; i++)
                    {
                        //если найдется зеркало с такими же координатами как у добавляемого
                        if ((_Mirrors[i].Left == parMirrors[j].X) && (_Mirrors[i].Top == parMirrors[j].Y))
                        {
                            //отмечаем, существование
                            isExists = true;
                        }
                    }
                    //если зеркало с такими координатами не существует
                    if (!isExists)
                    {
                        //добавляем зеркало
                        _Mirrors.Add(new Square(parMirrors[j].Y, parMirrors[j].Y + COORDINATE_RATIO, parMirrors[j].X, parMirrors[j].X + COORDINATE_RATIO));
                    }

                    //проверяем дыры
                    for (int i = 0; i < _Holes.Count; i++)
                    {
                        //если найдется дыра с такими же координатами как у добавляемго зеркала
                        if ((_Holes[i].Left == parMirrors[j].X) && (_Holes[i].Top == parMirrors[j].Y))
                        {
                            //удаляем ее
                            _Holes.RemoveAt(i);
                        }
                    }
                }
            }

            //пересчитываем траекторию лазера
            CalculateLaser();
        }

        /// <summary>
        /// Очистить список зеркал
        /// </summary>
        public void ClearMirrors()
        {
            _Mirrors.Clear();
        }

        /// <summary>
        /// Получить список координат зеркал на поле
        /// </summary>
        /// <returns>координаты дыр</returns>
        public List<Point> GetMirrors()
        {
            List<Point> mirrors = new List<Point>();

            for (int i = 0; i < _Mirrors.Count; i++)
            {
                mirrors.Add(new Point(_Mirrors[i].Left, _Mirrors[i].Top));
            }

            return mirrors;
        }

        /// <summary>
        /// Добавить дыру на поле
        /// </summary>
        /// <param name="parPos">координата верхнего левого угла</param>
        public void AddHole(Point parPos)
        {

            if (PointInField(parPos))
            {
                bool isExists = false;
                //смортрим все существующие дыры
                for (int i = 0; i < _Holes.Count; i++)
                {
                    //если найдется дыру с такими же координатами как у добавляемой
                    if ((_Holes[i].Left == parPos.X) && (_Holes[i].Top == parPos.Y))
                    {
                        //отмечаем, существование
                        isExists = true;
                    }
                }
                //если дыры с такими координатами не существует
                if (!isExists)
                {
                    //добавляем дыру
                    _Holes.Add(new Square(parPos.Y, parPos.Y + COORDINATE_RATIO, parPos.X, parPos.X + COORDINATE_RATIO));
                }

                //проверяем зеркала
                for (int i = 0; i < _Mirrors.Count; i++)
                {
                    //если найдется зеркало с такими же координатами как у добавляемой дыры
                    if ((_Mirrors[i].Left == parPos.X) && (_Mirrors[i].Top == parPos.Y))
                    {
                        //удаляем его
                        _Mirrors.RemoveAt(i);
                    }
                }
            }


            //пересчитываем траекторию лазера
            CalculateLaser();
        }

        /// <summary>
        /// Добавить дыру на поле
        /// </summary>
        /// <param name="parHoles">список координат дыр</param>
        public void AddHole(List<Point> parHoles)
        {
            for (int j = 0; j < parHoles.Count; j++)
            {
                if (PointInField(parHoles[j]))
                {
                    bool isExists = false;
                    //смортрим все существующие дыры
                    for (int i = 0; i < _Holes.Count; i++)
                    {
                        //если найдется дыру с такими же координатами как у добавляемого
                        if ((_Holes[i].Left == parHoles[j].X) && (_Holes[i].Top == parHoles[j].Y))
                        {
                            //отмечаем, существование
                            isExists = true;
                        }
                    }
                    //если дыры с такими координатами не существует
                    if (!isExists)
                    {
                        //добавляем дыру
                        _Holes.Add(new Square(parHoles[j].Y, parHoles[j].Y + COORDINATE_RATIO, parHoles[j].X, parHoles[j].X + COORDINATE_RATIO));
                    }

                    //проверяем зеркала
                    for (int i = 0; i < _Mirrors.Count; i++)
                    {
                        //если найдется зеркало с такими же координатами как у добавляемой дыры
                        if ((_Mirrors[i].Left == parHoles[j].X) && (_Mirrors[i].Top == parHoles[j].Y))
                        {
                            //удаляем его
                            _Mirrors.RemoveAt(i);
                        }
                    }
                }
            }


            //пересчитываем траекторию лазера
            CalculateLaser();
        }

        /// <summary>
        /// Очистить список дыр
        /// </summary>
        public void ClearHoles()
        {
            _Holes.Clear();
        }
        
        /// <summary>
        /// Получить список координат дыр на поле
        /// </summary>
        /// <returns>координаты дыр</returns>
        public List<Point> GetHoles()
        {
            List<Point> holes = new List<Point>();

            for (int i = 0; i < _Holes.Count; i++)
            {
                holes.Add(new Point(_Holes[i].Left, _Holes[i].Top));
            }

            return holes;
        }

        /// <summary>
        /// Добавление целевой точки
        /// </summary>
        /// <param name="parPos">координата целевой точки</param>
        public void AddGoal(Point parPos)
        {
            if (PointInField(parPos))
            {
                bool isExists = false;

                for (int i = 0; i < _Goals.Count; i++)
                {
                    if (_Goals[i].Position == parPos)
                    {
                        isExists = true;
                    }
                }

                if (!isExists)
                {
                    _Goals.Add(new Goal(parPos));
                }
            }

            CalculateLaser();
        }

        /// <summary>
        /// Добавление целевой точки
        /// </summary>
        /// <param name="parGoals">Список координат целевых точек</param>
        public void AddGoal(List<Point> parGoals)
        {
            for (int j = 0; j < parGoals.Count; j++)
            {
                if (PointInField(parGoals[j]))
                {
                    bool isExists = false;

                    for (int i = 0; i < _Goals.Count; i++)
                    {
                        if (_Goals[i].Position == parGoals[j])
                        {
                            isExists = true;
                        }
                    }

                    if (!isExists)
                    {
                        _Goals.Add(new Goal(parGoals[j]));
                    }
                }
            }

            CalculateLaser();
        }

        /// <summary>
        /// Очистить список целевых точек
        /// </summary>
        public void ClearGoals()
        {
            _Goals.Clear();
        }

        /// <summary>
        /// Получить целевые точки
        /// </summary>
        /// <returns>Координаты целевых точек</returns>
        public List<Point> GetGoals()
        {
            List<Point> goals = new List<Point>();

            for (int i = 0; i < _Goals.Count; i++)
            {
                goals.Add(_Goals[i].Position);
            }

            return goals;
        }

        /// <summary>
        /// Рассчитать траекторию лазера
        /// </summary>
        public void CalculateLaser()
        {
            Point laserPoint = _Laser.LaserSource.Position;
            Point laserVector = _Laser.LaserSource.Vector;

            bool laserIsBlocked = false;
            bool laserIsReflected = false;

            //перезапускаем лазерный луч
            _Laser.ClearLaser();

            //сбрасываем флаги пересечения на всех целях
            for (int i = 0; i < _Goals.Count; i++)
            {
                _Goals[i].Crossed = false;
            }

            //пока лазер в поле и не заблокирован
            while ((PointInField(laserPoint)) && (!laserIsBlocked) && (!_Laser.IsLoop()))
            {
                //проверяем пересечение с целевыми точками
                for (int i = 0; i < _Goals.Count; i++)
                {
                    if (laserPoint == _Goals[i].Position)
                    {
                        _Goals[i].Crossed = true;
                    }
                }
                    //проверяем каждое зеркало
                for (int i = 0; i < _Mirrors.Count; i++)
                {
                    //если найдется зеркало, у которого координата левой грани равна текущей точке лазера 
                    //и вектор направления положителен по оси Х
                    if ((_Mirrors[i].Left == laserPoint.X) && (laserVector.X > 0) && (_Mirrors[i].Top < laserPoint.Y) && (_Mirrors[i].Down > laserPoint.Y))
                    {
                        //если последний сохраненный сегмент был в этой же точке и это не источник лазерного луча
                        if ((_Laser.LaserSegments[_Laser.SegmentsCount - 1].Position == laserPoint) && (_Laser.SegmentsCount > 1))
                        {
                            //значит лазер заблокирован
                            laserIsBlocked = true;
                        }
                        //иначе отражаем луч
                        else
                        {
                            _Laser.AddSegment(laserPoint, laserVector);
                            _Laser.FlipVertical();
                            laserVector = _Laser.LaserSegments[_Laser.SegmentsCount - 1].Vector;
                            laserIsReflected = true;
                        }
                        break;
                    }
                    else
                        //если найдется зеркало, у которого координата правой грани равна текущей точке лазера
                        //и вектор направления положителен по оси Х
                        if ((_Mirrors[i].Right == laserPoint.X) && (laserVector.X < 0) && (_Mirrors[i].Top < laserPoint.Y) && (_Mirrors[i].Down > laserPoint.Y))
                        {
                            //если последний сохраненный сегмент был в этой же точке и это не источник лазерного луча
                            if ((_Laser.LaserSegments[_Laser.SegmentsCount - 1].Position == laserPoint) && (_Laser.SegmentsCount > 1))
                            {
                                //значит лазер заблокирован
                                laserIsBlocked = true;
                            }
                            //иначе отражаем луч
                            else
                            {
                                _Laser.AddSegment(laserPoint, laserVector);
                                _Laser.FlipVertical();
                                laserVector = _Laser.LaserSegments[_Laser.SegmentsCount - 1].Vector;
                                laserIsReflected = true;
                            }
                            break;
                        }
                        else
                            //если найдется зеркало, у которого координата нижней грани равна текущей точке лазера
                            //и вектор направления отрицатлен по оси Y
                            if ((_Mirrors[i].Down == laserPoint.Y) && (laserVector.Y < 0) && (_Mirrors[i].Left < laserPoint.X) && (_Mirrors[i].Right > laserPoint.X))
                            {
                                //если последний сохраненный сегмент был в этой же точке и это не источник лазерного луча
                                if ((_Laser.LaserSegments[_Laser.SegmentsCount - 1].Position == laserPoint) && (_Laser.SegmentsCount > 1))
                                {
                                    //значит лазер заблокирован
                                    laserIsBlocked = true;
                                }
                                //иначе отражаем луч
                                else
                                {
                                    _Laser.AddSegment(laserPoint, laserVector);
                                    _Laser.FlipHorizontal();
                                    laserVector = _Laser.LaserSegments[_Laser.SegmentsCount - 1].Vector;
                                    laserIsReflected = true;
                                }
                                break;
                            }
                            else

                                //если найдется зеркало, у которого координата верхней грани равна текущей точке лазера
                                //и вектор направления положителен по оси Y
                                if ((_Mirrors[i].Top == laserPoint.Y) && (laserVector.Y > 0) && (_Mirrors[i].Left < laserPoint.X) && (_Mirrors[i].Right > laserPoint.X))
                                {
                                    //если последний сохраненный сегмент был в этой же точке и это не источник лазерного луча
                                    if ((_Laser.LaserSegments[_Laser.SegmentsCount - 1].Position == laserPoint) && (_Laser.SegmentsCount > 1))
                                    {
                                        //значит лазер заблокирован
                                        laserIsBlocked = true;
                                    }
                                    //иначе отражаем луч
                                    else
                                    {
                                        _Laser.AddSegment(laserPoint, laserVector);
                                        _Laser.FlipHorizontal();
                                        laserVector = _Laser.LaserSegments[_Laser.SegmentsCount - 1].Vector;
                                        laserIsReflected = true;
                                    }
                                    break;
                                }
                }
                
                //если луч не был только что отражен и он не заблокирован, продвигаемся вперед по лучу
                if ((!laserIsReflected) && (!laserIsBlocked))
                {
                    laserPoint = new Point(laserPoint.X + laserVector.X, laserPoint.Y + laserVector.Y);

                    //если точка лазера вышла за пределы поля, заносим ее в конец списка сегментов луча
                    if (!PointInField(laserPoint))
                    {
                        _Laser.AddSegment(laserPoint, laserVector);
                    }
                }

                laserIsReflected = false;
            }
        }

        /// <summary>
        /// Определение принадлежности точки полю
        /// </summary>
        /// <param name="parPoint">Проверяемая точка</param>
        /// <returns></returns>
        private bool PointInField(Point parPoint)
        {
            if ((parPoint.X >= 0) && (parPoint.X <= _FieldWidth) && (parPoint.Y >= 0) && (parPoint.Y <= _FieldHeight))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Определение существования на поле зеркала с указанными координатами
        /// </summary>
        /// <param name="parMirrorPos">координаты искомого зеркала</param>
        /// <returns>true если на поле существует зеркало с указанными координатами</returns>
        public bool ExistsMirror(Point parMirrorPos)
        {
            bool exists = false;

            for (int i = 0; i < _Mirrors.Count; i++)
            {
                if ((_Mirrors[i].Left == parMirrorPos.X) && (_Mirrors[i].Top == parMirrorPos.Y))
                {
                    exists = true;
                    break;
                }
            }

            return exists;
        }

        /// <summary>
        /// Определение существования на поле дыры с указанными координатами
        /// </summary>
        /// <param name="parMirrorPos">координаты искомой дыры</param>
        /// <returns>true если на поле существует дыра с указанными координатами</returns>
        public bool ExistsHole(Point parMirrorPos)
        {
            bool exists = false;

            for (int i = 0; i < _Holes.Count; i++)
            {
                if ((_Holes[i].Left == parMirrorPos.X) && (_Holes[i].Top == parMirrorPos.Y))
                {
                    exists = true;
                    break;
                }
            }

            return exists;
        }

        /// <summary>
        /// Определение достижение цели
        /// </summary>
        /// <returns>true - если все целевые точки пересечены лазерным лучом</returns>
        public bool GoalReached()
        {
            bool allGoalsReached = true;

            for (int i = 0; i < _Goals.Count; i++)
            {
                
                if (_Goals[i].Crossed == false)
                {
                    allGoalsReached = false;
                }
            }

            return allGoalsReached;
        }

        /// <summary>
        /// Ширина поля
        /// </summary>
        public int FieldWidth
        {
            get { return _FieldWidth; }
            set 
            { 
                _FieldWidth = value;
                _Mirrors.Clear();
                _Holes.Clear();
                _Goals.Clear();
                _Laser = new Laser(new Point(0, 0), new Point(-COORDINATE_RATIO / 2, COORDINATE_RATIO / 2));
            }
        }

        /// <summary>
        /// Высота поля
        /// </summary>
        public int FieldHeight
        {
            get { return _FieldHeight; }
            set 
            { 
                _FieldHeight = value;
                _Mirrors.Clear();
                _Holes.Clear();
                _Goals.Clear();
                _Laser = new Laser(new Point(0, 0), new Point(-COORDINATE_RATIO / 2, COORDINATE_RATIO / 2));
            }
        }

    }
}
