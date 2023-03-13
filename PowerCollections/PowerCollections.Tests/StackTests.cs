using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PowerCollections.Tests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        [Description("Проверяю порядок заполнения стека")]
        /// <summary>
        /// Проверяю порядок заполнения стека 
        /// </summary>
        public void СheckingTheOrderOfFilling()
        {
            Stack_new<int> stack = new Stack_new<int>(8);
            for (int i = 1; i <= 8; i++)
            {
                stack.Push(i);
            }
            int[] array = new int[] { 8, 7, 6, 5, 4, 3, 2, 1 };
            CollectionAssert.AreEqual(array, stack.ToArray());
        }


        [TestMethod]
        /// <summary>
        /// Проверяю, совпадает ли емкость массива с заданным конструктору параметром 
        /// </summary>
        public void StackCapacityTest()
        {
            Stack_new<int> stack = new Stack_new<int>(8);
            Assert.AreEqual(8,stack.Capacity);
        }
        /// <summary>
        /// Должен выдать мой exeption, если на вход задать неверные параметры
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(StackException))]
        [DataRow(0)]
        [DataRow(-1)]
        public void ConstructorExeptionTestWithIncorrectInput(int capacity)
        {
            Stack_new<int> stack = new Stack_new<int>(capacity);
        }
        /// <summary>
        /// стек создан пустой, добавляю элемент
        /// Количество элементов в стеке должно стать = 1
        /// </summary>
        [TestMethod]
        public void PushOneElementAndCountElementsInStack()
        {
            Stack_new<int> stack = new Stack_new<int>(8);
            stack.Push(99);
            Assert.AreEqual(1, stack.Count);
        }
        /// <summary>
        /// первый элемент должен быть тем же, что только что положил
        /// </summary>
        [TestMethod]
        public void IsPushedRight()
        {
            Stack_new<int> stack = new Stack_new<int>(8);
            stack.Push(99);
            Assert.AreEqual(99, stack.array[0]);
        }
        /// <summary>
        /// правильно ли берется верхнее значение
        /// </summary>
        [TestMethod]
        public void GetTopElement()
        {
            Stack_new<int> stack = new Stack_new<int>(8);
            stack.Push(99);
            stack.Push(45);
            Assert.AreEqual(45, stack.Top());
        }
        /// <summary>
        /// Отлавливаю свой exeption при попытке
        /// посмотреть верхнее значение -пустого- стека
        /// </summary>
        [TestMethod]
        public void GetTopFromEmptyStackException()
        {
            Stack_new<int> stack = new Stack_new<int>(8);
            var ex = Assert.ThrowsException<StackException>(() => stack.Top());
            Assert.AreEqual("Top: Обращение к области вне диапазона", ex.Message);
        }
        /// <summary>
        /// Выдает ли _Pop верхнее значение
        /// </summary>
        [TestMethod]
        public void IsPoppedElementRight()
        {
            Stack_new<int> stack = new Stack_new<int>(8);
            stack.Push(99);
            stack.Push(45);
            Assert.AreEqual(45, stack.Pop());
        }

        [TestMethod]
        public void PopFromEmptyStackException()
        {
            Stack_new<int> stack = new Stack_new<int>(8);
            var ex = Assert.ThrowsException<StackException>(() => stack.Pop());
            Assert.AreEqual("Pop: Обращение к области вне диапазона", ex.Message);
        }

        [TestMethod]
        public void StackMoreThanItIsCalculated()
        {
            Stack_new<int> stack = new Stack_new<int>(8);
            for (int i = 1; i <= 8; i++)
            {
                stack.Push(i);
            }
            var ex = Assert.ThrowsException<StackException>(() => stack.Push(9));
            Assert.AreEqual("Push: Заполнение области стека вне диапазона", ex.Message);
        }
    }
}
