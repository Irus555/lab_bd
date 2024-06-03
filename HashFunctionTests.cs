using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authorization;
using Xunit;

namespace AuthorizationTests
{
    public class HashFunctionTests
    {

        [Theory]
        [InlineData("xUnitHashTest")]

        public void HashTest_ComparisonOfHashingChanges(string pass)
        {
            string expected = "40076BD1300BD843E9DAFC55A4EBA9FF";
            RegForm rh = new RegForm();
            string actual = rh.Hash(pass);

            Assert.Equal(expected, actual);            
        }


        [Theory]
        [InlineData("xUnitHashTestxUnitHashTest")]

        public void HashTest_ComparisonOfDoubleChanges(string pass)
        {
            string expected = "37A46867493C8F671E901A1C5EAE1C3D";
            RegForm rh = new RegForm();
            string actual = rh.Hash(pass);

            Assert.Equal(expected, actual);
        }
    }
}
