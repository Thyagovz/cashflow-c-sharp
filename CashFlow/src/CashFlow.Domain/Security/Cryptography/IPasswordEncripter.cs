namespace CashFlow.Domain.Security.Cryptography;
public interface IPasswordEncripter
{
    string Encrypt(string password);
    bool Verify(object password1, object password2);
}
