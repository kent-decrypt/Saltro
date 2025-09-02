using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Saltro.Application.Exceptions;

/// <summary>
/// Instance of ProblemDetails Exception.
/// </summary>
public class ProblemDetailsException : Exception
{
    public ProblemDetails Details { get; private set; }

    public ProblemDetailsException(int statusCode) => Details = new() { Status = statusCode };

    public ProblemDetailsException(int statusCode, string title) => Details = new() { Status = statusCode, Title = title };

    public ProblemDetailsException(int statusCode, string title, Exception ex) : base(title, ex) => Details = new() { Status = statusCode, Title = title };

    public ProblemDetailsException(ProblemDetails details) => Details = details;

    public ProblemDetailsException(ProblemDetails details, Exception ex) : base(details.Title, ex) => Details = details;

    #region Static Functions

    #region == Error 400 Functions ==
    /// <summary>
    /// Returns a new instance of ProblemDetailsException with a 400 Status Code
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    public static ProblemDetailsException BadRequestException(string title) => new(StatusCodes.Status400BadRequest, title);

    /// <summary>
    /// Returns a new instance of ProblemDetailsException with a 400 Status Code
    /// </summary>
    /// <param name="title"></param>
    /// <param name="ex"></param>
    /// <returns></returns>
    public static ProblemDetailsException BadRequestException(string title, Exception ex) => new(StatusCodes.Status400BadRequest, title, ex);

    /// <summary>
    /// Returns a new instance of ProblemDetailsException with a 400 Status Code
    /// </summary>
    /// <param name="details"></param>
    /// <returns></returns>
    public static ProblemDetailsException BadRequestException(ProblemDetails details)
    {
        details.Status = StatusCodes.Status400BadRequest;
        return new ProblemDetailsException(details);
    }

    /// <summary>
    /// Returns a new instance of ProblemDetailsException with a 400 Status Code
    /// </summary>
    /// <param name="details"></param>
    /// <param name="ex"></param>
    /// <returns></returns>
    public static ProblemDetailsException BadRequestException(ProblemDetails details, Exception ex)
    {
        details.Status = StatusCodes.Status400BadRequest;
        return new ProblemDetailsException(details, ex);
    }
    #endregion

    #region == Error 404 Functions ==
    /// <summary>
    /// Returns a new instance of ProblemDetailsException with a 404 Status Code
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    public static ProblemDetailsException NotFoundException(string title) => new(StatusCodes.Status404NotFound, title);

    /// <summary>
    /// Returns a new instance of ProblemDetailsException with a 404 Status Code
    /// </summary>
    /// <param name="title"></param>
    /// <param name="ex"></param>
    /// <returns></returns>
    public static ProblemDetailsException NotFoundException(string title, Exception ex) => new(StatusCodes.Status404NotFound, title, ex);

    /// <summary>
    /// Returns a new instance of ProblemDetailsException with a 404 Status Code
    /// </summary>
    /// <param name="details"></param>
    /// <returns></returns>
    public static ProblemDetailsException NotFoundException(ProblemDetails details)
    {
        details.Status = StatusCodes.Status404NotFound;
        return new ProblemDetailsException(details);
    }

    /// <summary>
    /// Returns a new instance of ProblemDetailsException with a 404 Status Code
    /// </summary>
    /// <param name="details"></param>
    /// <param name="ex"></param>
    /// <returns></returns>
    public static ProblemDetailsException NotFoundException(ProblemDetails details, Exception ex)
    {
        details.Status = StatusCodes.Status404NotFound;
        return new ProblemDetailsException(details, ex);
    }
    #endregion

    #region == Error 500 Functions ==
    /// <summary>
    /// Returns a new instance of ProblemDetailsException with a 500 Status Code
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    public static ProblemDetailsException InternalServerException(string title) => new(StatusCodes.Status500InternalServerError, title);

    /// <summary>
    /// Returns a new instance of ProblemDetailsException with a 500 Status Code
    /// </summary>
    /// <param name="title"></param>
    /// <param name="ex"></param>
    /// <returns></returns>
    public static ProblemDetailsException InternalServerException(string title, Exception ex) => new(StatusCodes.Status500InternalServerError, title, ex);

    /// <summary>
    /// Returns a new instance of ProblemDetailsException with a 500 Status Code
    /// </summary>
    /// <param name="details"></param>
    /// <returns></returns>
    public static ProblemDetailsException InternalServerException(ProblemDetails details)
    {
        details.Status = StatusCodes.Status500InternalServerError;
        return new ProblemDetailsException(details);
    }

    /// <summary>
    /// Returns a new instance of ProblemDetailsException with a 500 Status Code
    /// </summary>
    /// <param name="details"></param>
    /// <param name="ex"></param>
    /// <returns></returns>
    public static ProblemDetailsException InternalServerException(ProblemDetails details, Exception ex)
    {
        details.Status = StatusCodes.Status500InternalServerError;
        return new ProblemDetailsException(details, ex);
    }
    #endregion

    #endregion
}