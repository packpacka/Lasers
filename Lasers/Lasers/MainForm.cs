using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Lasers;

namespace Lasers
{
    /// <summary>
    /// Класс главной формы
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Действие
        /// </summary>
        private enum Action
        {
            ChangeDim,
            ChangeLaser,
            ChangeMirrors,
            ChangeHoles,
            ChangeGoals,
            None
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
        /// Задача
        /// </summary>
        private LasersGame _Game;
        /// <summary>
        /// Лазер
        /// </summary>
        private LaserSource _Laser;
        /// <summary>
        /// Дыры на поле
        /// </summary>
        private List<Point> _Mirrors;
        /// <summary>
        /// Дыры на поле
        /// </summary>
        private List<Point> _Holes;
        /// <summary>
        /// Целевые точки
        /// </summary>
        private List<Point> _Goals;

        /// <summary>
        /// Текущее действие
        /// </summary>
        private Action _Action;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        
            _Laser = new LaserSource(new Point((int)numericUpDownLaserPosX.Value,(int)numericUpDownLaserPosY.Value), new Point(5,5));
            _Mirrors = new List<Point>();
            _Holes = new List<Point>();
            _Goals = new List<Point>();

            _Game = new LasersGame(_FieldWidth, _FieldHeight);

            timer1.Start();
        }


        /// <summary>
        /// Изменение ширины поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownWidhField_ValueChanged(object sender, EventArgs e)
        {
            _FieldWidth = (int)numericUpDownWidhField.Value;
            
            numericUpDownLaserPosX.Maximum = _FieldWidth;
            _Action = Action.ChangeDim;
        }
        
        /// <summary>
        /// Именение высоты поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownHeightField_ValueChanged(object sender, EventArgs e)
        {
            _FieldHeight = (int)numericUpDownHeightField.Value;
         
            numericUpDownLaserPosY.Maximum = _FieldHeight;
            _Action = Action.ChangeDim;
        }
        
        /// <summary>
        /// Изменение положения лазера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownLaserPosX_ValueChanged(object sender, EventArgs e)
        {
            _Action = Action.ChangeLaser;
        }
        
        /// <summary>
        /// Изменение положения лазера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownLaserPosY_ValueChanged(object sender, EventArgs e)
        {
            _Action = Action.ChangeLaser;
        }
        
        /// <summary>
        /// Изменение направления лазера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton45_CheckedChanged(object sender, EventArgs e)
        {
            _Action = Action.ChangeLaser;
        }
        
        /// <summary>
        /// Изменение направления лазера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton135_CheckedChanged(object sender, EventArgs e)
        {
            _Action = Action.ChangeLaser;
        }
        
        /// <summary>
        /// Изменение направления лазера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton225_CheckedChanged(object sender, EventArgs e)
        {
            _Action = Action.ChangeLaser;
        }
        
        /// <summary>
        /// Изменение направления лазера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton315_CheckedChanged(object sender, EventArgs e)
        {
            _Action = Action.ChangeLaser;
        }

        /// <summary>
        /// Вывести список зеркал
        /// </summary>
        private void OutMirrorsList()
        {
            dataGridViewMirrors.Rows.Clear();

            for (int i = 0; i < _Mirrors.Count; i++)
            {
                dataGridViewMirrors.Rows.Add(_Mirrors[i].X, _Mirrors[i].Y);
            }
        }

        /// <summary>
        /// Вывести список дыр
        /// </summary>
        public void OutHolesList()
        {
            
            dataGridViewHoles.Rows.Clear();

            for (int i = 0; i < _Holes.Count; i++)
            {
                dataGridViewHoles.Rows.Add(_Holes[i].X, _Holes[i].Y);
            }
        }

        /// <summary>
        /// Вывести список целевых точек
        /// </summary>
        public void OutGoalsList()
        {
            
            dataGridViewGoals.Rows.Clear();

            for (int i = 0; i < _Goals.Count; i++)
            {
                dataGridViewGoals.Rows.Add(_Goals[i].X, _Goals[i].Y);
            }

        }

