﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mario
{
    interface IMovable
    {
        void Move();
        MotionState MotionState { get; set; }
    }
}
