namespace MyMail2.Security.SignEngine
{
    public interface ISignProvider
    {
        byte[] Keys { get; set; }
        byte[] SignData(byte[] data);
        bool VerifySign(byte[] data, byte[] signature);
    }
}