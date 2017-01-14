using System;
using System.Diagnostics;
using LotteryDraw.Tracer.Interfaces;

namespace LotteryDraw.Tracer.DebugTracer
{
    public class DebugTracer : ITracer  
    {
        public void WriteLine(string message, string callerid = null)
        {
            Debug.WriteLine($"Caller: {callerid}; Message: {message}");
        }

        public void WriteLine(Exception ex, string callerid = null)
        {
            WriteLine(ex.Message, callerid);
        }
    }
}
