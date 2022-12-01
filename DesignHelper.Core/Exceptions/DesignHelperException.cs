namespace DesignHelper.Core.Exceptions
{
    public class DesignHelperException : ApplicationException
    {
        public DesignHelperException()
        {
                
        }

        public DesignHelperException(string errorMessage)
            : base(errorMessage)
        {

        }
    }
}
