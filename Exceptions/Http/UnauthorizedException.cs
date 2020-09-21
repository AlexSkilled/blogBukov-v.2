using Microsoft.AspNetCore.Http;
using blogBukov.Exceptions.Http;

namespace BlogForStudents.Exceptions.Http
{
    /// <summary>
    /// Ошибка авторизации (код 401)
    /// </summary>
    public class UnauthorizedException : HttpException
    {
        /// <summary>
        /// Создание экземпляра класса <see cref="UnauthorizedException"/>
        /// </summary>
        /// <param name="errorObject">Объект описания ошибки</param>
        public UnauthorizedException(object errorObject)
            : base(StatusCodes.Status401Unauthorized, errorObject)
        { }

        /// <summary>
        /// Создание экземпляра класса <see cref="UnauthorizedException"/>
        /// </summary>
        public UnauthorizedException()
            : this(null)
        { }
    }
}
