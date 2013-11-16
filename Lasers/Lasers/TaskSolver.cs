using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lasers;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

namespace Lasers
{
    /// <summary>
    /// решатель задач
    /// </summary>
    public abstract class TaskSolver
    {

        /// <summary>
        /// Структура сведений о выполении алгоритма
        /// </summary>
        public struct SolveResult
        {
            /// <summary>
            /// Метод поиска
            /// </summary>
            public string Method;
            /// <summary>
            /// Результат выполнения
            /// </summary>
            public bool Complete;
            /// <summary>
            /// Время выполнения 
            /// </summary>
            public Stopwatch ProcessTime;
            /// <summary>
            /// Длина пути решения
            /// </summary>
            public int PathLenght;
            /// <summary>
            /// Максимальная глубина дерева поиска
            /// </summary>
            public int MaxDepth;
            /// <summary>
            /// Количество сгенерированных узлов
            /// </summary>
            public int GeneratedNodesCount;
            /// <summary>
            /// Направленность дерева поиска
            /// </summary>
            public double Directionality;
            /// <summary>
            /// Разветвленность дерева описка
            /// </summary>
            public double Branching;
            /// <summary>
            /// Список ходов для достижения цели
            /// </summary>
            public List<Move> MovesToGoal;
        }

        /// <summary>
        /// Информация о решении
        /// </summary>
        protected SolveResult _Info;

        /// <summary>
        /// Информация о решении
        /// </summary>
        public SolveResult Info
        {
            get { return _Info; }
        }
        /// <summary>
        /// Макимально допустимая глубина поиска
        /// </summary>
        public int MaxAlowableDepth;
        
        /// <summary>
        /// Задача
        /// </summary>
        protected Task _Task;
        
        /// <summary>
        /// Задача
        /// </summary>
        public Task Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="parTask"></param>
        public TaskSolver(Task parTask)
        {
            _Task = parTask;
        }
               

        /// <summary>
        /// Поиск в глубину
        /// </summary>
        /// <returns></returns>
        public bool DepthSolve()
        {
            //Засекаем время
            _Info.ProcessTime = new Stopwatch();
            _Info.ProcessTime.Start();
            //Задаем начальные сведения
            _Info.MaxDepth = 0;
            _Info.PathLenght = 0;
            _Info.GeneratedNodesCount = 0;
            _Info.MovesToGoal = new List<Move>();

            //решение еще не найдено
            bool complete = false;
            //создаем первый ход
            Move firstMove = CreateFirstMove();
            //добавляем узел в дерево решений
            SolutionThree solutionThree = new SolutionThree(firstMove, null, 0);

            complete = DepthSolve(firstMove, solutionThree);

            //Фиксируем время выполнения
            _Info.ProcessTime.Stop();
            //Записываем результат выполнения
            _Info.Complete = complete;
            _Info.Method = "Поиск в глубину";
            
            //если решение было найдено
            if (complete)
            {
                //рассчитываем разветвленность и направленность
                _Info.Branching = (double)_Info.GeneratedNodesCount / (double)_Info.PathLenght;
                _Info.Directionality = Math.Pow(_Info.GeneratedNodesCount, ((double)1 / _Info.PathLenght));
            }
            //если решение небыло найдено
            else
            {
                //указываем что длина пути решения, разветвленность и направленность не вычеслены числом -1
                _Info.PathLenght = -1;
                _Info.Branching = -1;
                _Info.Directionality = -1;
            }

            //возвращаем результат поиска
            return complete;
        }

