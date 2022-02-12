using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design_Patterns.Fake;

namespace Design_Patterns.Behavioral.Strategy.New
{
    abstract class LoginBehavior
    {
        LOGIN_TYPES LoginType { get; set; }
        private IIuserExistBehavior isUserExist;
        private IIsPasswordCorrect isPasswordCorrect;

        public LoginBehavior(LOGIN_TYPES loginType, IIuserExistBehavior isUserExist, IIsPasswordCorrect isPasswordCorrect)
        {
            LoginType = loginType;
            this.isUserExist = isUserExist;
            this.isPasswordCorrect = isPasswordCorrect;
        }

        public bool IsUserExist(string key) => isUserExist.IsUserExist(key);
        public bool IsPasswordCorrect(string password) => isPasswordCorrect.IsPasswordCorrect(password);

    }

    #region USEREXIST
    interface IIuserExistBehavior
    {
        bool IsUserExist(string key);
    }

    public class IsUserExistServer : IIuserExistBehavior
    {
        public bool IsUserExist(string key) => FakeData.Usernames.Contains(key);
    }

    public class IsUserExistNoCheck : IIuserExistBehavior
    {
        public bool IsUserExist(string key) => true;
    }
    #endregion

    #region PASSWORDCORRECT
    interface IIsPasswordCorrect
    {
        bool IsPasswordCorrect(string password);
    }

    public class IsPasswordCorrectServer : IIsPasswordCorrect
    {
        public bool IsPasswordCorrect(string password) => FakeFunction.Check(password);
    }

    public class IsPasswordCorrectRemote : IIsPasswordCorrect
    {
        public bool IsPasswordCorrect(string password) => FakeFunction.Verify(password);
    } 
    #endregion

    class PasswordLogin : LoginBehavior
    {
        //PasswordLogin spesific fields
        private int PasswordLoginFields1;
        private int PasswordLoginFields2;
        private int PasswordLoginFields3;

        public PasswordLogin(IIuserExistBehavior user, IIsPasswordCorrect pass, int passwordLoginFields1, int passwordLoginFields2)
            : base(LOGIN_TYPES.PASSWORD, user, pass)
        {
            PasswordLoginFields1 = passwordLoginFields1;
            PasswordLoginFields2 = passwordLoginFields2;
        }
    }

    class GoogleLogin : LoginBehavior
    {
        //GoogleLogin spesific fields
        private const string uri = "google.com";
        public GoogleLogin(IIuserExistBehavior isUserExist, IIsPasswordCorrect isPasswordCorrect) 
            : base(LOGIN_TYPES.GOOGLE, isUserExist, isPasswordCorrect)
        {
        }
    }

    class BasicLogin : LoginBehavior
    {
        public BasicLogin(LOGIN_TYPES login_type, IIuserExistBehavior isUserExist, IIsPasswordCorrect isPasswordCorrect) 
            : base(login_type, isUserExist, isPasswordCorrect)
        {
        }
    }

    class Strategy_NEW
    {
        public static void Main()
        {
            LoginBehavior passwordLogin = new PasswordLogin (                      new IsUserExistServer() , new IsPasswordCorrectServer(), 1, 2);
            LoginBehavior googleLogin   = new GoogleLogin   (                      new IsUserExistNoCheck(), new IsPasswordCorrectRemote()      );
            LoginBehavior facebookLogin = new BasicLogin    (LOGIN_TYPES.FACEBOOK, new IsUserExistNoCheck(), new IsPasswordCorrectRemote()      );

            var login = passwordLogin;
            if (login.IsUserExist("Emrehan") && login.IsPasswordCorrect("123"))
            {
                //LOGIN SUCCESS
            }
            else
            {
                //LOGIN FAILED
            }
        }
    }
}
