namespace MyMail2.Security.SymmetricEngine
{
    public interface ISymmetricEncryptor : IEncryptor
    {
        byte[] Key { get; set; }
        byte[] IdentVector { get; set; }
    }
}