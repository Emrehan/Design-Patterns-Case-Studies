using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design_Patterns.Fake;

namespace Design_Patterns.Behavioral.Strategy
{
    public enum LOGIN_TYPES { PASSWORD, GOOGLE, FACEBOOK };
}

namespace Design_Patterns.Behavioral.Strategy.Old
{
    abstract class LoginBehavior
    {
        LOGIN_TYPES LoginType { get; }
        public abstract bool IsUserExist(string key);
        public abstract bool IsPasswordCorrect(string password);
    }

    class PasswordLogin : LoginBehavior
    {
        private int PasswordLoginFields1;
        private int PasswordLoginFields2;
        private int PasswordLoginFields3;

        public LOGIN_TYPES LoginType { get; } = LOGIN_TYPES.PASSWORD;

        public override bool IsPasswordCorrect(string password)
        {
            return FakeFunction.Check(password);
        }

        public override bool IsUserExist(string key)
        {
            return FakeData.Usernames.Contains(key);
        }
    }

    class GoogleLogin : LoginBehavior
    {
        public LOGIN_TYPES LoginType { get; } = LOGIN_TYPES.GOOGLE;

        public override bool IsPasswordCorrect(string password)
        {            
            return true;
        }

        public override bool IsUserExist(string key)
        {
            return FakeData.Usernames.Contains(key);
        }
    }

    class FacebookLogin : LoginBehavior
    {
        public LOGIN_TYPES LoginType { get; } = LOGIN_TYPES.FACEBOOK;

        public override bool IsPasswordCorrect(string password)
        {
            return true;
        }

        public override bool IsUserExist(string key)
        {
            return FakeFunction.Verify(key);
        }
    }

    class Strategy_OLD
    {
        public static void Main()
        {
            LoginBehavior passwordLogin = new PasswordLogin();
            LoginBehavior googleLogin = new GoogleLogin();
            LoginBehavior facebookLogin = new FacebookLogin();
        }
    }
}
