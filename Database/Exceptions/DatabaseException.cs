using System;

namespace Database.Exceptions
{
    public class DatabaseException : Exception
    {
        private const string MESSAGE_TEMPLATE = "Произошла ошибка при работе с БД: {0} \n";

        public DatabaseException(string message) : base(string.Format(MESSAGE_TEMPLATE, message))
        {
        }

        public DatabaseException(string message, Exception innerException)
            : base(string.Format(MESSAGE_TEMPLATE, message), innerException)
        {
        }
    }
}
