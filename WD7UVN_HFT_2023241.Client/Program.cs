using System;
using WD7UVN_HFT_2023241.Repository;
using System.Net.Http.Headers;

namespace WD7UVN_HFT_2023241.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyDbContext dbContext = new CompanyDbContext();
            RestService rest = new RestService("127.0.0.1:5000", "api");
        }
    }
}
