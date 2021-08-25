using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Entity = DL.Entities;
using Models;
using DL;
namespace Test
{
    public class TestRatingAvg
    {   
        [Fact]
        public void TestRating()
        {
            int sum = 0; 
            int tracker = 0;
            decimal actual, expected;
            decimal[] NumOfRatings = {4,3,2,1,5,5,5,3,4,4,1,3,4,5,3};

            for (int i = 0; i < NumOfRatings.Length; i++)
            {
                sum+=i;
                tracker++;
            }
            actual = sum/tracker;
            expected = 3.46m;
            if(actual==expected)
            {
                bool outcome = true;
                Assert.True(outcome);
            }
        }


    }
}