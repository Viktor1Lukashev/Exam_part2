using exam2.Quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam2
{
    class Submenu
    {

        public Submenu() { }
        public static void Show(string login)
        {

            int i = default;
            do
            {
                Console.WriteLine("Выберите викторину: ");
                Console.WriteLine("1 - История");
                Console.WriteLine("2 - География");
                Console.WriteLine("3 - Биология");
                Console.WriteLine("4 - Выйти в предыдущее меню: ");

                try
                {
                    Int32.TryParse(Console.ReadLine(), out i);
                    if (i <= 0 || i > 4)
                    {
                        Console.WriteLine("некорректный выбор! Выберите пункт от 1 до 4");
                    }

                }
                catch (Exception ex)
                {
                    throw;
                }

                IQuiz quiz = CreateQuiz.Create(i, login);
                int k;
                do
                {
                    Console.WriteLine("Теперь пришло время играть!");
                    Console.WriteLine("Выберите действие: ");
                    Console.WriteLine("1 - Запустить викторину");
                    Console.WriteLine("2 - Посмотреть Топ-20 викторины");
                    Console.WriteLine("3 - Изменить настройки (поменять пароль и дату рождения)");
                    Console.WriteLine("4 - Выход в предыдущее меню");

                    try
                    {
                        Int32.TryParse(Console.ReadLine(), out k);
                        if (k < 1 || k > 4)
                        {
                            Console.WriteLine("Выберите доступный вариант: ");
                        }
                     
                        switch (k)
                        {
                            case 1:
                                quiz.Start();
                                break;
                            case 2:
                                quiz.Top20();
                                break;
                                //case 3:
                                //    break;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }


                } while (k != 4);
            } while (i != 4);
        }
    }
}
//                switch (i)
//                {
//                    case 1:
//                        do
//                        {
//                            Console.WriteLine("Теперь пришло время играть!");
//                            Console.WriteLine("Выберите действие: ");
//                            Console.WriteLine("1 - Запустить викторину");
//                            Console.WriteLine("2 - Посмотреть Топ-20 викторины");
//                            Console.WriteLine("3 - Изменить настройки (поменять пароль и дату рождения)");
//                            Console.WriteLine("4 - Выход в предыдущее меню");

//                            try
//                            {
//                                Int32.TryParse(Console.ReadLine(), out int k);
//                                if (i < 1 || i > 4)
//                                {
//                                    Console.WriteLine("Выберите доступный вариант: ");
//                                }
//                                CreateQuiz.Create(k, login);
                              
//                            }
//                            catch (Exception ex)
//                            {
//                                throw;
//                            }
//                            break;

//                        } while (i != 4);
//                        break;


//                    case 2:
//                        Console.WriteLine("по какой викторине вы хоите получить Топ-20?");

//                        break;
//                }

//            } while (i != 4);
//        }
//    }
//}
           
  
