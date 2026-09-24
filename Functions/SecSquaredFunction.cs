using System;

namespace Мирхаликов_БПИ24_01_Лаба.Functions
{
    /// <summary>
    /// Вспомогательный класс 1/cos^2(x) — производная тангенса.
    /// Наследник MathFunction, дополняет иерархию классов.
    /// </summary>
    public class SecSquaredFunction : MathFunction
    {
        public SecSquaredFunction() : base("1/cos^2(x)")
        {
        }

        public override double ComputeValue(double x)
        {
            double cos = Math.Cos(x);
            return 1.0 / (cos * cos);
        }

        /// <summary>
        /// Дальнейшее дифференцирование не требуется по условию задания,
        /// поэтому метод возвращает ссылку на самого себя как заглушку.
        /// </summary>
        public override IFunction GetDerivative()
        {
            return this;
        }
    }
}
