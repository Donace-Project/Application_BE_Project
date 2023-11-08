namespace Application_BE_Project.Exceptions;

public class FriendlyException : Exception
{
    public string Code { get; private set; } = string.Empty;

    public FriendlyException()
    {
    }

    public FriendlyException(string code, string message)
        : base(message)
    {
        Code = code;
    }

    public FriendlyException(string code, string message, Exception innerException)
        : base(message, innerException)
    {
        Code = code;
    }

    public FriendlyException(string code, string format, params object[] args)
        : base(string.Format(format, args))
    {
        Code = code;
    }

    public FriendlyException WithData(string key, object value)
    {
        Data[key] = value;
        return this;
    }
}
