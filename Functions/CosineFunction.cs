using System;

namespace Мирхаликов_БПИ24_01_Лаба.Functions
{
    /// <summary>
    /// Класс, представляющий функцию косинус: f(x) = cos(x).
    /// </summary>
    public class CosineFunction : MathFunction
    {
        /// <summary>
        /// Конструктор вызывает конструктор родителя MathFunction(base).
        /// </summary>
        public CosineFunction() : base("cos(x)")
        {
        }

        /// <summary>
        /// Переопределение абстрактного метода: значение косинуса в точке x.
        /// </summary>
        public override double ComputeValue(double x)
        {
            return Math.Cos(x);
        }

        /// <summary>
        /// Переопределение виртуального метода GetDescription (второй наследник,
        /// который его переопределяет — в отличие от TangentFunction).
        /// </summary>
        public override string GetDescription()
        {
            return "Косинус — тригонометрическая функция, равная отношению " +
                   "прилежащего катета к гипотенузе в прямоугольном треугольнике.";
        }

        /// <summary>
        /// Производная косинуса равна минус синусу.
        /// Так как в интерфейсе нет умножения на -1, для этого возвращаем
        /// специальный класс NegativeSineFunction.
        /// </summary>
        public override IFunction GetDerivative()
        {
            return new NegativeSineFunction();
        }
    }
}
