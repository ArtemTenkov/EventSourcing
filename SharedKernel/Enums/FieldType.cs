using Newtonsoft.Json;

namespace SharedKernel.Enums
{
    public class FieldType<T>
    {
        [JsonConstructor]
        protected FieldType(T value, string description)
        {
            Value = value;
            Description = description;
        }

        public T Value { get; }
        public string Description { get; }
    }
}
