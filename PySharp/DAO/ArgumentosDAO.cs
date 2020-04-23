using System.Collections.Generic;

namespace PySharp.DAO
{
    public class ArgumentosDAO
    {
        private List<string> _argumentos = new List<string>();

        string this[int i]
        {
            get => _argumentos[i];
            set => _argumentos[i] = value;
        }
        public int Count { get => _argumentos.Count; }

        public void AdicionarArgumento(string argumento)
        {
            _argumentos.Add(argumento);
        }

        public void LimparArgumentos()
        {
            _argumentos = new List<string>();
        }

        public override string ToString()
        {
            var retorno = string.Empty;
            if(Count == 0) return retorno;

            retorno = _argumentos[0];
            for (int i = 1; i < Count; i++)
            {
                retorno = $"{retorno} {_argumentos[i]}";
            }

            return retorno;
        } 
    }
}