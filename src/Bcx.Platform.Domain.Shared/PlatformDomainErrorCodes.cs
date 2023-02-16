using Bcx.Platform.Ingredientes;

namespace Bcx.Platform
{
    public static class PlatformDomainErrorCodes
    {
        /* You can add your business exception error codes here, as constants */
        public const string UserNameNotFound = "";

        public const string Vote_NaoPodeTerVotoDuplicado = "Só pode haver um único voto por usuário em cada receita.";
        public const string Vote_Range_1_5 = "Seu voto deve conter um valor entre 1 e 5";
    }
}
