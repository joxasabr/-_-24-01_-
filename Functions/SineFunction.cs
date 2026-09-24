using System;
using System.Text;

namespace Мирхаликов_БПИ24_01_Лаба.Functions
{
    /// <summary>
    /// Класс, представляющий функцию синус: f(x) = sin(x).
    /// </summary>
    public class SineFunction : MathFunction
    {
        /// <summary>
        /// Конструктор наследника — вызывает конструктор родительского
        /// класса MathFunction(base) и передаёт ему название функции.
        /// </summary>
        public SineFunction() : base("sin(x)")
        {
        }

        /// <summary>
        /// Переопределение (override) абстрактного метода родителя:
        /// вычисляет значение синуса в точке x.
        /// </summary>
        public override double ComputeValue(double x)
        {
            return Math.Sin(x);
        }

        /// <summary>
        /// ПЕРЕГРУЗКА (overload) метода ComputeValue: та же функция,
        /// но принимает массив точек и возвращает массив значений.
        /// Это ДОПОЛНИТЕЛЬНАЯ сигнатура метода, унаследованного от родителя
        /// (требование "один из наследников перегружает метод родителя").
        /// </summary>
        /// <param name="xs">Массив значений переменной</param>
        /// <returns>Массив значений sin(x) для каждой точки</returns>
        public double[] ComputeValue(double[] xs)
        {
            double[] result = new double[xs.Length];
            for (int i = 0; i < xs.Length; i++)
            {
                result[i] = ComputeValue(xs[i]);
            }
            return result;
        }

        /// <summary>
        /// Переопределение виртуального метода GetDescription из MathFunction.
        /// </summary>
        public override string GetDescription()
        {
            return "Синус — тригонометрическая функция, равная отношению " +
                   "противолежащего катета к гипотенузе в прямоугольном треугольнике.";
        }

        /// <summary>
        /// Производная синуса равна косинусу — создаём новый экземпляр CosineFunction.
        /// </summary>
        public override IFunction GetDerivative()
        {
            return new CosineFunction();
        }

        /// <summary>
        /// Вспомогательный метод для красивого форматирования результата
        /// перегруженного ComputeValue(double[]) при демонстрации в UI.
        /// </summary>
        public static string FormatArray(double[] values)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < values.Length; i++)
            {
                sb.Append(values[i].ToString("F4"));
                if (i < values.Length - 1) sb.Append("; ");
            }
            return sb.ToString();
        }
    }
}
