using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lasers;
using System.Drawing;
using System.Diagnostics;

namespace Lasers
{
    /// <summary>
    /// Класс решателя игры "Лазер"
    /// </summary>
    class LaserGameSolver : TaskSolver
    {
        /// <summary>
        /// Зеркала
        /// </summary>
        private List<Square> _Mirrors;
        /// <summary>
        /// "Дыры"
        /// </summary>
        private List<Square> _Holes;
        /// <summary>
        /// Лазер
        /// </summary>
        private Laser _Laser;
        /// <summary>
        /// Массив целевых точек
        /// </summary>
        private List<Goal> _Goals;
        /// <summary>
        /// Ширина поля
        /// </summary>
        private int _FieldWidth;
        /// <summary>
        /// Высота поля
        /// </summary>
        private int _FieldHeight;
        
        /// <summary>
        /// Задача
        /// </summary>
        private LasersGame _Task;
        
        /// <summary>
        /// Задача
        /// </summary>
        public LasersGame Task
        {
            get { return _Task; }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parGame"></param>
        public LaserGameSolver(LasersGame parGame) : base(parGame)
        {
            _Task = parGame;
            _Mirrors = _Task.Mirrors;
            _Holes = _Task.Holes;
            _Goals = _Task.Goals;
            _Laser = _Task.Laser;
            _FieldHeight = _Task.FieldHeight;
            _FieldWidth = _Task.FieldWidth;

            MaxAlowableDepth = _Task.Mirrors.Count;
        }

        /// <summary>
        /// Создать первый ход
        /// </summary>
        /// <returns></returns>
        public override Move CreateFirstMove()
        {
            Move firstMove = null;

            if (_Task.Mirrors.Count > 0)
            {
                firstMove = new Move(new Point(-1,-1), new Point (-1,-1), GetMirrorsCopy(_Task.Mirrors));
            }

            return firstMove;
        }
        
        /// <summary>
        /// Проверка достижения цели
        /// </summary>
        /// <param name="parSolutionThree">проверяемый узел дерева</param>
        /// <returns>true - если узел целевой</returns>
        public override bool GoalIsReached(SolutionThree parSolutionThree)
        {
            return _Task.GoalReached();
        }
      
        /// <summary>
        /// Проверка тупика
        /// </summary>
        /// <param name="parSolutionThree">проверяемый узел дерева</param>
        /// <returns>true - если узел тупиковый </returns>
        public override bool Deadlock(SolutionThree parSolutionThree)
        {
            bool deadlock = false;

            if ((parSolutionThree.Level >= MaxAlowableDepth))
            {
                deadlock = true;
            }

            return deadlock;
        }
        
        /// <summary>
        /// Получение списка возможных ходов
        /// </summary>
        /// <param name="parSolutionThree"></param>
        /// <returns></returns>
        public override List<Move> GetAvailableMoves(SolutionThree parSolutionThree)
        {
            List<Move> availableMove = new List<Move>();

            //получаем последний совершенный ход
            Move lastMove = parSolutionThree.Move;

            //активизируем поле, указанное в ходе
            _Task.Mirrors = GetMirrorsCopy(lastMove.Mirrors);

            //проходим по всез зеркалам
            for (int k = 0; k < _Task.Mirrors.Count; k++)
            {
                //в качаестве начальной точки берем положение очередного зеркала
                Point fromPos = new Point(_Task.Mirrors[k].Left, _Task.Mirrors[k].Top);
                //проходим по всем координатам поля
                for (int i = 0; i < _FieldHeight; i += LasersGame.COORDINATE_RATIO)
                    for (int j = 0; j < _FieldWidth; j += LasersGame.COORDINATE_RATIO)
                    {
                        //если ячейка не занята и не являетяс дырой
                        if (
                            (!_Task.ExistsHole(new Point(j, i))) &&
                            (!_Task.ExistsMirror(new Point(j, i)))
                           )
                        {
                            //выбираем конечную точку
                            Point toPos = new Point(j, i);
                            //и добавляем ход из начально точки в конечную в список возможных ходов
                            availableMove.Add(new Move(fromPos, toPos, GetMirrorsCopy(_Task.Mirrors)));
                        }
                    }
            }
            
            //возвращаем список возможных ходов
            return availableMove;
        }

        /// <summary>
        /// Сортировка списка возможных ходов согласно оценочной функции
        /// </summary>
        /// <param name="parAvailableMoves"></param>
        /// <param name="parSolutionThree"> узелд дерева из которого совершается ход</param>
        public override void SortMoves(List<Move> parAvailableMoves, SolutionThree parSolutionThree)
        {
            List<Move> availableMoves = parAvailableMoves;
            List<int> movesMarks = new List<int>();

            //для каждого возможного хода 
            for (int i = 0; i < availableMoves.Count; i++)
            {
                //получаем его оценку
                int rating = Estimator(availableMoves[i], parSolutionThree);
                movesMarks.Add(rating);
            }

            //сортируем возможные ходы согласно их оценкам
            for (int i = 0; i < availableMoves.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (movesMarks[i] > movesMarks[j])
                    {
                        int mark = movesMarks[i];
                        movesMarks.RemoveAt(i);
                        movesMarks.Insert(j, mark);

                        Move move = availableMoves[i];
                        availableMoves.RemoveAt(i);
                        availableMoves.Insert(j, move);
                    }
                }
            }
        }

