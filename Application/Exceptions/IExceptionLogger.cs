using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public interface IExceptionLogger
    {
        void Log(Exception ex);
    }
}
