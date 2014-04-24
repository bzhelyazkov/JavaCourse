using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reducePath
{
    class Program
    {
        public  static string  reduce_file_path(string path)
        {
            StringBuilder sb = new StringBuilder();
            bool hasSlash = false;
            List<string> pathList = new List<string>();

            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] == '/' && hasSlash == false)
                {
                    hasSlash = true;
                    sb.Append(path[i]);
                }

                if (path[i] == '/' && hasSlash == true)
                {
                    if(sb.ToString()=="/")
                    {

                    }
                    else if(sb.ToString()=="/."){
                        sb.Clear();
                        hasSlash = true;
                        sb.Append('/');
                    }
                    else if(sb.ToString()=="/..")
                    {
                        sb.Clear();
                        sb.Append('/');
                        int last = pathList.Count-1;
                        pathList.RemoveAt(last);
                        hasSlash = true;
                    }
                    else
                    {
                        hasSlash = false;
                        pathList.Add(sb.ToString());
                        sb.Clear();
                        sb.Append('/');
                        hasSlash = true;
                    }
                }
                else
                {
                    sb.Append(path[i]);
                }
            }
            sb.Clear();
            for (int i = 0; i < pathList.Count; i++)
            {
                sb.Append(pathList[i]);
            }
            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }
        static void Main(string[] args)
        {
            string str =reduce_file_path("/home//radorado/code/./hackbulgaria/week0/../");
        }
    }
}