        /// <summary>
        /// Поиск в глубину
        /// </summary>
        /// <param name="parMove">Ход</param>
        /// <param name="parSolutionThree">дерево решений</param>
        /// <returns>true если решение найдено, false в противном случае</returns>
        public bool DepthSolve(Move parMove, SolutionThree parSolutionThree)
        {
            //решение еще не найдено
            bool complete = false;
            //дерево решений
            SolutionThree solutionThree  = parSolutionThree;
            //последний совершенный ход
            Move lastMove = solutionThree.Move;

            //если цель достигнута
            if (GoalIsReached(solutionThree))
            {
                complete = true;
                //записываем длину пути и получаем список ходов
                _Info.PathLenght = solutionThree.Level;
                _Info.MovesToGoal = GetMovesToGoal(solutionThree);
            }
            else
                // ессли тупик
                if (Deadlock(solutionThree))
                {
                    complete = false;
                }
                    //если цель не достигнута и ситуация не тупиковая 
                else
                {
                    //получаем список возможных ходщв
                    List<Move> availableMoves = GetAvailableMoves(solutionThree);

                    //проходим по всем узлам
                    for (int i = 0; i < availableMoves.Count; i++)
                    {
                        //совершаем очередной ход
                        MakeMove(availableMoves[i], solutionThree);

                        //добавляем узел в дерево решений
                        solutionThree.AddChildNode(availableMoves[i]);
                        _Info.GeneratedNodesCount++;

                        //Если уровень узла нового узла дерева больше чем сохраненный в логе, 
                        if (solutionThree.ChildNodes[0].Level > _Info.MaxDepth)
                        {
                            //то записываем его в лог
                            _Info.MaxDepth = solutionThree.ChildNodes[0].Level;
                        }

                        // вызываем рекурсивный метод поиска в глубину
                        complete = DepthSolve(availableMoves[i], solutionThree.ChildNodes[0]);

                        //если решение было найдено
                        if (complete)
                        {
                            //заканчиваем просмотр
                            break;
                        }
                            //в противном случае
                        else
                        {
                            //отменяем ход и удаляем рассмотренную ветку дерева
                            CancelMove(availableMoves[i], solutionThree);
                            solutionThree.DeleteChildNode(0);
                        }
                            
                    }
                }

            //возвращаем результат выполнения
            return complete;
        }

        /// <summary>
        /// Поиск в градиенту
        /// </summary>
        /// <returns></returns>
        public bool SteepestRiseSolve()
        {
            //Засекаем время
            _Info.ProcessTime = new Stopwatch();
            _Info.ProcessTime.Start();
            //Задаем начальные сведения
            _Info.MaxDepth = 0;
            _Info.PathLenght = 0;
            _Info.GeneratedNodesCount = 0;
            _Info.MovesToGoal = new List<Move>();

            //решение еще не найдено
            bool complete = false;
            //создаем первый ход
            Move firstMove = CreateFirstMove();
            //добавляем узел в дерево решений
            SolutionThree solutionThree = new SolutionThree(firstMove, null, 0);

            complete = SteepestRiseSolve(firstMove, solutionThree);

            //Фиксируем время выполнения
            _Info.ProcessTime.Stop();
            //Записываем результат выполнения
            _Info.Complete = complete;
            _Info.Method = "Поиск по градиенту";

            //если решение было найдено
            if (complete)
            {
                //рассчитываем разветвленность и направленность
                _Info.Branching = (double)_Info.GeneratedNodesCount / (double)_Info.PathLenght;
                _Info.Directionality = Math.Pow(_Info.GeneratedNodesCount, ((double)1 / _Info.PathLenght));
            }
            //если решение небыло найдено
            else
            {
                //указываем что длина пути решения, разветвленность и направленность не вычеслены числом -1
                _Info.PathLenght = -1;
                _Info.Branching = -1;
                _Info.Directionality = -1;
            }

            //возвращаем результат поиска
            return complete;
        }

