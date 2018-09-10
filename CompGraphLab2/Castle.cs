using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace CompGraphLab1
{
    /// <summary>
    /// Класс для отрисовки замка
    /// </summary>
    class Castle
    {
        /// <summary>
        /// Содержит все отрисовываемые объекты
        /// </summary>
        DrawingObject[] drawingObjects;

        /// <summary>
        /// Создает отрисовываемые объекты
        /// </summary>
        public Castle()
        {

            DrawingObject wall1 = new DrawingObject()
            {
                matrix = new int[,]{
                { -15,  10,     -15,   1},
                { -13,  10,     -15,   1},
                { -13,  8,      -15,   1},
                { -9,   8,      -15,   1},
                { -9,   10,     -15,   1},
                { -7,   10,     -15,   1},
                { -7,   0,      -15,   1},
                { 7,    0,      -15,   1},
                { 7,    10,     -15,   1},
                { 9,    10,     -15,   1},
                { 9,    8,      -15,   1},
                { 13,   8,      -15,   1},
                { 13,   10,     -15,   1},
                { 15,   10,     -15,   1},
                { 15,   -14,    -15,   1},
                { 5,    -14,    -15,   1},
                { 5,    -4,     -15,   1},
                { -5,   -4,     -15,   1},
                { -5,   -14,    -15,   1},
                { -15,  -14,    -15,   1},
                { -15,  10,     -15,   1},
                }
            };
            DrawingObject wall2 = new DrawingObject()
            {
                matrix = new int[,]{
                { 15,  10,     -15,   1},
                { 15,  10,     -13,   1},
                { 15,  8,      -13,   1},
                { 15,  8,      -9,    1},
                { 15,  10,     -9,    1},
                { 15,  10,     -7,    1},
                { 15,  0,      -7,    1},
                { 15,  0,      7,     1},
                { 15,  10,     7,     1},
                { 15,  10,     9,     1},
                { 15,  8,      9,     1},
                { 15,  8,      13,    1},
                { 15,  10,     13,    1},
                { 15,  10,     15,    1},
                { 15,  -14,    15,    1},
                { 15,  -14,    -15,   1},
                { 15,  10,     -15,   1},
                }
            };
            DrawingObject wall3 = new DrawingObject()
            {
                matrix = new int[,]{
                { -15,  10,     15,   1},
                { -13,  10,     15,   1},
                { -13,  8,      15,   1},
                { -9,   8,      15,   1},
                { -9,   10,     15,   1},
                { -7,   10,     15,   1},
                { -7,   0,      15,   1},
                { 7,    0,      15,   1},
                { 7,    10,     15,   1},
                { 9,    10,     15,   1},
                { 9,    8,      15,   1},
                { 13,   8,      15,   1},
                { 13,   10,     15,   1},
                { 15,   10,     15,   1},
                { 15,   -14,    15,   1},
                { -15,  -14,    15,   1},
                { -15,  10,     15,   1},
                }
            };
            DrawingObject wall4 = new DrawingObject()
            {
                matrix = new int[,]{
                { -15,  10,     -15,   1},
                { -15,  10,     -13,   1},
                { -15,  8,      -13,   1},
                { -15,  8,      -9,    1},
                { -15,  10,     -9,    1},
                { -15,  10,     -7,    1},
                { -15,  0,      -7,    1},
                { -15,  0,      7,     1},
                { -15,  10,     7,     1},
                { -15,  10,     9,     1},
                { -15,  8,      9,     1},
                { -15,  8,      13,    1},
                { -15,  10,     13,    1},
                { -15,  10,     15,    1},
                { -15,  -14,    15,    1},
                { -15,  -14,    5,     1},
                { -15,  -4,     5,     1},
                { -15,  -4,     -5,    1},
                { -15,  -14,    -5,    1},
                { -15,  -14,    -15,   1},
                { -15,  10,     -15,   1},
                }
            };

            DrawingObject flag = new DrawingObject()
            {
                matrix = new int[,]{
                { 11, 8,  15,     1},
                { 11, 14, 15,     1},
                { 13, 13, 15,     1},
                { 11, 12, 15,     1}
            }
            };

            drawingObjects = new DrawingObject[]
            {
                wall1,
                wall2,
                wall3,
                wall4,
                flag,
                new Window(-13, 6, 15),
                new Window(11, 6, 15),
                new Window(-13, -4, 15),
                new Window(11, -4, 15),
                new Window(-13, 6, -15),
                new Window(11, 6, -15),
                new Window(-13, -4, -15),
                new Window(11, -4, -15),
            };
        }


        /// <summary>
        /// Рисует замок
        /// </summary>
        /// <param name="graphics">Рисующий объект</param>
        /// <param name="zoom">Масштаб</param>
        /// <param name="rotationX">Угол поворота вокруг оси X</param>
        /// <param name="rotationY">Угол поворота вокруг оси Y</param>
        /// <param name="rotationZ">Угол поворота вокруг оси Z</param>
        /// <param name="moveX">Перемещение по оси X</param>
        /// <param name="moveY">Перемещение по оси Y</param>
        /// <param name="moveZ">Перемещение по оси Z</param>
        public void Draw(Graphics graphics, int zoom,
            int rotationX, int rotationY, int rotationZ,
            int moveX, int moveY, int moveZ)
        {
            /// Угол поворота в радианах
            double angleX = rotationX * PI / 180;
            double angleY = rotationY * PI / 180;
            double angleZ = rotationZ * PI / 180;
            /// Матрица для поворота вокруг оси X
            double[,] T1 =
            {
                { 1,             0,             0,    0},  
                { 0,   Cos(angleX),     Sin(angleX),  0},
                { 0,   -Sin(angleX),    Cos(angleX),  0},
                { 0,             0,             0,    1}
            };
            /// Матрица для поворота вокруг оси Y
            double[,] T5 =
            {
                { Cos(angleY),   -Sin(angleY),    0,  0},
                { 0,              1,              0,  0},
                { Sin(angleY),    Cos(angleY),    1,  0},
                { 0,              0,              0,  1}
            };
            /// Матрица для поворота вокруг оси Z
            double[,] T6 =
            {
                { Cos(angleZ),    Sin(angleZ),    0,  0},
                { -Sin(angleZ),   Cos(angleZ),    0,  0},
                { 0,             0,               1,  0},
                { 0,             0,               0,  1}
            };
            
            /// Матрица для масшабирования
            double[,] T2 =
            {
                { (double)zoom / 10,    0,   0,     0},
                { 0,    (double)zoom / 10,   0,     0},
                { 0,    0,   (double)zoom / 10,     0},
                { 0,    0,   0,     1}
            };
            /// Матрица для сдвига
            //double[,] T3 =
            //{
            //    { 1,                        (double)offsetY / 10,   0},
            //    { (double)offsetX / 10,     1,                      0},
            //    { 0,                        0,                      1}
            //};
            /// Матрица для перемещения
            double[,] T4 =
            {
                { 1,     0,     0,     0},
                { 0,     1,     0,     0},
                { 0,     0,     1,     0},
                { moveX, moveY, moveZ, 1}
            };
            /// Итоговая матрица
            double[,] T = multiply(multiply(multiply(multiply(T1, T2), T4), T5), T6);  
            foreach (var i in drawingObjects)
            {
                i.draw(graphics, T);
            }
        }

        class Window : DrawingObject
        {
            public Window(int x, int y, int z)
            {
                matrix = new int[,]
                    {
                        { x,        y,      z,   1},
                        { x + 2,    y,      z,   1},
                        { x + 2,    y - 4,  z,   1},
                        { x,        y - 4,  z,   1}
                    };
            }
        }
        

        private class DrawingObject
        {
            /// <summary>
            /// Матрица точек
            /// </summary>
            public int[,] matrix { get; set; }

            /// <summary>
            /// Отрисовка объекта
            /// </summary>
            /// <param name="graphics">Рисующий объект</param>
            /// <param name="T">Матрица обработки</param>
            public void draw(Graphics graphics, double[,] T)
            {
                int dx = (int)(graphics.ClipBounds.Width / 60); // Соотношение усл.ед к пикселям
                int dy = (int)(graphics.ClipBounds.Height / 60);
                dx = dy = Math.Min(dx, dy);
                int countRows = matrix.GetLength(0);        //Количество строк
                double[,] matrixDrow = multiply(matrix, T); // Матрица отображения
                for (int i = 0; i < countRows; i++)         // Преобразование от усл. ед. к пикселям
                {
                    matrixDrow[i, 0] = (graphics.ClipBounds.Width / 2 + dx * matrixDrow[i, 0]);
                    matrixDrow[i, 1] = (graphics.ClipBounds.Height / 2 - dy * matrixDrow[i, 1]);
                }
                for (int i = 1; i < countRows; i++) // Рисование
                {
                    graphics.DrawLine(Pens.Black,
                        (float)matrixDrow[i - 1, 0],
                        (float)matrixDrow[i - 1, 1],
                        (float)matrixDrow[i, 0],
                        (float)matrixDrow[i, 1]
                        );
                }
                graphics.DrawLine(Pens.Black,
                        (float)matrixDrow[countRows - 1, 0],
                        (float)matrixDrow[countRows - 1, 1],
                        (float)matrixDrow[0, 0],
                        (float)matrixDrow[0, 1]
                        );
            }
        }

        /// <summary>
        /// Перемножение матриц
        /// </summary>
        public static double[,] multiply(int[,] m1, double[,] m2) 
        {
            double[,] result = new double[m1.GetLength(0), m2.GetLength(1)];

            for (int i = 0; i < m1.GetLength(0); i++)
            {
                for (int j = 0; j < m2.GetLength(1); j++)
                {
                    double sum = 0;

                    for (int k = 0; k < m1.GetLength(1); k++)
                    {
                        sum += m1[i, k] * m2[k, j];
                    }

                    result[i, j] = sum;
                }
            }
            return result;
        }
        /// <summary>
        /// Перемножение матриц
        /// </summary>
        public static double[,] multiply(double[,] m1, double[,] m2)
        {
            double[,] result = new double[m1.GetLength(0), m2.GetLength(1)];

            for (int i = 0; i < m1.GetLength(0); i++)
            {
                for (int j = 0; j < m2.GetLength(1); j++)
                {
                    double sum = 0;

                    for (int k = 0; k < m1.GetLength(1); k++)
                    {
                        sum += m1[i, k] * m2[k, j];
                    }

                    result[i, j] = sum;
                }
            }
            return result;
        }

    }


}
