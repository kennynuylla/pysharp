using System;
using PySharp.Classes;
using PySharp.Interfaces;

namespace PySharp
{
    public class Pysharp : IPy
    {
        private readonly IProcesso _processo;

        public Pysharp()
        {
            _processo = new Processo("/codigo/py/", "python3");
        }

        public void HelloWorld()
        {
            var resposta = _processo.ExecutarArquivo("hello.py");
        }
    }
}
