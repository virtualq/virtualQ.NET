﻿using System;
using VirtualQNet.Caller;
using VirtualQNet.LineGroups;
using VirtualQNet.Lines;

namespace VirtualQNet
{
    public interface IVirtualQ : IDisposable
    {
        ILinesHandler Lines { get; }
        ILineGroupsHandler LineGroups { get; }
        ICallerHandler Callers { get; }
    }
}