        /// <summary>
        /// Поиск по градиенту
        /// </summary>
        /// <param name="parMove">Ход</param>
        /// <param name="parSolutionThree">дерево решений</param>
        /// <returns>true если решение найдено, false в противном случае</returns>
        public bool SteepestRiseSolve(Move parMove, SolutionThree parSolutionThree)
        {
            //решение еще не найдено
            bool complete = false;
            //дерево решений
            SolutionThree solutionThree = parSolutionThree;
            //последний совершенный ход
            Move lastMove = solutionThree.Move;

            //если цель достигнута
            if (GoalIsReached(solutionThree))
            {
                complete = true;
                //записываем длину пути и получаем список ходов
                _Info.PathLenght = solutionThree.Level;
                _Info.MovesToGoal = GetMovesToGoal(solutionThree);
            }
            else
                // ессли тупик
                if (Deadlock(solutionThree))
                {
                    complete = false;
                }
                //если цель не достигнута и ситуация не тупиковая 
                else
                {
                    //получаем список возможных ходщв
                    List<Move> availableMoves = GetAvailableMoves(solutionThree);

                    //упорядочиваем список возможных ходов согласно оценочной функции
                    SortMoves(availableMoves, solutionThree);

                    //проходим по всем узлам
                    for (int i = 0; i < availableMoves.Count; i++)
                    {
                        //совершаем очередной ход
                        MakeMove(availableMoves[i], solutionThree);

                        //добавляем узел в дерево решений
                        solutionThree.AddChildNode(availableMoves[i]);
                        _Info.GeneratedNodesCount++;

                        //Если уровень узла нового узла дерева больше чем сохраненный в логе, 
                        if (solutionThree.ChildNodes[0].Level > _Info.MaxDepth)
                        {
                            //то записываем его в лог
                            _Info.MaxDepth = solutionThree.ChildNodes[0].Level;
                        }

                        // вызываем рекурсивный метод поиска в глубину
                        complete = SteepestRiseSolve(availableMoves[i], solutionThree.ChildNodes[0]);

                        //если решение было найдено
                        if (complete)
                        {
                            //заканчиваем просмотр
                            break;
                        }
                        //в противном случае
                        else
                        {
                            //отменяем ход и удаляем рассмотренную ветку дерева
                            CancelMove(availableMoves[i], solutionThree);
                            solutionThree.DeleteChildNode(0);
                        }

                    }
                }

            //возвращаем результат выполнения
            return complete;
        }

