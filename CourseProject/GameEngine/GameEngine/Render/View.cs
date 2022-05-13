using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace GameEngine
{
    /// <summary>
    /// Работа с камерой.
    /// </summary>
    public class View : GameComponent
    {
        private Vector2 position;
        private double rotation;
        private double zoom;
        private Vector2 positionGoto, positionFrom;
        private TweenType tweenType;
        private int currentStep, tweenSteps;

        /// <summary>
        /// Свойство позиции.
        /// </summary>
        public Vector2 Position
        {
            get { return this.position; }
        }

        /// <summary>
        /// Свойство позиции перехода.
        /// </summary>
        public Vector2 PositionGoto
        {
            get { return this.positionGoto; }
        }

        /// <summary>
        /// Конструктор камеры.
        /// </summary>
        /// <param name="startPosition">Начальная позиция.</param>
        /// <param name="startRotation">Начальное значение поворота.</param>
        /// <param name="startZoom">Начальное увеличение.</param>
        public View(Vector2 startPosition, double startRotation = 0.0, double startZoom = 1.0)
        {
            this.position = startPosition;
            this.rotation = startRotation;
            this.zoom = startZoom;
        }

        /// <summary>
        /// Метод движения по игровому миру.
        /// </summary>
        /// <param name="input">Входной параметр.</param>
        /// <returns></returns>
        public Vector2 ToWorld(Vector2 input)
        {
            input /= (float)zoom;
            Vector2 dX = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            Vector2 dY = new Vector2((float)Math.Cos(rotation + MathHelper.PiOver2), (float)Math.Sin(rotation + MathHelper.PiOver2));

            return (this.Position + dX * input.X + dY * input.Y);
        }

        /// <summary>
        /// Метод обновления.
        /// </summary>
        public void Update()
        {
            if (currentStep < tweenSteps)
            {
                currentStep++;

                switch (tweenType)
                {
                    case TweenType.Linear:
                        position = positionFrom + (positionGoto - positionFrom) * GetLinear((float)currentStep / tweenSteps);
                        break;
                    case TweenType.QuadraticInOut:
                        position = positionFrom + (positionGoto - positionFrom) * GetQuadraticInOut((float)currentStep / tweenSteps);
                        break;
                    case TweenType.CubicInOut:
                        position = positionFrom + (positionGoto - positionFrom) * GetCubicInOut((float)currentStep / tweenSteps);
                        break;
                    case TweenType.QuarticOut:
                        position = positionFrom + (positionGoto - positionFrom) * GetQuarticOut((float)currentStep / tweenSteps);
                        break;
                }
            }
            else
            {
                position = positionGoto;
            }
        }

        /// <summary>
        /// Набор позиций.
        /// </summary>
        /// <param name="newPosition">Новая позиция.</param>
        public void SetPosition(Vector2 newPosition)
        {
            this.position = newPosition;
            this.positionFrom = newPosition;
            this.positionGoto = newPosition;
            tweenType = TweenType.Instant;
            currentStep = 0;
            tweenSteps = 0;
        }

        /// <summary>
        /// Набор позиций.
        /// </summary>
        /// <param name="newPosition">Новая позиция.</param>
        /// <param name="type">Тип.</param>
        /// <param name="numSteps">Номер шага.</param>
        public void SetPosition(Vector2 newPosition, TweenType type, int numSteps)
        {
            this.positionFrom = Position;
            this.position = newPosition;
            this.positionGoto = newPosition;
            tweenType = type;
            currentStep = 0;
            tweenSteps = numSteps;
        }
        /// <summary>
        /// Получение линейной функции.
        /// </summary>
        /// <param name="t">Переменная.</param>
        /// <returns>t</returns>
        public float GetLinear(float t)
        {
            return t;
        }
        /// <summary>
        /// Получение квадратичной функции.
        /// </summary>
        /// <param name="t">Переменная.</param>
        /// <returns>Квадратичная функция.</returns>
        public float GetQuadraticInOut(float t)
        {
            return (t * t) / ((2 * t * t) - (2 * t) + 1);
        }
        /// <summary>
        /// Получение кубической функции.
        /// </summary>
        /// <param name="t">Переменная.</param>
        /// <returns>Кубическая функция.</returns>
        public float GetCubicInOut(float t)
        {
            return (t * t * t) / ((3 * t * t) - (3 * t) + 1);
        }
        /// <summary>
        /// Получение суперкубической функции.
        /// </summary>
        /// <param name="t">Переменная.</param>
        /// <returns>Суперкубическая функция.</returns>
        public float GetQuarticOut(float t)
        {
            return -((t - 1) * (t - 1) * (t - 1) * (t - 1)) + 1;
        }
        /// <summary>
        /// Применение изменений.
        /// </summary>
        public void ApplyTransform()
        {
            Matrix4 transform = Matrix4.Identity;

            transform = Matrix4.Mult(transform, Matrix4.CreateTranslation(-Position.X, -Position.Y, 0));
            transform = Matrix4.Mult(transform, Matrix4.CreateRotationZ(-(float)rotation));
            transform = Matrix4.Mult(transform, Matrix4.CreateScale((float)zoom, (float)zoom, 1.0f));

            GL.MultMatrix(ref transform);
        }
    }
}
