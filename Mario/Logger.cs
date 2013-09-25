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

        public static void Log(params string[] what)
        {
            using (StreamWriter st = new StreamWriter(_path_, true))
            {
                foreach ( var i in what )
                {
                    st.WriteLine(i);
                }
            }
        }

        public static void Clear()
        {
            File.Delete(_path_);
        }
    }
}
