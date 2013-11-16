using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lasers
{
    /// <summary>
    /// Класс квадрат
    /// </summary>
    [Serializable]
    public class Square
    {
        /// <summary>
        /// Координата верхней грани
        /// </summary>
        private int _Top;

       
        /// <summary>
        /// Координата нижней грани
        /// </summary>
        private int _Down;

        
        /// <summary>
        /// Координата левой грани
        /// </summary>
        private int _Left;

       
        /// <summary>
        /// Координата правой грани
        /// </summary>
        private int _Right;



        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parTop">Координата нижней грани</param>
        /// <param name="parDown">Координата верхней грани</param>
        /// <param name="parLeft">Координата левой грани</param>
        /// <param name="parRight">Координата правой грани</param>
        public Square(int parTop, int parDown, int parLeft, int parRight)
        {
            _Top = parTop;
            _Down = parDown;
            _Left = parLeft;
            _Right = parRight;
        }

        /// <summary>
        /// Получить копию объекта
        /// </summary>
        /// <returns></returns>
        public Square Clone()
        {
            return new Square(_Top, _Down, _Left, _Right);
        }

        /// <summary>
        /// Координата правой грани
        /// </summary>
        public int Top
        {
            get { return _Top; }
            set { _Top = value; }
        }
        /// <summary>
        /// Координата нижней грани
        /// </summary>
        public int Down
        {
            get { return _Down; }
            set { _Down = value; }
        }
        /// <summary>
        /// Координата верхней грани
        /// </summary>
        public int Left
        {
            get { return _Left; }
            set { _Left = value; }
        }
        /// <summary>
        /// Координата левой грани
        /// </summary>
        public int Right
        {
            get { return _Right; }
            set { _Right = value; }
        }


    }
}
