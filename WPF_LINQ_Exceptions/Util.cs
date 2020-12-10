using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IST215C_Project
{
    class Util
    {
        public static int LoadData(string path, out List<Customer> customerList)
        {
            string line;
            string[] words;
            int count = 0;

            customerList = new List<Customer>();

            StreamReader reader = null;
            reader = new StreamReader(path);
            try
            {
                do
                {
                    count++;
                    line = reader.ReadLine();
                    words = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    customerList.Add(new Customer(Convert.ToInt32(words[0]), words[1], words[2], Convert.ToInt32(words[3]), words[4], 
                        words[5], words[6], words[7], words[8], words[9]));
                    // Console.WriteLine("{0,6} - {1}", count, line);
                } while (reader.Peek() != -1);
            }
            catch (FileNotFoundException ef)
            {
                throw new FileNotFoundException(ef.Message);                      // FieldAccessException
            }
            catch (FieldAccessException ef)
            {
                throw new FieldAccessException(ef.Message);                      // FieldAccessException
            }

            catch (Exception e)
            {
                throw new Exception($"{e.GetType()}, {e.Message}\r\n{e.StackTrace}\r\n");
            }

            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return customerList.Count;
        } // end try
    } // end class Util

} // end namespace
   
