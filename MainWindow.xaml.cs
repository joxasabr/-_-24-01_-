using System;
using System.Globalization;
using System.Text;
using System.Windows;
using Мирхаликов_БПИ24_01_Лаба.Functions;

namespace Мирхаликов_БПИ24_01_Лаба
{
    /// <summary>
    /// Главное окно приложения. Демонстрирует работу всех методов
    /// классов-функций (синус, косинус, тангенс) и их производных.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Формируем отчёт сразу при запуске с x = 1
            BuildReport(1.0);
        }

        /// <summary>
        /// Обработчик кнопки — считывает x из поля ввода и пересобирает отчёт.
        /// </summary>
        private void ComputeButton_Click(object sender, RoutedEventArgs e)
        {
            double x;
            if (!double.TryParse(XValueTextBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out x)
                && !double.TryParse(XValueTextBox.Text, out x))
            {
                MessageBox.Show("Введите корректное числовое значение x.", "Ошибка ввода",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            BuildReport(x);
        }

        /// <summary>
        /// Формирует полный отчёт, демонстрирующий работу всех объявленных
        /// методов классов иерархии (ComputeValue, GetDerivative, GetDescription,
        /// перегруженный ComputeValue(double[]), а также вызов конструктора родителя).
        /// </summary>
        private void BuildReport(double x)
        {
            var sb = new StringBuilder();

            // Базовый класс хранится через интерфейс IFunction — полиморфизм.
            IFunction[] functions =
            {
                new SineFunction(),
                new CosineFunction(),
                new TangentFunction()
            };

            sb.AppendLine("=== ЛАБОРАТОРНАЯ РАБОТА №1. Вариант 9 ===");
            sb.AppendLine("Иерархия: MathFunction -> SineFunction / CosineFunction / TangentFunction");
            sb.AppendLine("Точка вычисления x = " + x.ToString("F4", CultureInfo.InvariantCulture));
            sb.AppendLine();

            foreach (IFunction f in functions)
            {
                MathFunction mf = (MathFunction)f;

                sb.AppendLine("--- " + mf.Name + " ---");
                sb.AppendLine("Описание (GetDescription): " + mf.GetDescription());
                sb.AppendLine(string.Format(CultureInfo.InvariantCulture,
                    "Значение функции ComputeValue({0:F4}) = {1:F4}", x, mf.ComputeValue(x)));

                IFunction derivative = mf.GetDerivative();
                sb.AppendLine("Производная (GetDerivative): " + derivative);
                sb.AppendLine(string.Format(CultureInfo.InvariantCulture,
                    "Значение производной в точке x = {0:F4}", derivative.ComputeValue(x)));
                sb.AppendLine();
            }

            // Демонстрация ПЕРЕГРУЖЕННОГО метода ComputeValue(double[])
            // из класса SineFunction — работает с массивом точек.
            SineFunction sine = new SineFunction();
            double[] samplePoints = { 0, Math.PI / 6, Math.PI / 4, Math.PI / 3, Math.PI / 2 };
            double[] sineValues = sine.ComputeValue(samplePoints); // перегрузка родительского метода
            sb.AppendLine("--- Демонстрация перегрузки метода ComputeValue (SineFunction) ---");
            sb.AppendLine("Точки: 0, pi/6, pi/4, pi/3, pi/2");
            sb.AppendLine("sin(x) для этих точек: " + SineFunction.FormatArray(sineValues));
            sb.AppendLine();

            sb.AppendLine("--- Демонстрация вызова конструктора родителя ---");
            sb.AppendLine("Каждый наследник (SineFunction, CosineFunction, TangentFunction)");
            sb.AppendLine("вызывает конструктор MathFunction через base(name) и получает Name.");

            ReportTextBlock.Text = sb.ToString();
        }
    }
}
