using System;

namespace JsonGenerator.Contracts
{
    public interface IOperationsService
    {
        int GetRandomInt();
        Guid GetGuid();
    }
}
