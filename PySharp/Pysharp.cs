using System;
using PySharp.Classes;
using PySharp.DAO;
using PySharp.Interfaces;

namespace PySharp
{
    public class Pysharp : IPy
    {
        private readonly IProcesso _processo;
        private readonly string _diretórioPython;
        private readonly string _executávelPython;

        public Pysharp(string diretórioPython, string executávelPython)
        {
            _diretórioPython = diretórioPython;
            _executávelPython = executávelPython;
            
            _processo = new Processo(_diretórioPython, _executávelPython);
        }

        public void HelloWorld()
        {
            var resposta = Executar("hello.py");
        }

        private ProcessoDAO Executar(string arquivo)
        {
            return _processo.ExecutarArquivo(arquivo);
        }
    }
}
