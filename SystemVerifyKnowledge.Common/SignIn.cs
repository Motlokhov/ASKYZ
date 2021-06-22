namespace SystemVerifyKnowledge.Common
{
    public struct SignIn
    {
        public ulong Id { get; init; }
        public string Password { get; init; }

        public SignIn(ulong id, string password)
        {
            Id = id;
            Password = password;
        }
    }
}
