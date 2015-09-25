namespace MyMail2.Security
{
    public interface IEncryptor
    {
        byte[] Encrypt(byte[] originalValue);
        byte[] Decrypt(byte[] encryptedValue); 
    }
}