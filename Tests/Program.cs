using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            SteamClientAPI.SteamClientAPI.Profile profile = new SteamClientAPI.SteamClientAPI.Profile();
            try
            {
                Console.WriteLine("Баланс: " + profile.Balance + " " + profile.Currency);
            }
            catch (SteamClientAPI.Exceptions.SteamMemoryRead)
            {
                Console.WriteLine("Ошибка чтения памяти");
            }
            catch (SteamClientAPI.Exceptions.SteamNotRunning)
            {
                Console.WriteLine("Steam не запущен");
            }
            Console.ReadKey();
        }
    }
}
