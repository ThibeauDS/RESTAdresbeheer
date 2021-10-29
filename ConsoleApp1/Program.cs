using Datalaag.Repositories;
using System;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string cs = @"Data Source=LAPTOP-Thibeau\SQLEXPRESS;Initial Catalog=AdresBeheer2A;Integrated Security=True";
            GemeenteRepositoryADO repo = new(cs);
            var x = repo.GeefGemeente(10000);
            //Console.WriteLine(x.ToString());
            Console.WriteLine($"{x.NIScode}, {x.Gemeentenaam}");

            StraatRepositoryADO repo2 = new(cs);
            var y = repo2.GeefStratenGemeente(10000);
            //Console.WriteLine(y.ToString());
            foreach (var item in y)
            {
                Console.WriteLine($"{item.ID}, {item.Straatnaam}, {item.Gemeente.NIScode}, {item.Gemeente.Gemeentenaam}");
            }
        }
    }
}