        /// <summary>
        /// Поиск в ширину
        /// </summary>
        /// <returns></returns>
        public bool BreadthSolve()
        {
            //Засекаем время
            _Info.ProcessTime = new Stopwatch();
            _Info.ProcessTime.Start();
            //Задаем начальные сведения
            _Info.MaxDepth = 0;
            _Info.PathLenght = 0;
            _Info.GeneratedNodesCount = 0;
            _Info.MovesToGoal = new List<Move>();


            //флаг нахождения решения
            bool complete = false;
            //флаг завершение алгоритма
            bool done = false;

            //создаем первый ход
            Move firstMove = CreateFirstMove();
            //добавляем узел в дерево решений
            SolutionThree solutionThree = new SolutionThree(firstMove, null, 0);

            //инициализируем список вершин дерева решений на текущем уровне
            List<SolutionThree> currentLevelNodes = new List<SolutionThree>();
            //и на следующем уровне
            List<SolutionThree> nextLevelNodes = new List<SolutionThree>();

            //заносим корневую ситуацию в список вершин текущего уровня
            currentLevelNodes.Add(solutionThree);

            //если корневой узел является целевым
            if (GoalIsReached(solutionThree))
            {
                //решение найдено
                complete = true;
               
            }
            //в противном случае начинаем алгоритм поиска
            else
            {
                //пока алгоритм не завершен выволняем действия
                while (!done)
                {
                    //рассматриваем каждый узел на текущем уровне
                    for (int i = 0; (i < currentLevelNodes.Count) && (!done); i++)
                    {
                        //получаем список возможных ходов
                        List<Move> availableMove = GetAvailableMoves(currentLevelNodes[i]);
                        //для каждого возможного хода
                        for (int j = 0; (j < availableMove.Count) && (!done); j++)
                        {
                            //совершаем ход
                            MakeMove(availableMove[j], currentLevelNodes[i]);
                            //добавляем его в дерево решений
                            currentLevelNodes[i].AddChildNode(availableMove[j]);
                            _Info.GeneratedNodesCount++;

                            SolutionThree newNode = currentLevelNodes[i].ChildNodes[currentLevelNodes[i].ChildNodes.Count - 1];
                            //запоминаем максимальную глубину поиска
                            _Info.MaxDepth = newNode.Level;

                            //если сгенерированный узел является целевым
                            if (GoalIsReached(newNode))
                            {
                                //решение найдено
                                complete = true;
                                //алгоритм завершен
                                done = true;
                                //запоминаем длину пути и получаем список ходов до цели
                                _Info.PathLenght = newNode.Level;
                                _Info.MovesToGoal = GetMovesToGoal(newNode);
                            }
                            else
                            {
                                //если сгенерированный узел не тупиковый, 
                                if (!Deadlock(newNode))
                                {
                                    //добавляем его в список узлов следующего уровня
                                    nextLevelNodes.Add(newNode);
                                }
                            }
                        }
                    }

                    //если решение не было достигнуто
                    if (!complete)
                    {
                        //если на следующем уровен нету узлов
                        if (nextLevelNodes.Count == 0)
                        {
                            //алгоритм закончен
                            done = true;
                        }
                        else
                        {
                            //если следующий уровень является максимально допустимым
                            if (nextLevelNodes[0].Level >= MaxAlowableDepth)
                            {
                                //алгоритм закончен
                                done = true;
                            }
                                //иначе
                            else
                            {
                                //переходим на следующий уровень
                                currentLevelNodes = nextLevelNodes;
                                nextLevelNodes = new List<SolutionThree>();
                            }
                        }
                    }

                }
            }

            //Фиксируем время выполнения
            _Info.ProcessTime.Stop();
            //Записываем результат выполнения
            _Info.Complete = complete;
            _Info.Method = "Поиск в ширину";
            

            //если решение было найдено
            if (complete)
            {
                //рассчитываем разветвленность и направленность
                _Info.Branching = (double)_Info.GeneratedNodesCount / (double)_Info.PathLenght;
                _Info.Directionality = Math.Pow(_Info.GeneratedNodesCount, ((double)1 / _Info.PathLenght));
            }
            //если решение небыло найдено
            else
            {
                //указываем что длина пути решения, разветвленность и направленность не вычеслены числом -1
                _Info.PathLenght = -1;
                _Info.Branching = -1;
                _Info.Directionality = -1;
            }

            return complete;
        }

        /// <summary>
        /// Метод наилучшего частичного пути
        /// </summary>
        /// <param name="parLocalDepth">Величина углубления в ширину</param>
        /// <returns></returns>
        public bool PartialPath(int parLocalDepth)
        {
            //Засекаем время
            _Info.ProcessTime = new Stopwatch();
            _Info.ProcessTime.Start();
            //Задаем начальные сведения
            _Info.MaxDepth = 0;
            _Info.PathLenght = 0;
            _Info.GeneratedNodesCount = 0;
            _Info.MovesToGoal = new List<Move>();


            //флаг нахождения решения
            bool complete = false;

            //создаем первый ход
            Move firstMove = CreateFirstMove();
            //добавляем узел в дерево решений
            SolutionThree solutionThree = new SolutionThree(firstMove, null, 0);

            complete = PartialPath(solutionThree, parLocalDepth);

            //Фиксируем время выполнения
            _Info.ProcessTime.Stop();
            //Записываем результат выполнения
            _Info.Complete = complete;
            _Info.Method = "Метод наилучшего частичного пути";


            //если решение было найдено
            if (complete)
            {
                //рассчитываем разветвленность и направленность
                _Info.Branching = (double)_Info.GeneratedNodesCount / (double)_Info.PathLenght;
                _Info.Directionality = Math.Pow(_Info.GeneratedNodesCount, ((double)1 / _Info.PathLenght));
            }
            //если решение небыло найдено
            else
            {
                //указываем что длина пути решения, разветвленность и направленность не вычеслены числом -1
                _Info.PathLenght = -1;
                _Info.Branching = -1;
                _Info.Directionality = -1;
            }

            return complete;
        }

