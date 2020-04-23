using System;
using PySharp;

namespace Testes
{
    class Program
    {
        static void Main(string[] args)
        {
            var python = new Pysharp();
            python.HelloWorld();
        }
    }
}
