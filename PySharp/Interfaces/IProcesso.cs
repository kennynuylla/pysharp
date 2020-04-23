using PySharp.DAO;

namespace PySharp.Interfaces
{
    public interface IProcesso
    {
        ProcessoDAO ExecutarArquivo(string Nome); 
    }
}