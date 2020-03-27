using System;

namespace PlazaProject
{
    class Program
    {
        static void Main(string[] args)
        {
            CmdProgram cmdProgram = new CmdProgram(args);
            cmdProgram.run();
        }
    }
}
