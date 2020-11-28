using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.CustomValidators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    /*sealed*/
    public class PasswordValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            //En az 1 sayi,//En az 1 kucuk harf,En az 1 buyuk harf, bosluk karakteri olmayacak 
            //En az 6 en fazla 20 karakter
            Regex regex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{6,20}$");

            return regex.IsMatch((string)value);
        }

        public override string FormatErrorMessage(string name)
        {
            return
                "Şifrenizde az 6 en fazla 20 karakter olmalı ve en az bir tane sayı, küçük harf ve büyük harf barındırmalı.";
        }
    }
}
