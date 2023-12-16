using Abstractions.Repositories;
using Application.Account;
using Application.User;
using Contracts.Account;
using Contracts.User;
using DataAccess.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Models.Account;
using Models.Operations;
using Models.Users;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Tests
{
    [Fact]
    public async void OnDepositSavedCorrectly()
    {
        ICurrentUserService user = new CurrentUserManager();
        user.User = new User(1, "krby", "5643", UserRole.User);

        ICurrentAccountService account = new CurrentAccountManager();
        account.Account = new Account(1, 1, "debit", 0, "5643");

        IAccountRepository repository = Substitute.For<IAccountRepository>();
        var service = new AccountService(
            repository,
            new OperationRepository(Substitute.For<IPostgresConnectionProvider>()),
            user,
            account);

        service.DepositMoney(5000);
        await repository.Received().ChangeBalance("debit", 5000).ConfigureAwait(false);
    }

    [Fact]
    public async void OnCorrectWithdrawSavedCorrectly()
    {
        ICurrentUserService user = new CurrentUserManager();
        user.User = new User(1, "krby", "5643", UserRole.User);
        ICurrentAccountService account = new CurrentAccountManager();
        account.Account = new Account(1, 1, "debit", 5000, "5643");

        IAccountRepository repository = Substitute.For<IAccountRepository>();
        var service = new AccountService(
            repository,
            new OperationRepository(Substitute.For<IPostgresConnectionProvider>()),
            user,
            account);

        service.WithdrawMoney(5000);
        await repository.Received().ChangeBalance("debit", 0).ConfigureAwait(false);
    }

    [Fact]
    public async void OnIncorrectWithdrawGetFailure()
    {
        ICurrentUserService user = new CurrentUserManager();
        user.User = new User(1, "krby", "5643", UserRole.User);
        ICurrentAccountService account = new CurrentAccountManager();
        account.Account = new Account(1, 1, "debit", 5000, "5643");

        IAccountRepository repository = Substitute.For<IAccountRepository>();
        var service = new AccountService(
            repository,
            new OperationRepository(Substitute.For<IPostgresConnectionProvider>()),
            user,
            account);

        service.WithdrawMoney(6000);
        Assert.Equal(OperationResult.Fail, service.WithdrawMoney(6000));
        await repository.DidNotReceive().ChangeBalance("debit", 0).ConfigureAwait(false);
    }
}