        /// <summary>
        /// Задать зеркала в объект игры
        /// </summary>
        private void SetMirrors()
        {
            bool availableValues = true;
            try
            {
                _Mirrors.Clear();

                for (int i = 0; (i < dataGridViewMirrors.RowCount - 1) && (availableValues); i++)
                {
                    int x = Convert.ToInt32(dataGridViewMirrors.Rows[i].Cells[0].Value);
                    int y = Convert.ToInt32(dataGridViewMirrors.Rows[i].Cells[1].Value);

                    if ((x % LasersGame.COORDINATE_RATIO != 0) || (y % LasersGame.COORDINATE_RATIO != 0))
                    {
                        MessageBox.Show("Координаты зеркал должны быть кратны " + LasersGame.COORDINATE_RATIO.ToString());
                        availableValues = false;
                    }
                    else
                        if ((x >= _FieldWidth) || (y >= _FieldHeight))
                        {
                            MessageBox.Show("Координаты зеркал должны находиться в пределах размеров поля ");
                            availableValues = false;
                        }
                        else
                        {
                            _Mirrors.Add(new Point(x, y));
                        }
                }

                if (availableValues)
                {
                    _Game.ClearMirrors();
                    _Game.AddMirror(_Mirrors);

                    _Mirrors = _Game.GetMirrors();
                    _Holes = _Game.GetHoles();
                    _Goals = _Game.GetGoals();

                    OutMirrorsList();
                    OutHolesList();
                    OutGoalsList();
                    _Action = Action.None;
                }


            }
            catch
            {
                MessageBox.Show("Введите корректные данные");
            }
        }

        /// <summary>
        /// Задать дыры в объект игры
        /// </summary>
        private void SetHoles()
        {
            bool availableValues = true;
            try
            {
                _Holes.Clear();

                for (int i = 0; (i < dataGridViewHoles.RowCount - 1) && (availableValues); i++)
                {
                    int x = Convert.ToInt32(dataGridViewHoles.Rows[i].Cells[0].Value);
                    int y = Convert.ToInt32(dataGridViewHoles.Rows[i].Cells[1].Value);

                    if ((x % LasersGame.COORDINATE_RATIO != 0) || (y % LasersGame.COORDINATE_RATIO != 0))
                    {
                        MessageBox.Show("Координаты дыр должны быть кратны " + LasersGame.COORDINATE_RATIO.ToString());
                        availableValues = false;
                    }
                    else
                        if ((x >= _FieldWidth) || (y >= _FieldHeight))
                        {
                            MessageBox.Show("Координаты дыр должны находиться в пределах размеров поля ");
                            availableValues = false;
                        }
                        else
                        {
                            _Holes.Add(new Point(x, y));
                        }
                }

                if (availableValues)
                {
                    _Game.ClearHoles();
                    _Game.AddHole(_Holes);


                    _Mirrors = _Game.GetMirrors();
                    _Holes = _Game.GetHoles();
                    _Goals = _Game.GetGoals();

                    OutMirrorsList();
                    OutHolesList();
                    OutGoalsList();
                    _Action = Action.None;
                }


            }
            catch
            {
                MessageBox.Show("Введите корректные данные");
            }
        }

