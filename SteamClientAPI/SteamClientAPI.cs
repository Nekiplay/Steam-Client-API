using Process.NET;
using Process.NET.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SteamClientAPI
{
    public class SteamClientAPI
    {
        public static System.Diagnostics.Process Steam_Process
        {
            get
            {
                foreach (System.Diagnostics.Process temp in System.Diagnostics.Process.GetProcessesByName("steam"))
                {
                    if (temp.MainWindowTitle.Contains("Steam"))
                    {
                        return temp;
                    }
                }
                return null;
            }
        }

        public class Profile
        {
            public double Balance
            {
                get
                {
                    System.Diagnostics.Process Steam = Steam_Process;
                    if (Steam != null)
                    {
                        var process = new ProcessSharp(Steam, MemoryType.Remote);
                        if (process != null)
                        {
                            try
                            {
                                foreach (Process.NET.Modules.RemoteModule mod in process.ModuleFactory.RemoteModules.ToList())
                                {
                                    if (mod.Name == "steamui.dll")
                                    {
                                        IntPtr addres = Utils.PointRead(Steam, mod.BaseAddress, new[] { 0x00B621B0, 0x7C, 0x24, 0x130, 0x98, 0x1D0, 0x90 });
                                        Console.WriteLine(addres.ToString("X"));
                                        byte[] done = process.Memory.Read(addres, 70);
                                        string donest2 = Encoding.Unicode.GetString(done.ToArray());
                                        string donest3 = Regex.Match(donest2, "^(.*) ").Groups[1].Value;
                                        return double.Parse(donest3);
                                    }
                                }
                            }
                            catch
                            {
                                throw new Exceptions.SteamMemoryRead("Error when trying to get a balance.");
                            }
                        }
                        else
                        {
                            throw new Exceptions.SteamNotRunning("Process connection error.");
                        }
                    }
                    else
                    {
                        throw new Exceptions.SteamNotRunning("Steam is not running.");
                    }
                    return -1;
                }
            }

            public string Currency
            {
                get
                {
                    System.Diagnostics.Process Steam = Steam_Process;
                    if (Steam != null)
                    {
                        var process = new ProcessSharp(Steam, MemoryType.Remote);
                        if (process != null)
                        {
                            try
                            {
                                foreach (Process.NET.Modules.RemoteModule mod in process.ModuleFactory.RemoteModules.ToList())
                                {
                                    if (mod.Name == "steamui.dll")
                                    {
                                        IntPtr addres = Utils.PointRead(Steam, mod.BaseAddress, new[] { 0x00B621B0, 0x7C, 0x24, 0x130, 0x98, 0x1D0, 0x90 });
                                        byte[] done = process.Memory.Read(addres, 70);
                                        string donest2 = Encoding.Unicode.GetString(done.ToArray());
                                        string a = string.Join("", Regex.Matches(donest2, "[а-я]", RegexOptions.IgnoreCase).Cast<object>());
                                        if (string.IsNullOrEmpty(a))
                                        {
                                            a = string.Join("", Regex.Matches(donest2, "[a-z]", RegexOptions.IgnoreCase).Cast<object>());
                                        }
                                        return a;
                                    }
                                }
                            }
                            catch
                            {
                                throw new Exceptions.SteamMemoryRead("Error when trying to get a currency.");
                            }
                        }
                        else
                        {
                            throw new Exceptions.SteamNotRunning("Process connection error.");
                        }
                    }
                    else
                    {
                        throw new Exceptions.SteamNotRunning("Steam is not running.");
                    }
                    return "";
                }
            }
        }
    }
}
