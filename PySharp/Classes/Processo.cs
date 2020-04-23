using System;
using System.Diagnostics;
using PySharp.DAO;
using PySharp.Interfaces;

namespace PySharp.Classes
{
    public class Processo : IProcesso
    {
        private readonly string _localArquivosPython;
        private readonly string _comandoPython;

        public Processo(string localArquivosPython, string comandoPython)
        {
            _localArquivosPython = localArquivosPython;
            _comandoPython = comandoPython;
        }

        public ProcessoDAO ExecutarArquivo(string nome, ArgumentosDAO argumentosPython)
        {
            ProcessoDAO retorno = new ProcessoDAO();
            retorno.AlgoErrado = false; //Sou meio paranóico ;-)

            try
            {
                using(Process processo = new Process())
                {
                    processo.StartInfo = new ProcessStartInfo(_comandoPython) 
                    {
                        Arguments = $"{_localArquivosPython}{nome} {argumentosPython}",
                        UseShellExecute = false, //Não usar shell
                        RedirectStandardOutput = true, //Redirecionar a saída para o C#
                        RedirectStandardError = true, //Redirecionar os erros para o C# também
                        CreateNoWindow = true
                    };

                    processo.Start();

                    var saídaSemNovaLinha = processo.StandardOutput.ReadToEnd();
                    saídaSemNovaLinha = saídaSemNovaLinha.Replace(Environment.NewLine, string.Empty);

                    var errosSemNovaLinha = processo.StandardError.ReadToEnd();
                    errosSemNovaLinha = errosSemNovaLinha.Replace(Environment.NewLine, string.Empty);

                    retorno.MensagensTela = saídaSemNovaLinha;
                    retorno.Erros = errosSemNovaLinha;

                    if(!string.IsNullOrEmpty(errosSemNovaLinha))
                    {
                        retorno.AlgoErrado = true;
                    }
                }
            }
            catch(Exception e)
            {
                retorno.ExceçãoCSharp = e.Message;
                retorno.AlgoErrado = true;
            }
            
            return retorno;
        }
    }
}