        /// <summary>
        /// Сортировка сгенерированных узлов дерева по оценочной функции
        /// </summary>
        /// <param name="parThreeNodes">Сортируемые узлы</param>
        public override void SortThreeNodes(List<SolutionThree> parThreeNodes)
        {
            List<SolutionThree> threeNodes = parThreeNodes;
            List<int> movesMarks = new List<int>();
        
            //для каждого возможного хода 
            for (int i = 0; i < threeNodes.Count; i++)
            {
                //получаем его оценку
                int rating = Estimator(threeNodes[i].Move, threeNodes[i].Root);
                movesMarks.Add(rating);
            }

            //сортируем возможные ходы согласно их оценкам
            for (int i = 0; i < threeNodes.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (movesMarks[i] > movesMarks[j])
                    {
                        int mark = movesMarks[i];
                        movesMarks.RemoveAt(i);
                        movesMarks.Insert(j, mark);

                        SolutionThree node = threeNodes[i];
                        threeNodes.RemoveAt(i);
                        threeNodes.Insert(j, node);
                    }
                }
            }
        }

        /// <summary>
        /// Оценочная функция
        /// </summary>
        /// <param name="parMove">оцениваемый ход</param>
        /// <param name="parSolutionThree"> узелд дерева из которого совершается ход</param>
        /// <returns>rколичество ходов, прошедших с момента последненго перемещения зеркала, указанного в ходе</returns>
        public override int Estimator(Move parMove, SolutionThree parSolutionThree)
        {
            int rating = MaxAlowableDepth + 1;
            //получаем исходное положение перемещаемого зеркала
            Point mirrorPosition = parMove.FromPos;
            //и узел дерева из которого совершаем ход
            SolutionThree solutionNode = parSolutionThree;

            //пока не добрались до корня дерва поиска
            while (solutionNode.Root != null)
            {
                //если ход, приведший к текущему узлу дерева, перемещал проверяемое зеркало
                if (solutionNode.Move.ToPos == mirrorPosition)
                {
                    //считаем сколько ходов назад это было
                    rating = parSolutionThree.Level - solutionNode.Level + 1;
                    break;
                }
                    //иначе
                else
                {
                    //и перемещаемся вверх по дереву.
                    solutionNode = solutionNode.Root;
                }
            }
            
            return rating;
        }
        
        /// <summary>
        /// Совершение хода
        /// </summary>
        /// <param name="parMove">Совершаемый ход</param>
        /// <param name="parSolutionThree">узел дерева, из которого совершаем ход</param>
        public override void MakeMove(Move parMove, SolutionThree parSolutionThree)
        {
            //активизируем поле 
            _Task.Mirrors = GetMirrorsCopy(parMove.Mirrors);
            //проходим по всем зеркалам
            for (int i = 0; i < _Task.Mirrors.Count; i++)
            {
                //находим зеркало указанное в ходе и совершием ход
                if ((_Task.Mirrors[i].Left == parMove.FromPos.X) && (_Task.Mirrors[i].Top == parMove.FromPos.Y))
                {
                    parMove.Mirrors[i] = new Square(parMove.ToPos.Y, parMove.ToPos.Y + LasersGame.COORDINATE_RATIO, parMove.ToPos.X, parMove.ToPos.X + LasersGame.COORDINATE_RATIO);  
                }
            }
            _Task.Mirrors = GetMirrorsCopy(parMove.Mirrors);
            //пересчитываем траекторию лазера
            _Task.CalculateLaser(); 
        }

        /// <summary>
        /// Отмена хода
        /// </summary>
        /// <param name="parMove"></param>
        /// <param name="parSolutionThree"></param>
        public override void CancelMove(Move parMove, SolutionThree parSolutionThree)
        {
            _Task.Mirrors = parMove.Mirrors;
            
            for (int i = 0; i < _Task.Mirrors.Count; i++)
            {
                if ((_Task.Mirrors[i].Left == parMove.ToPos.X) && (_Task.Mirrors[i].Top == parMove.ToPos.Y))
                {
                    parMove.Mirrors[i] = new Square(parMove.FromPos.Y, parMove.FromPos.Y + LasersGame.COORDINATE_RATIO, parMove.FromPos.X, parMove.FromPos.X + LasersGame.COORDINATE_RATIO);
                    
                    _Task.CalculateLaser();
                }
            }
        }

        /// <summary>
        /// Получение копии списка зеркал
        /// </summary>
        /// <param name="parMirrors"></param>
        /// <returns></returns>
        private List<Square> GetMirrorsCopy(List<Square> parMirrors)
        {
            List<Square> mirrorsCopy = new List<Square>();

            for (int i = 0; i < parMirrors.Count; i++)
            {
                mirrorsCopy.Add(parMirrors[i].Clone());
            }

            return mirrorsCopy;
        }
        
    }
}
