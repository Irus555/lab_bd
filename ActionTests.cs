using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Authorization;
using Xunit;
using System.Threading;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace AuthorizationTests
{
    public class ActionTests
    {

        [Theory]
        [InlineData("xUnitTest", "xUnitTest", "xUnitTestLogin", "xUnitTest")]
        public void AddNewUser_UserShoudAddtoTable(string firstName, string lastName, string login, string password)
        {
            RegForm form = new RegForm();
            form.RegNewUser(firstName, lastName, login, password);
            int id = form.lastIDforTests;
            form.CompareForTests();
            Assert.True(id == form.lastIDforTests && login == form.loginForTests);
        }
        

        [Theory]
        [InlineData("xUnitTestLogin", "xUnitTestLoginRenamed")]
        public void RenameTestLogin_TestLoginShouldRename(string oldLogin, string newLogin)
        {
            RegForm Rform = new RegForm();
            AdminForm Aform = new AdminForm();
            Aform.RenameUser(oldLogin, newLogin);
            Rform.CompareForTests();

            Assert.True(Rform.loginForTests == newLogin);
        }


        [Theory]
        [InlineData("xUnitTestLoginRenamed")]
        public void UserRemoving_RenamedUserShouldDelete(string login)
        {
            RegForm Rform = new RegForm();
            Rform.CompareForTests();
            string uL = Rform.loginForTests;

            Assert.False(uL != login);

            AdminForm Aform = new AdminForm();
            Aform.DeleteUser(login);

            Rform.CompareForTests();
            uL = Rform.loginForTests;

            Assert.True(uL != login);
        }

    }
}
