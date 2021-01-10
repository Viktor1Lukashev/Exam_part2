using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace exam2
{
    public  class WorkWithUser
    {
        public string[] UsersInBAse { get; private set;}
        public static bool check(string log)
        {
            bool flag = false;
            //  Regex rx = new Regex(@"^[A-Za-zА-Яа-яЁё]{1,}\s$");
            {
                try
                {
                    using (FileStream fstr = new FileStream("Users.txt", FileMode.OpenOrCreate))
                    {
                        using (StreamReader str = new StreamReader(fstr, Encoding.UTF8))
                        {
                            while (!str.EndOfStream)
                            {
                                if ((str.ReadLine().Contains(log)))
                                {
                                    flag = true;
                                }
                            }

                        }
                    }
                    return flag;
                }
                
                catch (Exception ex)
                {
                    throw;
                }

            }
        }

            public static bool check(string log,string pass)
            {
                bool flag = false;
                //  Regex rx = new Regex(@"^[A-Za-zА-Яа-яЁё]{1,}\s$");
                {
                    try
                    {
                        using (FileStream fstr = new FileStream("Users.txt", FileMode.OpenOrCreate))
                        {
                            using (StreamReader str = new StreamReader(fstr, Encoding.UTF8))
                            {
                                while (!str.EndOfStream)
                                {
                                string[] strf = str.ReadLine().Split(' ',(char)StringSplitOptions.RemoveEmptyEntries) ;
                                if ((strf.Contains(log) && strf.Contains(pass)))

                                        flag = true;                                    
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                return flag;
            }


        public static bool AddNewUser(string log,string pass, string BithDate)
        {
            if (check(log))
            {
                
                return false;
            }
            try
            {
                using (FileStream fstr = new FileStream("Users.txt", FileMode.Append))
                {
                    using (StreamWriter str = new StreamWriter(fstr, Encoding.UTF8))
                    {
                        
                        str.WriteLine(log + " " + pass + " " + BithDate);

                    }
                }
                
                return true;
            }
            catch(Exception ex)
            {
                throw;
            } 

        }

        public static bool CherCorrectInfo(string log, string pass, string BirthDate)
        {
            bool flag = true;
            Regex password = new Regex(@"^[A-Za-z]{6}");
            Regex BithDate1 = new Regex(@"^\d{2}\.\d{2}\.\d{4}");
            if (!password.IsMatch(pass) || !BithDate1.IsMatch(BirthDate))
            {
                flag = false;
            }
            return flag;
        }

        public static void FindUser(string log)
        {
            try
            {
                using (FileStream fstr = new FileStream("Users.txt", FileMode.OpenOrCreate))
                {
                    using (StreamReader str = new StreamReader(fstr, Encoding.UTF8))
                    {


                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