        /// <summary>
        /// метод наилучшего частичного пути
        /// </summary>
        /// <param name="parSolutionThree">Корневой узел</param>
        /// <param name="parLocalDepth">величина углубления в ширину</param>
        /// <returns></returns>
        private bool PartialPath(SolutionThree parSolutionThree, int parLocalDepth)
        {
            //флаг нахождения решения
            bool complete = false;
            //флаг завершение алгоритма
            bool done = false;

            int localDepth = 0;

            SolutionThree solutionThree = parSolutionThree;

            //инициализируем список вершин дерева решений на текущем уровне
            List<SolutionThree> currentLevelNodes = new List<SolutionThree>();
            //и на следующем уровне
            List<SolutionThree> nextLevelNodes = new List<SolutionThree>();

            //заносим корневую ситуацию в список вершин текущего уровня
            currentLevelNodes.Add(solutionThree);


            //если корневой узел является целевым
            if (GoalIsReached(solutionThree))
            {
                //решение найдено
                complete = true;
            }
            //в противном случае начинаем алгоритм поиска
            else
            {
                //пока алгоритм не завершен выволняем действия
                while (!done)
                {
                    //рассматриваем каждый узел на текущем уровне
                    for (int i = 0; (i < currentLevelNodes.Count) && (!done); i++)
                    {

                        //если пора углубляться
                        if (localDepth == parLocalDepth)
                        {
                            complete = PartialPath(currentLevelNodes[i], parLocalDepth);
                            done = complete;
                            currentLevelNodes[i] = null;
                        }
                        else
                        {
                            //получаем список возможных ходов
                            List<Move> availableMove = GetAvailableMoves(currentLevelNodes[i]);


                            //для каждого возможного хода
                            for (int j = 0; (j < availableMove.Count) && (!done); j++)
                            {
                                //совершаем ход
                                MakeMove(availableMove[j], currentLevelNodes[i]);
                                //добавляем его в дерево решений
                                currentLevelNodes[i].AddChildNode(availableMove[j]);
                                _Info.GeneratedNodesCount++;

                                SolutionThree newNode = currentLevelNodes[i].ChildNodes[currentLevelNodes[i].ChildNodes.Count - 1];
                                //запоминаем максимальную глубину поиска
                                _Info.MaxDepth = newNode.Level;


                                //если сгенерированный узел является целевым
                                if (GoalIsReached(newNode))
                                {
                                    //решение найдено
                                    complete = true;
                                    //алгоритм завершен
                                    done = true;
                                    //запоминаем длину пути и получаем список ходов до цели
                                    _Info.PathLenght = newNode.Level;
                                    _Info.MovesToGoal = GetMovesToGoal(newNode);
                                }
                                else
                                {
                                    //если сгенерированный узел не тупиковый, 
                                    if (!Deadlock(newNode))
                                    {
                                        //добавляем его в список узлов следующего уровня
                                        nextLevelNodes.Add(newNode);
                                    }
                                }
                            }
                        }
                    }

                    //если решение не было достигнуто
                    if (!complete)
                    {
                        //если на следующем уровен нету узлов
                        if (nextLevelNodes.Count == 0)
                        {
                            //алгоритм закончен
                            done = true;
                        }
                        else
                        {
                            //если следующий уровень является максимально допустимым
                            if (nextLevelNodes[0].Level >= MaxAlowableDepth)
                            {
                                //алгоритм закончен
                                done = true;
                            }
                            //иначе
                            else
                            {
                                //переходим на следующий уровень
                                currentLevelNodes = nextLevelNodes;
                                nextLevelNodes = new List<SolutionThree>();
                                localDepth++;

                                if (localDepth == parLocalDepth)
                                {
                                    //сортируем по оценочной функции
                                    SortThreeNodes(currentLevelNodes);
                                }

                            }
                        }
                    }

                }
            }

            return complete;
        }
        
