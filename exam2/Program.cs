using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace exam2
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = default;
            do
            {
                Console.Clear();
                Console.WriteLine("Для игры в викторину VICTORY авторизируйтесь или зарегистрируйтесь: ");
                Console.WriteLine("0 - выход из приложения");
                Console.WriteLine("1 - авторизация существующего пользователя");
                Console.WriteLine("2 - регистрация нового пользователя");
                try
                {
                    Int32.TryParse(Console.ReadLine(), out result);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (result > 2 || result < 0)
                {
                    Console.WriteLine("Вы ввели некорректный ввод попробуйте еще раз..");
                }
                else if (result == 0)
                {
                    break;
                }
                switch (result)
                {

                    case 1:
                        // Console.Clear();
                        string answer = default;
                        do
                        {
                            Console.WriteLine("нажмите 'y' для выхода в предыдущее меню ");
                            Console.WriteLine("Для авторизации в приложении: ");
                            Console.WriteLine("Введите логин: ");
                            string Ulogin = Console.ReadLine();
                            if(Ulogin == "y")
                            {
                                break;
                            }
                            Console.WriteLine("Введите пароль:");
                            string Upass = Console.ReadLine();
                           
                            if (!WorkWithUser.check(Ulogin,Upass))
                            {
                                Console.WriteLine("логин и пароль не верны");
                                Console.WriteLine("попробовать еще раз? нажмите 'y' для выхода в предыдущее меню нового пользователя или любую клавишу для повтороного воода");
                                answer = Console.ReadLine();
                            }
                           
                            else
                            {
                                Console.WriteLine("пользователь найден!");
                                Submenu.Show(Ulogin);
                            }


                        } while (answer != "y");

                        break;
                    case 2:
                        string answer2 = default;
                        do
                        {
                            Console.WriteLine("введите логин пользователя");
                            string log = Console.ReadLine();
                            Console.WriteLine("введите пароль: ");
                            string pass = Console.ReadLine();
                            Console.WriteLine("введите дату рождения");
                            string BirthDate = Console.ReadLine();
                            if (!WorkWithUser.CherCorrectInfo(log, pass, BirthDate))
                            {
                                Console.WriteLine("некорректно заполнены поля! попробуйте еще раз.");
                                Console.WriteLine("для повторной попытки нажмите любую клавишу. Для выхода в предыдущее меню нажмите 'n'");
                                answer2 = Console.ReadLine();
                            }
                            else if(WorkWithUser.check(log))
                            {
                                Console.WriteLine("пользователь с таким логином уже существует");
                                Console.WriteLine("для повторной попытки нажмите любую клавишу. Для выхода в предыдущее меню нажмите 'n'");
                                answer2 = Console.ReadLine();
                            }
                            else
                            {
                                WorkWithUser.AddNewUser(log, pass, BirthDate);
                                Console.WriteLine("Новый пользователь успешно добавлен!");
                                Submenu.Show(log);
                            }
                           
                        }
                        while (answer2 != "n");

                       

                        break;
                }
                 
            } while (result != 0);
         }
    }
}

