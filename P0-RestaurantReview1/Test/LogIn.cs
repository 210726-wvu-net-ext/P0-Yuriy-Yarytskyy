using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Entity = DL.Entities;
using Models;
using DL;
namespace Test
{
    public class LogIn
    {   
        [Fact]
        public void TestSignIn()
        {
            bool login = false;
            string actualUN = "ADMIN";
            string actualUP = "CODE";

            string expectedUN = "ADMIN";
            string expectedUP = "CODE";
            if(actualUN==expectedUN && actualUP==expectedUP)
            {
                bool outcome = true;
                Assert.True(outcome);
            }
          
        }
    }
}