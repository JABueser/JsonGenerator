using HandlebarsDotNet;
using JsonGenerator.Contracts;
using System;
using System.IO;


namespace JsonGenerator.Services
{
    public class HandlebarsSetup : IHandlebarsSetup
    {
        public void load()
        {
            Handlebars.RegisterHelper("randomRange", RandomRange());
        }

        public HandlebarsHelper RandomRange()
        {
            HandlebarsHelper _randomRange = (TextWriter output, dynamic context, object[] arguments) =>
            {
                var arg1 = arguments[0] as string;
                var arg2 = arguments[1] as string;

                if(arg1.Contains('.') && arg2.Contains('.'))
                {
                    if (Double.TryParse(arg1, out double min) && Double.TryParse(arg2, out double max))
                        output.WriteSafeString(min + new Random().NextDouble() * (max - min));
                    else
                        throw new ArgumentException("Invalid Argument combination in {{randomRange}}");
                }
                else
                {
                    if(Int32.TryParse(arg1, out int min) && Int32.TryParse(arg2, out int max))
                        output.WriteSafeString(new Random().Next(min, max));
                    else
                        throw new ArgumentException("Invalid Arguments combination in {{randomRange}}");
                }
            };

            return _randomRange;
        }
    }
}
