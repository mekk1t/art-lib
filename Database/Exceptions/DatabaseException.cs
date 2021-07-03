using System;

namespace Database.Exceptions
{
    public class DatabaseException : Exception
    {
        private const string MESSAGE_TEMPLATE = "Произошла ошибка сохранения данных в БД: {0} \n";

        public DatabaseException(string message) : base(string.Format(MESSAGE_TEMPLATE, message))
        {
        }

        public DatabaseException(string message, Exception innerException)
            : base(string.Format(MESSAGE_TEMPLATE, message), innerException)
        {
        }
    }
}
