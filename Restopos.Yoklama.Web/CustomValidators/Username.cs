using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.CustomValidators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class Username : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            //oRneK12_
            Regex regex = new Regex(@"^[a-zA-Z0-9_]{5,20}$");

            return regex.IsMatch((string)value);
        }

        public override string FormatErrorMessage(string errorMessage)
        {
            return "Kullanıcı adınız en az 5 en fazla 20 karakter olabilir." +
                " Büyük/küçük harf, sayı ve alt çizgi barındırabilir." +
                " Türkçe karakter içeremez.";
        }
    }
}
