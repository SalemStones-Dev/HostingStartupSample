using Interface;
using System;

namespace Library;

public class Handler : IHandler
{
    public string HandleRequest(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException("value");
        }

        return $"Handled request with argument '{value}'.";
    }
}
