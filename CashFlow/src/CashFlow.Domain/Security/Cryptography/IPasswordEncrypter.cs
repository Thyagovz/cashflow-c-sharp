namespace CashFlow.Domain.Security.Cryptography;
public interface IPasswordEncrypter
{
    string Encrypt(string password);
    bool Verify(object password1, object password2);
}
