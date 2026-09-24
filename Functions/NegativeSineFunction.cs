using System;

namespace Мирхаликов_БПИ24_01_Лаба.Functions
{
    /// <summary>
    /// Вспомогательный класс -sin(x) — производная косинуса.
    /// Является наследником MathFunction (продолжение иерархии классов).
    /// </summary>
    public class NegativeSineFunction : MathFunction
    {
        public NegativeSineFunction() : base("-sin(x)")
        {
        }

        public override double ComputeValue(double x)
        {
            return -Math.Sin(x);
        }

        /// <summary>
        /// Производная -sin(x) равна -cos(x).
        /// </summary>
        public override IFunction GetDerivative()
        {
            return new NegativeCosineFunction();
        }
    }
}
