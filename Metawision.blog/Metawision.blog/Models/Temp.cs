using Nethereum.Signer;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metawision.blog.Models
{
    public class Temp
    {
        public int sum(int a , int b)
        {
            return a + b;
        }
        public static int sumStatic(int a , int b)
        {
            return sumPrivate(a, b);
        }
        private static int sumPrivate(int a,int b)
        {
            return a + b;
        }

        public static string CreateAccount()
        {
            EthECKey key = new EthECKey("360df529e9a86041916a8b0a1d32911e65a490e19e6063fc7f685433ff99b711");
            Account account = new Account(key);
            return account.Address;
        }

        public static string GetSessionID()
        {
            return HttpContext.Current.Session.SessionID;
        }

    }
}