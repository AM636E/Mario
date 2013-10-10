﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Mario
{
    static class console
    {
        private const string _path_ = "./log.txt";

        static console()
        {

        }

        public static void log(params string[] what)
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
