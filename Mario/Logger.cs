using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Mario
{
    static class Logger
    {
        private const string _path_ = "./log.txt";

        static Logger()
        {

        }

        public static void Log(string what)
        {
            using (StreamWriter st = new StreamWriter(_path_, true))
            {
                st.WriteLine(what);
            }
        }

        public static void Clear()
        {
            File.Delete(_path_);
        }
    }
}
