﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp;
namespace CSharpTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dic = new Dic();

            Dic.Init();
        }
    }
}
