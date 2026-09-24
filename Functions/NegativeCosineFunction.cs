using System;

namespace Мирхаликов_БПИ24_01_Лаба.Functions
{
    /// <summary>
    /// Вспомогательный класс -cos(x) — вторая производная синуса
    /// (производная -sin(x)). Замыкает цепочку sin -> cos -> -sin -> -cos -> sin.
    /// </summary>
    public class NegativeCosineFunction : MathFunction
    {
        public NegativeCosineFunction() : base("-cos(x)")
        {
        }

        public override double ComputeValue(double x)
        {
            return -Math.Cos(x);
        }

        public override IFunction GetDerivative()
        {
            return new SineFunction();
        }
    }
}
