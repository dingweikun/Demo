﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Module
{
    public interface IProjectModule
    {
        string ModuleTitle { get; }

        bool IsInEdit { get; }
    }
}