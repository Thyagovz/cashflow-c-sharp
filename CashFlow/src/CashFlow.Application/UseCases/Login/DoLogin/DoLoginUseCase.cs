using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Domain.Security.Tokens;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Login.DoLogin
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IUserReadOnlyRepository _repository;
        private readonly IPasswordEncrypter _passwordEncrypter;
        private readonly IAccessTokenGenerator _acessTokenGenerator;

        public DoLoginUseCase(
            IUserReadOnlyRepository repository,
            IPasswordEncrypter passwordEncrypter,
            IAccessTokenGenerator acessTokenGenerator)
        {
            _passwordEncrypter = passwordEncrypter;
            _repository = repository;
            _acessTokenGenerator = acessTokenGenerator;
        }

        public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
        {
            var user = await _repository.GetUserByEmail(request.Email);

            if (user is null)
            {
                throw new InvalidLoginException();
            }

            var passwordMatch = _passwordEncrypter.Verify(request.Password, user.Password);

            if (passwordMatch == false)
            {
                throw new InvalidLoginException();
            }

            return new ResponseRegisteredUserJson
            {
                Name =user.Name,
                Token = _acessTokenGenerator.Generate(user)
            };
        }

    }
}
