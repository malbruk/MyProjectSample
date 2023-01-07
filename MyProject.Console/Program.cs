using MyProject.Mock;
using MyProject.Repositories;
using MyProject.Repositories.Repositories;
using System;
using System.Linq;

namespace MyProject.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var mock = new MockContext();
            //    Console.ForegroundColor = ConsoleColor.Cyan;

            //    //create instance of MockContext
            //    var mockContext = new MockContext();

            //    //create repository and send the MockContext to the ctor
            //    var roleRepository = new RoleRepository(mockContext);

            //    roleRepository.GetAll().ForEach(r => Console.WriteLine(r.ToString()));

            //    Console.WriteLine("=========================");

            //    var role = roleRepository.Add(3, "secretary", "all office access");
            //    roleRepository.GetAll().ForEach(r => Console.WriteLine(r.ToString()));


            //    var role1 = roleRepository.GetById(1);
            //    role1.Name = "Administrator";
            //    roleRepository.Update(role1);


            //    int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            //    var numQuery = numbers.Where(num => (num % 2) == 0);

            //    var numQuery2 =
            //                            from num in numbers
            //                            where (num % 2) == 0
            //                            select num;

        }
    }
}
