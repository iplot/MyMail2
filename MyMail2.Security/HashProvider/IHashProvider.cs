namespace MyMail2.Security.HashProvider
{
    public interface IHashProvider
    {
        byte[] GetHash(byte[] data);
        object CreateHashProviderObject { get; }
    }
}