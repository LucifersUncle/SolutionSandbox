using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using sandbox.web.api.Models;
using System;

namespace sandbox.web.api.Infratsructure.Formatting
{
    /// <summary>
    /// Class <StringOrInt64Serializer> - String property om C# object has Int64 i Mongo Storage otherwise causing an exception
    /// https://stackoverflow.com/questions/41055414/replacement-of-bsonbaseserializer-in-mongodb-driver-v2-4-0
    /// </summary>
    public class StringOrInt64Serializer : SerializerBase<object>
    {
        //static StringOrInt64Serializer()
        //{
        //    if (typeof(object) != typeof(Token) && typeof(object) != typeof(Token?))
        //    {
        //        throw new InvalidOperationException($"StringOrInt64Serializer could be used only with {nameof(Token)} or {nameof(Nullable<Token>)}");
        //    }
        //}
        public override object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            if (context.Reader.CurrentBsonType == MongoDB.Bson.BsonType.Int64)
            {
                return context.Reader.ReadInt64();
            }
            if (context.Reader.CurrentBsonType == MongoDB.Bson.BsonType.String)
            {
                var value = context.Reader.ReadString();
                if (string.IsNullOrWhiteSpace(value))
                {
                    return null;
                }
                return Convert.ToInt64(value);
            }
            context.Reader.SkipValue();
            return null;
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            if (value == null)
            {
                context.Writer.WriteNull();
                return;
            }
            context.Writer.WriteInt64(Convert.ToInt64(value));
        }
    }
}