        /// <summary>
        /// Поиск в ширину
        /// </summary>
        /// <returns></returns>
        public bool UniformCostSolve()
        {
            //Засекаем время
            _Info.ProcessTime = new Stopwatch();
            _Info.ProcessTime.Start();
            //Задаем начальные сведения
            _Info.MaxDepth = 0;
            _Info.PathLenght = 0;
            _Info.GeneratedNodesCount = 0;
            _Info.MovesToGoal = new List<Move>();


            //флаг нахождения решения
            bool complete = false;
            //флаг завершение алгоритма
            bool done = false;

            //создаем первый ход
            Move firstMove = CreateFirstMove();
            //добавляем узел в дерево решений
            SolutionThree solutionThree = new SolutionThree(firstMove, null, 0);

            List<Situation> situations = new List<Situation>();

            //инициализируем список вершин дерева решений на текущем уровне
            List<SolutionThree> currentLevelNodes = new List<SolutionThree>();
            //и на следующем уровне
            List<SolutionThree> nextLevelNodes = new List<SolutionThree>();

            //заносим корневую ситуацию в список вершин текущего уровня
            currentLevelNodes.Add(solutionThree);
            //создаем исходную ситуацию
            situations.Add(new Situation(solutionThree.Move.Mirrors));

            //если корневой узел является целевым
            if (GoalIsReached(solutionThree))
            {
                //решение найдено
                complete = true;

            }
            //в противном случае начинаем алгоритм поиска
            else
            {
                //пока алгоритм не завершен выволняем действия
                while (!done)
                {
                    //рассматриваем каждый узел на текущем уровне
                    for (int i = 0; (i < currentLevelNodes.Count) && (!done); i++)
                    {
                        //получаем список возможных ходов
                        List<Move> availableMove = GetAvailableMoves(currentLevelNodes[i]);

                        //для каждого возможного хода
                        for (int j = 0; (j < availableMove.Count) && (!done); j++)
                        {
                            //совершаем ход
                            MakeMove(availableMove[j], currentLevelNodes[i]);
                            //добавляем его в дерево решений
                            currentLevelNodes[i].AddChildNode(availableMove[j]);
                            _Info.GeneratedNodesCount++;

                            SolutionThree newNode = currentLevelNodes[i].ChildNodes[currentLevelNodes[i].ChildNodes.Count - 1];
                            //запоминаем максимальную глубину поиска
                            _Info.MaxDepth = newNode.Level;

                            //если такой ситуации еще небыло
                            if (!IsExistsSituation(situations, newNode))
                            {
                                //если сгенерированный узел является целевым
                                if (GoalIsReached(newNode))
                                {
                                    //решение найдено
                                    complete = true;
                                    //алгоритм завершен
                                    done = true;
                                    //запоминаем длину пути и получаем список ходов до цели
                                    _Info.PathLenght = newNode.Level;
                                    _Info.MovesToGoal = GetMovesToGoal(newNode);
                                }
                                else
                                {
                                    //если сгенерированный узел не тупиковый, 
                                    if (!Deadlock(newNode))
                                    {
                                        //добавляем его в список узлов следующего уровня
                                        nextLevelNodes.Add(newNode);
                                        //добавляем новую ситуацию
                                        situations.Add(new Situation(newNode.Move.Mirrors));
                                    }
                                }
                            }
                        }
                    }

                    //если решение не было достигнуто
                    if (!complete)
                    {
                        //если на следующем уровен нету узлов
                        if (nextLevelNodes.Count == 0)
                        {
                            //алгоритм закончен
                            done = true;
                        }
                        else
                        {
                            //если следующий уровень является максимально допустимым
                            if (nextLevelNodes[0].Level >= MaxAlowableDepth)
                            {
                                //алгоритм закончен
                                done = true;
                            }
                            //иначе
                            else
                            {
                                //переходим на следующий уровень
                                currentLevelNodes = nextLevelNodes;
                                nextLevelNodes = new List<SolutionThree>();
                            }
                        }
                    }

                }
            }

            //Фиксируем время выполнения
            _Info.ProcessTime.Stop();
            //Записываем результат выполнения
            _Info.Complete = complete;
            _Info.Method = "Стратегия равных цен";


            //если решение было найдено
            if (complete)
            {
                //рассчитываем разветвленность и направленность
                _Info.Branching = (double)_Info.GeneratedNodesCount / (double)_Info.PathLenght;
                _Info.Directionality = Math.Pow(_Info.GeneratedNodesCount, ((double)1 / _Info.PathLenght));
            }
            //если решение небыло найдено
            else
            {
                //указываем что длина пути решения, разветвленность и направленность не вычеслены числом -1
                _Info.PathLenght = -1;
                _Info.Branching = -1;
                _Info.Directionality = -1;
            }

            return complete;
        }

