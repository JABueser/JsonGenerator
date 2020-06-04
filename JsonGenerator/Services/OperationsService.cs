using JsonGenerator.Contracts;
using System;


namespace JsonGenerator.Services
{
    public class OperationsService : IOperationsService
    {
        public int GetRandomInt()
        {
            return new Random().Next();
        }

        public Guid GetGuid()
        {
            return Guid.NewGuid();
        }
    }
}
