using System;

namespace SystemVerifyKnowledge.Common
{
    public record Student
    {
        public ulong Id { get; init; }
        public byte ProgramGroupId { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Surname { get; init; }
        public ushort PassportSerie { get; init; }
        public uint PassportNumber { get; init; }
        public DateTime DateStartTest { get; init; }
        public DateTime DateEndTest { get; init; }
    }
}
