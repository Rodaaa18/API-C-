using System;
using System.Text.Json;

namespace Services.Common.Mapping
{
    public static class DTOMapperExtension
    {

        public static T MapTo<T>(this object value)
        {
            var serialize = JsonSerializer.Serialize(value);
            Console.WriteLine(serialize);            
            var deserialize = JsonSerializer.Deserialize<T>(serialize);
            Console.WriteLine(deserialize);
            return deserialize;
        }
    }
}
