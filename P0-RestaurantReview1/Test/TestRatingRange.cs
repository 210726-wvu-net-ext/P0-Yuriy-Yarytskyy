using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Entity = DL.Entities;
using Models;
using DL;
namespace Test
{
    public class TestRatingRange
    {   
        [Fact]
        public void TestRating()
        {
            int rating = 6;
            bool result = true;
        
            if (rating > 5)
        {
             result = false;
        }
        
            Assert.False(result, "Rating range is 1-5");
        }

    }
}