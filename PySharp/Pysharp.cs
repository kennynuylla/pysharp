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

        private readonly ArgumentosDAO _argumentosPython;

        public Pysharp(string diretórioPython, string executávelPython)
        {
            _diretórioPython = diretórioPython;
            _executávelPython = executávelPython;
            
            _processo = new Processo(_diretórioPython, _executávelPython);
            _argumentosPython = new ArgumentosDAO();
        }

        public void AdicionarArgumento(string argumento) => _argumentosPython.AdicionarArgumento(argumento);
        public void LimparArgumentos() => _argumentosPython.LimparArgumentos();

        public ProcessoDAO Executar(string arquivo)
        {
            return _processo.ExecutarArquivo(arquivo, _argumentosPython);
        }
    }
}
