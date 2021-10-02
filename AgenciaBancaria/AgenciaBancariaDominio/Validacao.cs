using System;

namespace AgenciaBancariaDominio
{
    public static class Validacao
    {
        public static string ValidacaoString(this string texto)
        {
            return string.IsNullOrWhiteSpace(texto) ?
                            throw new Exception("Não pode ser vazio!")
                            : texto;
        }
    }
}