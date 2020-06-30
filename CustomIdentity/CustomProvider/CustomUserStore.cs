using CustomIdentity.CustomProvider.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomIdentity.CustomProvider
{
    public class CustomUserStore : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>
    {
        private ApplicationDbContext context;
        public CustomUserStore(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userId == null)
                throw new ArgumentNullException(nameof(userId));
            return Task.Factory.StartNew(() =>
            {
                ApplicationUser user = this.context.Users.Get(userId);
                return user;
            }) ;
        }

        public Task<ApplicationUser> FindByNameAsync(string userName, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (userName == null)
                throw new ArgumentNullException(nameof(userName));
            return Task.Factory.StartNew(() =>
            {
                ApplicationUser user = this.context.Users.GetAll().FirstOrDefault(u => u.Username.ToUpper() == userName);
                return user;
            });
        }

        public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.ID.ToString());
        }

        public Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.Username);
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.Password);
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Factory.StartNew(() =>
            {
                user.Password = passwordHash;
            });
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            bool result = user.Password != null ? true : false;
            return Task.FromResult(result);
        }

        public Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return Task.Factory.StartNew(() =>
            {
                this.context.Users.Create(user);
                return IdentityResult.Success;
            });
        }

        public Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
