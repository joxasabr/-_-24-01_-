using System;

namespace Мирхаликов_БПИ24_01_Лаба.Functions
{
    /// <summary>
    /// Базовый (родительский) класс для иерархии функций одной переменной
    /// (синус, косинус, тангенс). Реализует интерфейс IFunction.
    /// </summary>
    public abstract class MathFunction : IFunction
    {
        /// <summary>
        /// Поле для хранения символьного названия функции, например "sin(x)".
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// Свойство "только для чтения", открывающее доступ к названию функции.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Конструктор базового класса. Вызывается из каждого наследника
        /// через base(name) — демонстрация вызова конструктора родителя.
        /// </summary>
        /// <param name="name">Название функции</param>
        protected MathFunction(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Абстрактный метод вычисления значения функции в точке x.
        /// Обязателен к переопределению во всех классах-наследниках.
        /// </summary>
        public abstract double ComputeValue(double x);

        /// <summary>
        /// Виртуальный метод получения текстового описания функции.
        /// Часть наследников его переопределяет, часть — нет
        /// (требование про виртуальный метод, переопределяемый не везде).
        /// </summary>
        public virtual string GetDescription()
        {
            return "Математическая функция " + _name + " (общее описание базового класса)";
        }

        /// <summary>
        /// Абстрактный метод создания экземпляра класса, представляющего
        /// производную текущей функции.
        /// </summary>
        public abstract IFunction GetDerivative();

        /// <summary>
        /// Переопределение стандартного метода ToString() для удобного вывода.
        /// </summary>
        public override string ToString()
        {
            return _name;
        }
    }
}
