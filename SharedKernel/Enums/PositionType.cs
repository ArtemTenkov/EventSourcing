using Newtonsoft.Json;

namespace SharedKernel.Enums
{
    public class PositionType : FieldType<int>
    {
        public static PositionType NotSet => new PositionType(-1, "Type was not set");
        public static PositionType Worker => new PositionType(0, "Just a regular worker");
        public static PositionType Manager => new PositionType(1, "Boss");
        public static PositionType Parse(int positionType)
        {
            if (positionType == Worker.Value)
                return Worker;

            if (positionType == Manager.Value)
                return Manager;

            return NotSet;

        }
        [JsonConstructor]
        protected PositionType(int value, string description) : base(value, description)
        {
        }
    }
}
