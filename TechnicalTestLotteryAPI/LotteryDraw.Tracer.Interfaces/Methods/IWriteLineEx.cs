using System;
using System.Runtime.CompilerServices;

namespace LotteryDraw.Tracer.Interfaces.Methods
{
    public interface IWriteLineEx
    {
        void WriteLine(Exception ex, [CallerMemberName] string callerid = null);
    }
}
