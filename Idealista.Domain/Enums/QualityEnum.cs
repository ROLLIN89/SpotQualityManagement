using System.Collections.Generic;

namespace Idealista.Domain.Enums
{
    public sealed class QualityEnum
    {
        public static readonly QualityEnum HD = new QualityEnum(1, "HD");
        public static readonly QualityEnum SD = new QualityEnum(2, "SD");

        public int Id { get; private set; }
        public string Name { get; private set; }

        private QualityEnum(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static IReadOnlyCollection<QualityEnum> GetAll()
        {
            return new[] {
                HD,
                SD
            };
        }
    }
}
