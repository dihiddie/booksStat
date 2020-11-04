namespace BooksStat.BAL.Core.Exceptions
{
    using System;

    public class DatabaseException : Exception
    {
        public DatabaseException(string message)
            : base(message)
        {
        }
    }
}