        /// <summary>
        /// Получение ходов до целевой вершины
        /// </summary>
        /// <param name="parSolutionNode">целевая вершина</param>
        /// <returns></returns>
        private List<Move> GetMovesToGoal(SolutionThree parSolutionNode)
        {

            List<Move> movesToGoal = new List<Move>();
            SolutionThree currentSolutionNode  = parSolutionNode;

            while (currentSolutionNode.Root != null)
            {
                movesToGoal.Insert(0, currentSolutionNode.Move);
                currentSolutionNode = currentSolutionNode.Root;
            }

            return movesToGoal;
        }
       
        /// <summary>
        /// Создание Первого хода
        /// </summary>
        /// <returns></returns>
        abstract public Move CreateFirstMove();
        
        /// <summary>
        /// Определение достижения цели
        /// </summary>
        /// <param name="parSolutionThree">проверяемый узел дерева</param>
        /// <returns>true - если вершина целевая</returns>
        abstract public bool GoalIsReached(SolutionThree parSolutionThree);

        /// <summary>
        /// Определение тупика в указанной вершине
        /// </summary>
        /// <param name="parSolutionThree">проверяемая вершина дерева</param>
        /// <returns>true - если вершина тупиковая</returns>
        abstract public bool Deadlock(SolutionThree parSolutionThree);
        
        /// <summary>
        /// ПОлучение списка возможных ходов из указанной вершины дерева
        /// </summary>
        /// <param name="parSolutionThree">вершина дерева</param>
        /// <returns>Список возможных ходов</returns>
        abstract public List<Move> GetAvailableMoves(SolutionThree parSolutionThree);

        /// <summary>
        /// Сортировка списка возможных ходов согласно оценочной функции
        /// </summary>
        /// <param name="parAvailableMoves"></param>
        /// <param name="parSolutionThree"> узелд дерева из которого совершается ход</param>
        abstract public void SortMoves(List<Move> parAvailableMoves, SolutionThree parSolutionThree);

        /// <summary>
        /// Сортировка сгенерированных узлов дерева по оценочной функции
        /// </summary>
        /// <param name="parThreeNodes"></param>
        abstract public void SortThreeNodes(List<SolutionThree> parThreeNodes);
        
        /// <summary>
        /// Оценочная функция
        /// </summary>
        /// <param name="parMove">оцениваемый ход</param>
        /// <param name="parSolutionThree"> узелд дерева из которого совершается ход</param>
        /// <returns>оценка хода</returns>
        abstract public int Estimator(Move parMove, SolutionThree parSolutionThree);

        /// <summary>
        /// Определение существования указанной ситуации
        /// </summary>
        /// <param name="parSolutionThree">вершина дерева решиня с проверяемой ситуацией</param>
        /// <returns></returns>
        abstract public bool IsExistsSituation(List<Situation> parSituations, SolutionThree parSolutionThree);

        /// <summary>
        /// Совершение хода
        /// </summary>
        /// <param name="parMove">Ход</param>
        /// <param name="parSolutionThree"> узелд дерева из которого совершается ход</param>
        abstract public void MakeMove(Move parMove, SolutionThree parSolutionThree);
        
        /// <summary>
        /// Отмена хода
        /// </summary>
        /// <param name="parMove">Ход</param>
        /// <param name="parSolutionThree">узел дерева у которого отменяется ход</param>
        abstract public void CancelMove(Move parMove, SolutionThree parSolutionThree);
      
    }
}
