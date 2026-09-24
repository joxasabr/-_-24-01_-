using System;

namespace Мирхаликов_БПИ24_01_Лаба.Functions
{
    /// <summary>
    /// Класс, представляющий функцию тангенс: f(x) = tg(x) = sin(x)/cos(x).
    /// </summary>
    public class TangentFunction : MathFunction
    {
        /// <summary>
        /// Конструктор вызывает конструктор родителя MathFunction(base).
        /// </summary>
        public TangentFunction() : base("tg(x)")
        {
        }

        /// <summary>
        /// Переопределение абстрактного метода: значение тангенса в точке x.
        /// </summary>
        public override double ComputeValue(double x)
        {
            return Math.Tan(x);
        }

        // Метод GetDescription НЕ переопределяется — используется вариант
        // из базового класса MathFunction. Это демонстрирует требование:
        // "виртуальный метод переопределяется в одном наследнике
        // (Sine, Cosine) и не переопределяется в другом (Tangent)".

        /// <summary>
        /// Производная тангенса равна 1 / cos^2(x).
        /// </summary>
        public override IFunction GetDerivative()
        {
            return new SecSquaredFunction();
        }
    }
}
