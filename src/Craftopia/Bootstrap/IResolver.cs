﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Craftopia.Bootstrap
{
    public interface IResolver
    {
        T Resolve<T>();
    }
}