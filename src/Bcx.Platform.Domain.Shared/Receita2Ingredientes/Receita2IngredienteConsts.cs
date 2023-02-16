namespace Bcx.Platform.Receita2Ingredientes
{
    public static class Receita2IngredienteConsts
    {
        public const byte QuantidadeRangeStart = 0;
        public const int QuantidadeRangeEnd = int.MaxValue;
        public const byte UnidadeMaxLength = 120;

        public const string IngredienteIdIsRequired = "Você precisa informar um ingrediente!";
        public const string ReceitaIdIsRequired = "Você precisa informar uma receita!";
        public const string QuantidadeIsRequired = "Qual a quantidade do ingrediente é necessária?";
        public const string QuantidadeOutOfRange = "Quantidade precisa de um valor inteiro positivo";
        public const string UnidadeIsRequired = "Qual a unidade de medida?";
        public const string UnidadeLessThenMaxLength = "A palavra da unidade de medida não pode ter mais do que 120 caracteres";
    }
}
