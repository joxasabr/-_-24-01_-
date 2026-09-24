namespace Мирхаликов_БПИ24_01_Лаба.Functions
{
    /// <summary>
    /// Интерфейс математической функции одной переменной.
    /// Реализуется абстрактным классом MathFunction (требование "Реализовать интерфейс").
    /// </summary>
    public interface IFunction
    {
        /// <summary>
        /// Вычисляет значение функции в точке x.
        /// </summary>
        /// <param name="x">Значение переменной</param>
        /// <returns>Значение функции f(x)</returns>
        double ComputeValue(double x);

        /// <summary>
        /// Создаёт новый экземпляр класса, представляющий производную данной функции.
        /// </summary>
        /// <returns>Объект-функция, являющийся производной текущей функции</returns>
        IFunction GetDerivative();
    }
}