        /// <summary>
        /// Задать Цели в объект игры
        /// </summary>
        private void SetGoals()
        {
            bool availableValues = true;
            try
            {
                _Goals.Clear();

                for (int i = 0; (i < dataGridViewGoals.RowCount - 1) && (availableValues); i++)
                {
                    int x = Convert.ToInt32(dataGridViewGoals.Rows[i].Cells[0].Value);
                    int y = Convert.ToInt32(dataGridViewGoals.Rows[i].Cells[1].Value);

                    if (!(
                        ((x % LasersGame.COORDINATE_RATIO == 0) && (y % LasersGame.COORDINATE_RATIO != 0)) ||
                        ((x % LasersGame.COORDINATE_RATIO != 0) && (y % LasersGame.COORDINATE_RATIO == 0))
                        ))
                    {
                        MessageBox.Show("Одна из координат целевой точки должна быть кратна " + LasersGame.COORDINATE_RATIO.ToString() +
                                         ", вторая - кратна " + LasersGame.COORDINATE_RATIO / 2);
                        availableValues = false;
                    }
                    else
                        if ((x > _FieldWidth) || (y > _FieldHeight))
                        {
                            MessageBox.Show("Координаты дыр должны находиться в пределах размеров поля ");
                            availableValues = false;
                        }
                        else
                        {
                            _Goals.Add(new Point(x, y));
                        }
                }

                if (availableValues)
                {
                    _Game.ClearGoals();
                    _Game.AddGoal(_Goals);


                    _Mirrors = _Game.GetMirrors();
                    _Holes = _Game.GetHoles();
                    _Goals = _Game.GetGoals();

                    OutMirrorsList();
                    OutHolesList();
                    OutGoalsList();

                    _Action = Action.None;
                }


            }
            catch
            {
                MessageBox.Show("Введите корректные данные");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_Action == Action.None)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                dataGridViewMirrors.Enabled = true;
                dataGridViewHoles.Enabled = true;
                dataGridViewGoals.Enabled = true;
                buttonApply.Enabled = false;
                buttonCancel.Enabled = false;
            }
            if (_Action == Action.ChangeDim)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                dataGridViewMirrors.Enabled = false;
                dataGridViewHoles.Enabled = false;
                dataGridViewGoals.Enabled = false;
                buttonApply.Enabled = true;
                buttonCancel.Enabled = true;
            }
            if (_Action == Action.ChangeLaser)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
                dataGridViewMirrors.Enabled = false;
                dataGridViewHoles.Enabled = false;
                dataGridViewGoals.Enabled = false;
                buttonApply.Enabled = true;
                buttonCancel.Enabled = true;
            }
            if (_Action == Action.ChangeMirrors)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                dataGridViewMirrors.Enabled = true;
                dataGridViewHoles.Enabled = false;
                dataGridViewGoals.Enabled = false;
                buttonApply.Enabled = true;
                buttonCancel.Enabled = true;
            }
            if (_Action == Action.ChangeHoles)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                dataGridViewMirrors.Enabled = false;
                dataGridViewHoles.Enabled = true;
                dataGridViewGoals.Enabled = false;
                buttonApply.Enabled = true;
                buttonCancel.Enabled = true;
            }
            if (_Action == Action.ChangeGoals)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                dataGridViewMirrors.Enabled = false;
                dataGridViewHoles.Enabled = false;
                dataGridViewGoals.Enabled = true;
                buttonApply.Enabled = true;
                buttonCancel.Enabled = true;
            }
        }
        
        /// <summary>
        /// Нажати кнопки "Применить параметры"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (_Action == Action.ChangeDim)
            {
                _FieldWidth = (int)numericUpDownWidhField.Value;
                _FieldHeight = (int)numericUpDownHeightField.Value;

                _Game.FieldHeight = _FieldHeight;
                _Game.FieldWidth = _FieldWidth;

                OutMirrorsList();
                OutHolesList();
                OutGoalsList();

                _Action = Action.None;
            }
            if (_Action == Action.ChangeLaser)
            {
                int x = (int)numericUpDownLaserPosX.Value;
                int y = (int)numericUpDownLaserPosY.Value;
                if (!(
                        ((x % LasersGame.COORDINATE_RATIO == 0) && (y % LasersGame.COORDINATE_RATIO != 0)) ||
                        ((x % LasersGame.COORDINATE_RATIO != 0) && (y % LasersGame.COORDINATE_RATIO == 0))
                        ))
                {
                    MessageBox.Show("Одна из координат лазера должна быть кратна " + LasersGame.COORDINATE_RATIO.ToString() +
                                     ", вторая - кратна " + LasersGame.COORDINATE_RATIO / 2);
                }
                else
                {
                    _Laser.Position = new Point(x, y);

                    if (radioButton45.Checked)
                    {
                        _Laser.Vector = new Point(5, 5);
                    }
                    if (radioButton135.Checked)
                    {
                        _Laser.Vector = new Point(-5, 5);
                    }
                    if (radioButton225.Checked)
                    {
                        _Laser.Vector = new Point(-5, -5);
                    }
                    if (radioButton315.Checked)
                    {
                        _Laser.Vector = new Point(5, -5);
                    }
                    _Game.SetUpLaser(_Laser);
                    _Action = Action.None;
                }
            }
            if (_Action == Action.ChangeMirrors)
            {
                SetMirrors();
            }
            if (_Action == Action.ChangeHoles)
            {
                SetHoles();
            }
            if (_Action == Action.ChangeGoals)
            {
                SetGoals();
            }
        }

        /// <summary>
        /// Нажатие кнопки "Отменить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _FieldHeight = _Game.FieldHeight;
            _FieldWidth = _Game.FieldWidth;
            numericUpDownHeightField.Value = _FieldHeight;
            numericUpDownWidhField.Value = _FieldWidth;

            _Laser = _Game.Laser.LaserSource;
            numericUpDownLaserPosX.Value = _Laser.Position.X;
            numericUpDownLaserPosY.Value = _Laser.Position.Y;
            if (_Laser.Vector == new Point(5, 5)) { radioButton45.Checked = true; }
            if (_Laser.Vector == new Point(-5, 5)) { radioButton135.Checked = true; }
            if (_Laser.Vector == new Point(-5, -5)) { radioButton225.Checked = true; }
            if (_Laser.Vector == new Point(5, -5)) { radioButton315.Checked = true; }


            OutMirrorsList();
            OutHolesList();
            OutGoalsList();

            _Action = Action.None;
        }
        
        /// <summary>
        /// Изменение списка зеркал
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewMirrors_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _Action = Action.ChangeMirrors;
        }
        
        /// <summary>
        /// Изменение списка дыр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewHoles_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _Action = Action.ChangeHoles;
        }
        
        /// <summary>
        /// Изменение списка целей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewGoals_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _Action = Action.ChangeGoals;
        }
        
        /// <summary>
        /// Нажатие кнопки "Сохранить пример"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();

            try
            {
                using (FileStream fs = File.Create(sfd.FileName))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, _Game);
                }
            }
            catch
            {
                MessageBox.Show("Задача не сохранена");
            }
        }
        
        /// <summary>
        /// Нажатие кнопки "Загрузить пример"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                using (FileStream fs = File.Open(ofd.FileName, FileMode.Open))
                {
                    _Game = null;
                    BinaryFormatter formatter = new BinaryFormatter();
                    _Game = (LasersGame)formatter.Deserialize(fs);
                }

                _FieldHeight = _Game.FieldHeight;
                _FieldWidth = _Game.FieldWidth;
                numericUpDownHeightField.Value = _FieldHeight;
                numericUpDownWidhField.Value = _FieldWidth;

                _Laser = _Game.Laser.LaserSource;
                numericUpDownLaserPosX.Value = _Laser.Position.X;
                numericUpDownLaserPosY.Value = _Laser.Position.Y;
                if (_Laser.Vector == new Point(5, 5)) { radioButton45.Checked = true; }
                if (_Laser.Vector == new Point(-5, 5)) { radioButton135.Checked = true; }
                if (_Laser.Vector == new Point(-5, -5)) { radioButton225.Checked = true; }
                if (_Laser.Vector == new Point(5, -5)) { radioButton315.Checked = true; }


                _Mirrors = _Game.GetMirrors();
                _Holes = _Game.GetHoles();
                _Goals = _Game.GetGoals();
                OutMirrorsList();
                OutHolesList();
                OutGoalsList();

                _Action = Action.None;
            }
            catch
            {
                MessageBox.Show("Пример не был загружен");
            }
        }

        /// <summary>
        /// Запись результатов решения в файл
        /// </summary>
        /// <param name="parLog"></param>
        /// <param name="parPath"></param>
        private void WriteLog(LaserGameSolver.SolveResult parLog, string parPath)
        {
            StreamWriter sw = new StreamWriter(parPath);
            string result = parLog.Complete ? "РЕШЕНИЕ НАЙДЕНО" : "РЕШЕНИЕ НЕ НАЙДЕНО";

            sw.WriteLine("Метод решения - " + parLog.Method);
            sw.WriteLine("Статус выполнения - " + result);
            sw.WriteLine("Время выполнения - " + parLog.ProcessTime.Elapsed);
            sw.WriteLine("Максимальная глубина поиска - " + parLog.MaxDepth);
            sw.WriteLine("Количество сгенерированных узлов - " + parLog.GeneratedNodesCount);
            sw.WriteLine("Длина пути решения - " + parLog.PathLenght);
            sw.WriteLine("Направленность - " + parLog.Directionality);
            sw.WriteLine("Разветвелнность - " + parLog.Branching);
            sw.WriteLine("");
            sw.WriteLine("ШАГИ: ");
            for (int i = 0; i < parLog.MovesToGoal.Count; i++)
            {
                sw.WriteLine(parLog.MovesToGoal[i].FromPos + " -> " + parLog.MovesToGoal[i].ToPos);
            }
            sw.Close();
        }

        /// <summary>
        /// Нажати кнопки "Поиск в глубину"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDepth_Click(object sender, EventArgs e)
        {
            SetMirrors();
            SetHoles();
            SetGoals();


            LaserGameSolver solver = new LaserGameSolver(_Game);
            solver.MaxAlowableDepth = (int)numericUpDownMaxDepth.Value;

            solver.DepthSolve();

            WriteLog(solver.Info, "DepthInfo.txt");

            //создаем форму сведений о выполнении 
            FormLog logForm = new FormLog();
            logForm.Show();
            //и заносим туда данные
            logForm.FillLogForm("DepthInfo.txt");

            dataGridView1.Rows.Clear();
            for (int i = 0; i < solver.Task.Mirrors.Count; i++)
            {
                dataGridView1.Rows.Add(solver.Task.Mirrors[i].Left, solver.Task.Mirrors[i].Top);
            }
        }
        
        /// <summary>
        /// Нажатие кнопки вызова информации о поиске в глубину
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDepthInfo_Click(object sender, EventArgs e)
        {
            //создаем форму сведений о выполнении 
            FormLog logForm = new FormLog();
            logForm.Show();
            //и заносим туда данные
            logForm.FillLogForm("DepthInfo.txt");
        }
        
        /// <summary>
        /// Нажатие кнопки "Поиск в ширину"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBreadth_Click(object sender, EventArgs e)
        {
            SetMirrors();
            SetHoles();
            SetGoals();


            LaserGameSolver solver = new LaserGameSolver(_Game);
            solver.MaxAlowableDepth = (int)numericUpDownMaxDepth.Value;

            solver.BreadthSolve();

            WriteLog(solver.Info, "BreadthInfo.txt");

            //создаем форму сведений о выполнении 
            FormLog logForm = new FormLog();
            logForm.Show();
            //и заносим туда данные
            logForm.FillLogForm("BreadthInfo.txt");

            dataGridView1.Rows.Clear();
            for (int i = 0; i < solver.Task.Mirrors.Count; i++)
            {
                dataGridView1.Rows.Add(solver.Task.Mirrors[i].Left, solver.Task.Mirrors[i].Top);
            }
        }
        
        /// <summary>
        /// Нажатие кнопки вызова информации о поиске в ширину
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBreadthInfo_Click(object sender, EventArgs e)
        {
            //создаем форму сведений о выполнении 
            FormLog logForm = new FormLog();
            logForm.Show();
            //и заносим туда данные
            logForm.FillLogForm("BreadthInfo.txt");
        }

        private void buttonGradient_Click(object sender, EventArgs e)
        {
            SetMirrors();
            SetHoles();
            SetGoals();


            LaserGameSolver solver = new LaserGameSolver(_Game);
            solver.MaxAlowableDepth = (int)numericUpDownMaxDepth.Value;

            solver.SteepestRiseSolve();

            WriteLog(solver.Info, "GradientInfo.txt");

            //создаем форму сведений о выполнении 
            FormLog logForm = new FormLog();
            logForm.Show();
            //и заносим туда данные
            logForm.FillLogForm("GradientInfo.txt");

            dataGridView1.Rows.Clear();
            for (int i = 0; i < solver.Task.Mirrors.Count; i++)
            {
                dataGridView1.Rows.Add(solver.Task.Mirrors[i].Left, solver.Task.Mirrors[i].Top);
            }
        }

        private void buttonGradientInfo_Click(object sender, EventArgs e)
        {
            //создаем форму сведений о выполнении 
            FormLog logForm = new FormLog();
            logForm.Show();
            //и заносим туда данные
            logForm.FillLogForm("GradientInfo.txt");
        }

        private void buttonPartialPath_Click(object sender, EventArgs e)
        {
            SetMirrors();
            SetHoles();
            SetGoals();


            LaserGameSolver solver = new LaserGameSolver(_Game);
            solver.MaxAlowableDepth = (int)numericUpDownMaxDepth.Value;

            solver.PartialPath((int)numericUpDownLocaDepth.Value);

            WriteLog(solver.Info, "PartialPathInfo.txt");

            //создаем форму сведений о выполнении 
            FormLog logForm = new FormLog();
            logForm.Show();
            //и заносим туда данные
            logForm.FillLogForm("PartialPathInfo.txt");

            dataGridView1.Rows.Clear();
            for (int i = 0; i < solver.Task.Mirrors.Count; i++)
            {
                dataGridView1.Rows.Add(solver.Task.Mirrors[i].Left, solver.Task.Mirrors[i].Top);
            }
        }

        private void buttonPartialPathInfo_Click(object sender, EventArgs e)
        {
            //создаем форму сведений о выполнении 
            FormLog logForm = new FormLog();
            logForm.Show();
            //и заносим туда данные
            logForm.FillLogForm("PartialPathInfo.txt");
        }

        private void buttonUniCost_Click(object sender, EventArgs e)
        {
            SetMirrors();
            SetHoles();
            SetGoals();


            LaserGameSolver solver = new LaserGameSolver(_Game);
            solver.MaxAlowableDepth = (int)numericUpDownMaxDepth.Value;

            solver.UniformCostSolve();

            WriteLog(solver.Info, "UniCostInfo.txt");

            //создаем форму сведений о выполнении 
            FormLog logForm = new FormLog();
            logForm.Show();
            //и заносим туда данные
            logForm.FillLogForm("UniCostInfo.txt");

            dataGridView1.Rows.Clear();
            for (int i = 0; i < solver.Task.Mirrors.Count; i++)
            {
                dataGridView1.Rows.Add(solver.Task.Mirrors[i].Left, solver.Task.Mirrors[i].Top);
            }
        }

        private void buttonUniCostInfo_Click(object sender, EventArgs e)
        {
            //создаем форму сведений о выполнении 
            FormLog logForm = new FormLog();
            logForm.Show();
            //и заносим туда данные
            logForm.FillLogForm("UniCostInfo.txt");
        }

    }
}
