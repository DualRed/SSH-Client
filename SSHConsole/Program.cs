using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;

namespace SSHConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string host = @"localhost";
            string username = "sshuser";
            string password = @"Baolinhkg44";

            using (var client = new SshClient(host, username, password))
            {

                //Start the connection
                client.Connect();
                while (true)
                {
                    Console.Write("Write command here: ");
                    String command = Console.ReadLine();
                    if (command == "exit")
                        break;
                    Console.WriteLine("-------------------");
                    Console.WriteLine("Result: ");
                    Console.WriteLine("-------------------");
                    SshCommand output = client.RunCommand(command);
                    string answer = output.Result;
                    Console.WriteLine(answer);
                }
                client.Disconnect();
            }
        }
    }
}
