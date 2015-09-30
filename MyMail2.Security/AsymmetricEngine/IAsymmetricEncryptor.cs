namespace MyMail2.Security.AsymmetricEngine
{
    public interface IAsymmetricEncryptor : IEncryptor
    {
        byte[] RsaKeys { get; set; }
    }
}