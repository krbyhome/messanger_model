using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace DataAccess.Migration;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create type user_role as enum
        (
            'admin',
            'user'
        );

        create type operation_result as enum
        (
            'success',
            'fail'
        );
        
        create type operation_type as enum
        (
            'withdraw',
            'refill',
            'login',
            'logout',
            'accountcreation'
        );

        create table users
        (
            user_id bigint primary key generated always as identity ,
            user_name text not null ,
            Password text not null,
            user_role user_role not null
        );

        create table bank_account
        (
            account_id bigint primary key generated always as identity ,
            user_id bigint not null references users(user_id),
            name text not null,
            balance bigint not null,
            pin_code text not null
        );

        create table Operations
        (
            user_id text not null,
            account_id text not null,
            type operation_type not null,
            result operation_result not null,
            message text not null
        );
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table users;
        drop table bank_account;
        drop table operations;

        drop type user_role;
        drop type operation_result;
        drop type operation_type;
        """;
}