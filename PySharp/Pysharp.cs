using System;
using PySharp.Interfaces;

namespace PySharp
{
    public class Pysharp : IPy
    {
        private readonly IProcesso _processo;

        public Pysharp(IProcesso processo)
        {
            _processo = processo;
        }
    }
}
