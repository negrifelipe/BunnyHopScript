using Memory;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace Feli.BunnyHopScript
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(ushort virtualKeyCode);

        private static Mem _mem = new Mem();

        static void Main(string[] args)
        {
            Console.WriteLine("Bunny Hop Script made by Feli (https://github.com/01-Feli/)");
            Console.WriteLine("Loading Cheat...");
            Console.WriteLine("Getting Process...");
            Process csgo = Process.GetProcessesByName("csgo").FirstOrDefault();
            while (csgo == null)
            {
                csgo = Process.GetProcessesByName("csgo").FirstOrDefault();
            }

            Console.WriteLine("Process is ready !");
            _mem.OpenProcess(csgo.Id);
            Thread bhopThread = new Thread(Bhop);
            bhopThread.Start();
        }

        private static void Bhop()
        {
            Console.WriteLine("Cheat is ready !");
            while (true)
            {
                if (GetAsyncKeyState(32) < 0)
                {
                    if (_mem.ReadInt("client.dll+0xD8B2DC,0x104", "") == 257)
                    {
                        _mem.WriteMemory("client.dll+0x524CE84", "int", "6");
                    }
                }
            }
        }
    }
}
