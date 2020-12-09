using System.Collections.Generic;

namespace Idealista.Domain.Enums
{
    public sealed class TypologyEnum
    {
        public static readonly TypologyEnum Chalet = new TypologyEnum(1, "CHALET");
        public static readonly TypologyEnum Flat = new TypologyEnum(2, "FLAT");
        public static readonly TypologyEnum Garage = new TypologyEnum(3, "GARAGE");

        public int Id { get; private set; }
        public string Name { get; private set; }

        private TypologyEnum(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static IReadOnlyCollection<TypologyEnum> GetAll()
        {
            return new[] {
                Chalet,
                Flat,
                Garage
            };
        }
    }
}
