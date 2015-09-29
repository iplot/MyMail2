namespace MyMail2.Security.AsymmetricEngine
{
    public interface IRsaAsymmetricEncryptor : IEncryptor
    {
        byte[] RsaKeys { get; set; }
    }
}