namespace MP.Core.Domain.Validations
{
    internal class DomainValidationException : Exception
    {
        public DomainValidationException(string erro)
            :base(erro)
        { }

        public static void When(bool hasError, string message)
        {
            if(hasError)
            {
                throw new DomainValidationException(message);
            }
        }
    }
}
