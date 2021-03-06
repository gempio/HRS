﻿using System;
using System.Linq;

namespace HRS.NunitTests.TestDataClasses
{
    public class TestUtility
    {
        public static string GenerateReservationId()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}