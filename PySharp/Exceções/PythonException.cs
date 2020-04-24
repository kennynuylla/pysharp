using System;

namespace PySharp.Exceções
{
    public class PythonException: Exception
    {
        public PythonException(string erro) : base(erro)
        {
            
        }

        public PythonException(string erro, Exception e) : base(erro, e)
        {
            
        }
    }
}