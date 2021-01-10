using exam2.Quiz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace exam2
{
    public abstract class quiz : IQuiz
    {
        protected string _Name;
        protected string _Login;
        protected int Count;
        protected string PathQuestons;
        protected string PathAnswers;
        protected string PathResultThis;
        protected string PathResultsAll;
        protected bool Equal(string[] str1, string[] str2)
        {
            bool flag = true;
            if (str1.Length == str2.Length)
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    if (str1[i] != str2[i])
                    {
                        flag = false;
                    }
                }
            }
            return flag;
        }
        protected void ReadData(string path, List<string> ls)
        {
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        while (!reader.EndOfStream)
                        {
                            ls.Add(reader.ReadLine());

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void HistoryUser()
        {
            List<string> ls = new List<string>();
            try
            {
                using (FileStream stream = new FileStream(PathResultsAll, FileMode.OpenOrCreate))
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        while (!reader.EndOfStream)
                        {
                            if ((reader.ReadLine().Contains(_Login)))
                            {
                                ls.Add(reader.ReadLine());
                            }
                        }
                    }
                }
                foreach (var i in ls)
                {
                    Console.WriteLine(i);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected void Save()
        {
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            int Count2 = Count;
            string cash = $"Пользователь {_Login} Количестов правильных ответов: {Count}";
            try
            {
                using (FileStream stream = new FileStream(PathResultsAll, FileMode.Append))
                {
                    using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))

                    {
                        writer.WriteLine("Пользователь:" + " " + _Login + " " + DateTime.Now + " " + "Викторина:" + " " + _Name + " " + "Количество правильных ответов: " + Count);

                    }
                }
                using (FileStream str = new FileStream(PathResultThis, FileMode.OpenOrCreate))
                {
                    using (StreamReader reader = new StreamReader(str, Encoding.UTF8))
                    {
                        while (!reader.EndOfStream)
                        {
                            list.Add(reader.ReadLine());
                        }
                    }
                }
                if (list.Any())
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        Regex rx = new Regex(@"\d{1,}$");
                        Match match = rx.Match(list[i]);
                        if (match.Success)
                        {
                            int val = int.Parse(match.Value);
                            if (Count2 > val)
                            {
                                list2.Add(cash);
                                cash = list[i];
                                Count2 = val;
                            }
                            else
                            {
                                list2.Add(list[i]);
                            }

                        }
                    }
                    list2.Add(cash);
                }
                else
                {
                    list2.Add(cash);
                }

                using (FileStream stream = new FileStream(PathResultThis, FileMode.OpenOrCreate))
                {
                    using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))

                    {
                        foreach (var i in list2)
                        {
                            writer.WriteLine(i);
                        }
                    }
                }
            }


            catch (Exception ex)
            {
                throw;
            }

        }

        public void Top20()
        {
            List<string> list = new List<string>();
            using (FileStream stream = new FileStream(PathResultThis, FileMode.OpenOrCreate))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))

                {
                    while (!reader.EndOfStream || list.Count <= 20)
                    {
                        list.Add(reader.ReadLine());

                    }
                }
            }
            Console.WriteLine($"Топ - 20 игроков в викторине {_Name}: ");
            foreach (var str in list)
            {
                Console.WriteLine(str);
            }
        }
        public void Start()
        {
            List<string> quest = new List<string>();
            List<string> answer = new List<string>();
            try
            {
                ReadData(PathQuestons, quest);
                ReadData(PathAnswers, answer);
            }
            catch (Exception ex)
            {
                throw;
            }
            for (int i = 0; i < quest.Count; i++)
            {
                string[] UserAnswer;
                Console.WriteLine(quest[i]);
                string[] st = answer[i].Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
                UserAnswer = Console.ReadLine().Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
                if (Equal(UserAnswer, st))
                {
                    Console.WriteLine("Верно!");
                    Count++;
                }

            }
            Save();
        }
    }
}
