using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace AspNetProjectStructure.Helper
{
    public class CustomPasswordValidator : IIdentityValidator<string>
    {
        public int RequiredLength { get; set; }

        public CustomPasswordValidator(int length)
        {
            RequiredLength = length;
        }

        public Task<IdentityResult> ValidateAsync(string item)
        {
            if (String.IsNullOrEmpty(item) || item.Length < RequiredLength)
            {
                return Task.FromResult(IdentityResult.Failed(String.Format("Password length should be more than {0}.", RequiredLength)));
            }

            string pattern = @"^(?=.*\d)(?=.*[a-zA-Z])[0-9a-zA-Z!@#$%^&*]{6,}$";
            if (!Regex.IsMatch(item, pattern))
            {
                return Task.FromResult(IdentityResult.Failed("Password should have numeral and alphabet characters."));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}