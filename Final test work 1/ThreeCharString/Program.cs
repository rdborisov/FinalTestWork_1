/*
Задача: написать программу, которая из имеющегося массива строк формирует массив из строк,
длинна которых меньше либо равна 3 символа. Первоначальный массив можно ввести с клавиатуры,
либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться коллекциями,
лучше обойтись исключительно массивами.
Примеры:
["hello", "2", "world", ":-)"] -> ["2", ":-)"]
["1234", "1567", "-2", "computer scince"] -> ["-2"]
["Russia", "Denmark", "Kazan"] -> []
*/

namespace FinalTestWork1
{
    class TestWork1
    {
        public static void Main()
        {
            string[] userArray = UserInputArray("Введите элементы массива через запятую или пробел: ");
            string[] threeCharString = ThreeCharString(userArray);

            PrintArr(userArray);
            Console.Write($" -> ");
            PrintArr(threeCharString);
        }

        /*Функция записи из консольной строки с разделением через пробел/пробелы
          Символ-разделитель добавляется в массив SplitChar и используется в функции Split(char[], StringSplitOptions)
          StringSplitOptions.RemoveEmptyEnties - удаляет повторяющийся ввод пробелов*/
        public static string[] UserInputArray(string message)
        {
            Console.WriteLine(message);
            char[] SplitChar = new char[] { ',', ' ' };          // Массив символов разделителей
            string text = Console.ReadLine();                    //Пользовательский ввод
            string[] words = text.Split(SplitChar, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }

        //Функция вывода массива
        public static void PrintArr(string[] array)         
        {
            for (int i = 0; i < array.Length; i++)
            {   
                if(i == 0) Console.Write($"[{array[i]}, ");
                else if(i == array.Length - 1) Console.Write($" {array[i]}]");
                else Console.Write($"{array[i]}, ");
            }

        }

        //Функция, возвращающая элементы массива длинной меньше или равной 3 символам
        public static string[] ThreeCharString(string[] array)        
        {
            string[] threeCharString = new string[array.Length];                    //Создаем массив длиной равной длине принимаемого аргумента
            for (int i = 0, j = 0; i < array.Length; i++)                           //Циклически перебираем от 0 до последнего элемента принимаемого аргумента
            {
                if (array[i].Length <= 3)                                           //если длина i-го элемента меньше или равна
                {
                    threeCharString[j] = array[i];                                  //элемент второго массива равен элементу первого
                    j++;                                                            //увеличиваем индекс второго массива на единицу   
                }
                else
                {
                    Array.Resize(ref threeCharString, threeCharString.Length - 1);  //иначе уменьшаем длину второго массива 
                }
            }
            return threeCharString;
        }
    }
}