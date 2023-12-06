using WD7UVN_HFT_2023241.Models;
using 

namespace WD7UVN_HFT_2023241.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RestService rest = new RestService();
            List<Employee> list = rest.Get<Employee>("/api");
        }


    }
}
