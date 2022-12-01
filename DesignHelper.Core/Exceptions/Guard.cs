using DesignHelper.Core.Exceptions;
using DesignHelper.Core.Exceptions;

namespace DesignHelper.Core.Exceptions
{
    public class Guard : IGuard
    {
        public void AgainstNull<T>(T value, string? errorMessage = null)
        {
            if (value == null)
            {
                var exception = errorMessage == null ?
                    new DesignHelperException() :
                    new DesignHelperException(errorMessage);
                
                throw exception;
            }
        }
    }
}
