using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Entities
{
    public class MyMailDataInitializer : DropCreateDatabaseIfModelChanges<MyMailDataContext>
    {
        protected override void Seed(MyMailDataContext context)
        {
            #region USERS
            var user1 = new User
            {
                BirthDate = DateTime.Now,
                City = "Donetsk",
                Country = "Ukraine",
                FirstName = "Dave",
                IdentVector = "Vector",
                WorkPlace = "Home"
            };
            var user2 = new User
            {
                BirthDate = DateTime.Now,
                City = "Kyiv",
                Country = "Ukraine",
                FirstName = "Jon",
                IdentVector = "Vector",
                WorkPlace = "Home"
            };

            var users = new List<User> {user1, user2};
            users.ForEach(x => context.Users.Add(x));
            context.SaveChanges();
            #endregion

            #region ACCOUNT

            var account1 = new Account
            {
                ImapServerHost = "imap.server",
                ImapServerPort = 900,
                SmtpServerHost = "smtp.server",
                SmtpServerPort = 100,
                MailAddress = "me@com",
                MailPassword = "secret",
                UserId = user1.Id
            };

            var account2 = new Account
            {
                ImapServerHost = "imap.server",
                ImapServerPort = 900,
                SmtpServerHost = "smtp.server",
                SmtpServerPort = 100,
                MailAddress = "me@com",
                MailPassword = "secret",
                UserId = user2.Id
            };

            var accounts = new List<Account> {account1, account2};
            accounts.ForEach(x => context.Accounts.Add(x));
            account1.Contacts.Add(account2);
            context.SaveChanges();

            #endregion
        }
    }
}