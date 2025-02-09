﻿using System;
using System.IO;
using CTFAK.GUI;

namespace CTFAK.Utils
{
    public static class Logger
    {
        static StreamWriter _writer;

        public static void Log(object text, bool logToScreen = true, ConsoleColor color = ConsoleColor.White,
            bool logToConsole = true)
        {
            Log(text.ToString(), logToScreen, color, logToConsole);

        }
        public static void LogWarning(object text)
        {
            Log(text.ToString(), true, ConsoleColor.Yellow, true);

        }
        public static void Log(string text, bool logToScreen = true,ConsoleColor color = ConsoleColor.White, bool logToConsole=true)
        {
            if (logToScreen)
            {
                Console.ForegroundColor = color;
                //Console.WriteLine(Helper.GetCurrentTime() + text);
                Console.ForegroundColor = ConsoleColor.White;
            }
            return;
            if (_writer == null)
            {
                File.Delete("NewLog.log");
                _writer = new StreamWriter("NewLog.log", true);
                _writer.AutoFlush = true;

            }

            //_writer.WriteLine(Helper.GetCurrentTime()+ text);
            
            
            if(logToConsole) MainConsole.Message(text);
                


        }
    }
}
