using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Interface
{
    public interface ISnsService
    {
        Task PublishAsync(string message);

    }
}
