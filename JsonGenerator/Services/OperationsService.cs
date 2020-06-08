using JsonGenerator.Contracts;
using System;


namespace JsonGenerator.Services
{
    public class OperationsService : IOperationsService
    {
        public object getData()
        {
            return new
            {
                random = GetRandomInt(),
                guid = GetGuid()
            };
        }
        protected int GetRandomInt()
        {
            return new Random().Next();
        }
        protected Guid GetGuid()
        {
            return Guid.NewGuid();
        }
    }
}
