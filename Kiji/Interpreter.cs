using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace KizhiPart1
{
    public class Interpreter
    {
        //private TextWriter _writer;
        public string _writer;
        private Dictionary<string, int> countries = new Dictionary<string, int>();// словарь для сохранения в поле экземпляра класса значений  {variable} {value} 
        private Dictionary<string, string> countriesFunction = new Dictionary<string, string>();//словарь для функций
        private string textCode;
        private List<int> printValue;
        private string commandMemory;
        //public Interpreter(TextWriter writer)
        //{
        //    _writer = writer;
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        public void ExecuteLine(string command)
        {
            MessageBox.Show(textCode);
            if (command == "set code" & command != textCode)// записывает комманду в поле если она соответствует  началу или концу кода и проверка на 2 команды подряд
            {
                textCode = command;
                _writer = null;
            }
            if (command == "set code" & command == textCode)
            {
                _writer = "set code уже вводился";
            }
                if (command == "end set code" & textCode== "set code")
            {
                textCode = command;
            }
            if (command == "end set code" & textCode != "set code")
            {
                _writer = "комманда end set code введена не правильно";
            }

            if (textCode == "set code" & command != "run")// если в предидущей команде было set code то делать
            {
                commandMemory = command;                
            }

            if (command == "run" & textCode == "end set code")
            {
                FunctionDictionaryWriter(commandMemory);
                
                List<string> commandList;// отдельные строки
                commandMemory = commandMemory.Trim();//удаляет  в начале и в конце лишние пробелы если они есть
                commandList = commandMemory.Split('\n').ToList();
                foreach(string str in commandList)
                {
                    ExecuteLineSimple(str);
                }
            }
            if(command == "run" & textCode != "end set code")
            {
                _writer = "перед run должен быть end set code";
            }
            else
            {
                _writer = "все не правильно"+ _writer;
            }
            //if((command.StartsWith("print") | command.StartsWith("sub")) & textCode !="set code")
            //{
            //    //_writer.WriteLine("Переменная отсутствует в памяти");
            //    _writer = "Не введено set code";
            //}
        }

        /// <summary>
        /// Возвращает true если Variable содержит только символы английского алфовита
        /// </summary>
        /// <param name="Variable"></param>
        /// <returns></returns>
        private bool VariableConteinOnlyEnglishChar(string Variable)
        {
            bool flag = true;
            char[] charVariable = Variable.ToCharArray();
            foreach (char ch in charVariable)
            {
                if (!char.IsLetter(ch))
                {
                    //_writer.WriteLine($"Variable содержит символы не соотвествующие синтаксису языка Кижи {ch}");
                    _writer = $"Variable содержит символы не соотвествующие синтаксису языка Кижи {ch}";
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }
        /// <summary>
        /// Возвращает true если Value содержит только цифры
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        private bool ValueConteinOnlyDigit(string Value)
        {
            bool flag = true;
            char[] charValue = Value.ToCharArray();
            foreach (char ch in charValue)
            {
                if (!char.IsDigit(ch))
                {
                    // _writer.WriteLine($"Value содержит не только цифры что соотвествуюет синтаксису языка Кижи {ch}");
                    _writer = $"Value содержит не только цифры что соотвествуюет синтаксису языка Кижи {ch}";
                     flag = false;
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }
        /// <summary>
        /// Обрабатывает отдельные строки
        /// </summary>
        /// <param name="command"></param>
        private void ExecuteLineSimple(string command)
        {

            List<string> commandList;
            command = command.Trim();//удаляет  в начале и в конце лишние пробелы если они есть
            command = Regex.Replace(command, @"\s+", " ");// удаляет лишние пробелы между словами
            commandList = command.Split(' ').ToList();
            int countCommand = commandList.Count;
            if(commandList[0].Contains("call")& countriesFunction.ContainsKey(commandList[1])& countCommand==2)
            {
                
                List<string> commandListFunction = countriesFunction[commandList[1]].Split(' ').ToList();//получает коллекцию строк относящуюся к функции
                foreach(string str in commandListFunction)
                {
                    ExecuteLineSimple(str);
                }

            }
            if (commandList[0].Contains("set") | commandList[0].Contains("sub") | commandList[0].Contains("print") | commandList[0].Contains("rem"))
            {
                if (countCommand == 3 | 2 == countCommand)
                {
                    if (VariableConteinOnlyEnglishChar(commandList[1]))
                    {
                        switch (countCommand)
                        {
                            case 3://сработает если 3 слова
                                switch (commandList[0])
                                {
                                    case "set":
                                        if (ValueConteinOnlyDigit(commandList[2]))
                                        {
                                            if (!countries.ContainsKey(commandList[1]))
                                            {
                                                countries.Add(commandList[1], Convert.ToInt32(commandList[2]));
                                            }
                                            else
                                            {
                                                countries[commandList[1]] = Convert.ToInt32(commandList[2]);
                                            }
                                        }
                                        else
                                        {
                                            //_writer.WriteLine($"Value команды {command} не соотвествует синтаксису языка Кижи switch case set");
                                            _writer = $"Value команды {command} не соотвествует синтаксису языка Кижи switch case set";
                                        }
                                        break;

                                    case "sub":
                                        if (ValueConteinOnlyDigit(commandList[2]))
                                        {
                                            if (countries.ContainsKey(commandList[1]))
                                            {
                                                if (0 < countries[commandList[1]] - Convert.ToInt32(commandList[2]))
                                                {
                                                    countries[commandList[1]] = countries[commandList[1]] - Convert.ToInt32(commandList[2]);
                                                }
                                                else
                                                {
                                                    //_writer.WriteLine($"Результат вычисления  не входит в множество натуральных чисел {countries[commandList[1]] - Convert.ToInt32(commandList[2])} switch case sub");
                                                    _writer = $"Результат вычисления  не входит в множество натуральных чисел {countries[commandList[1]] - Convert.ToInt32(commandList[2])} switch case sub";
                                                }
                                            }
                                            else
                                            {
                                                //_writer.WriteLine("Переменная отсутствует в памяти");
                                                _writer="Переменная отсутствует в памяти";
                                            }
                                        }
                                        else
                                        {
                                           // _writer.WriteLine($"Value команде {command} не соотвествует синтаксису языка Кижи switch case sub");
                                            _writer= $"Value команде {command} не соотвествует синтаксису языка Кижи switch case sub";
                                        }
                                        break;
                                }
                                break;

                            case 2://сработает если 2 слова
                                switch (commandList[0])
                                {
                                    case "print":
                                        if (countries.ContainsKey(commandList[1]))
                                        {
                                            // _writer.WriteLine(countries[commandList[1]]);
                                            printValue.Add(countries[commandList[1]]);
                                        }
                                        else
                                        {
                                            //_writer.WriteLine("Переменная отсутствует в памяти");
                                            _writer="Переменная отсутствует в памяти";
                                        }
                                        break;
                                    case "rem":
                                        if (countries.ContainsKey(commandList[1]))
                                        {
                                            countries.Remove(commandList[1]);
                                        }
                                        else
                                        {
                                            //_writer.WriteLine("Переменная отсутствует в памяти");
                                            _writer="Переменная отсутствует в памяти";
                                        }
                                        break;
                                }
                                break;
                            default://сработает если ни 2 и не 3 слова
                                //_writer.WriteLine("Количество слов в команде не соответствует синтаксису языка Кижи если ни 2 и не 3 слова");
                                _writer="Количество слов в команде не соответствует синтаксису языка Кижи если ни 2 и не 3 слова";
                                break;
                        }
                    }
                    else
                    {
                        //_writer.WriteLine($"Variable  {commandList[1]} не  последовательность символов из букв английского алфавита VariableConteinOnlyEnglishChar");
                        _writer=$"Variable  {commandList[1]} не  последовательность символов из букв английского алфавита VariableConteinOnlyEnglishChar";
                    }
                }
                else
                {
                    //_writer.WriteLine($"Количество слов в команде {command} не соотвествует синтаксису языка Кижи countCommand == 3 | 2 == countCommand");
                    _writer=$"Количество слов в команде {command} не соотвествует синтаксису языка Кижи countCommand == 3 | 2 == countCommand";
                }
            }
            else
            {
                //_writer.WriteLine($"{commandList[0]} не соответствует синтаксису языка Кижи");
                _writer=$"{commandList[0]} не соответствует синтаксису языка Кижи";
            }
        }
        /// <summary>
        /// Получает команду извлекает код с функцией и  записывает функции в словарь если они есть
        /// </summary>
        /// <param name="command"></param>
        private void FunctionDictionaryWriter(string command)
        {
            List<string> commandList;// отдельные строки
            command = command.Trim();//удаляет  в начале и в конце лишние пробелы если они есть
            commandList = command.Split('\n').ToList();
            int stringLeang = commandList.Count;// количество строк в команде
            string functionName = null;
            bool flag = false;// определяет должна ли на следующей итеррации цикла идти запись функции
            for (int i = 0; i <= stringLeang; i++)// цикл проходит по всем строкам
            {                
                List<string> commandListWords = commandList[i].Split().ToList();// коллекция слов в конкретной строке
                if (flag == true & commandList[i].StartsWith("    "))//запись тела функции
                {
                    commandList[i].Trim();
                    if (!countriesFunction.ContainsKey(functionName))//если в словаре такой функции  нет то создать ее и добавить одну строку
                    {
                        countriesFunction.Add(functionName, commandList[i]);
                    }
                    else
                    {
                        countriesFunction[functionName] = countriesFunction[functionName] +" " +commandList[i];//если в словаре такая функция уже есть то ее значению
                        //присваивается то что было + доп строка
                    }
                }
                if (commandListWords[0] == "def")
                {
                    flag = true;
                    functionName = commandListWords[1];
                }
                if (!commandList[i].StartsWith("    "))
                {
                    flag = false;
                }
            }         
        }
    }
}








