﻿using System;
using WD7UVN_HFT_2023241.Repository;

namespace WD7UVN_HFT_2023241.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CompanyDbContext dbContext = new CompanyDbContext();
        }
    }
}
