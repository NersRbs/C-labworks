using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Infrastructure.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        $"""
         CREATE TABLE Account (
             id BIGINT PRIMARY KEY,
             hashed_pin_code VARCHAR(255),
             balance DECIMAL(10, 2)
         );

         CREATE TABLE History (
             id BIGSERIAL PRIMARY KEY,
             account_id BIGINT,
             date_time TIMESTAMP,
             amount DECIMAL(10, 2)
         );

         CREATE TABLE  Admin (
             hashed_pin_code VARCHAR(255)
         );

         INSERT INTO Admin (hashed_pin_code) VALUES ('$2a$11$1ykb6xHRpv8P7E9te5R35eI2lh5vaUcLoOOubzxt.32AY/q6Hhz3K');
         """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        $"""
         DROP TABLE Account;

         DROP TABLE History;

         DROP TABLE Admin;
         """;
}