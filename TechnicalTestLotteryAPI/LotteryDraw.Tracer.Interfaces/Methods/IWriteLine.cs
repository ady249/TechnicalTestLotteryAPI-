using System.Runtime.CompilerServices;

namespace LotteryDraw.Tracer.Interfaces.Methods
{
    public interface IWriteLine
    {
        void WriteLine(string message, [CallerMemberName] string callerid = null);
    }
}
