using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuSha.Framework.Common.Enums;
using JuSha.Framework.Common.Helper;
namespace UnitTestProject
{
    [TestClass]
    public class CommonTest
    {
        [TestMethod]
        public void GetEnumDescription()
        {
            var desc= EnumHelper.GetEnumDescription(FuncType.Ajax);
        }

        [TestMethod]
        public void GetEnumAllDescription()
        {
            EnumHelper.GetEnumAllDescription<FuncType>();

        }
        [TestMethod]
        public void MD5Test()
        {
            EncryptHelper.EncryptMd5("jusha");

        }
    }
}
