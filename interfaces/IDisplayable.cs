﻿using DotAgro.graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAgro.interfaces
{
    internal interface IDisplayable
    {
        List<ProfileFrame> profileFrames { get; }

        void Initialization();
    }
}
