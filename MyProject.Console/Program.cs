using MyProject.Mock;
using MyProject.Repositories;
using MyProject.Repositories.Repositories;
using System;

namespace MyProject.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            //create instance of MockContext
            var mockContext = new MockContext();

            //create repository and send the MockContext to the ctor
            var roleRepository = new RoleRepository(mockContext);

            roleRepository.GetAll().ForEach(r => Console.WriteLine(r.ToString()));

            Console.WriteLine("=========================");

            var role =  roleRepository.Add(3, "secretary", "all office access");
            roleRepository.GetAll().ForEach(r => Console.WriteLine(r.ToString()));


            var role1 = roleRepository.GetById(1);
            role1.Name = "Administrator";
            roleRepository.Update(role1);
        }
    }
}
