using Process.NET;
using Process.NET.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                                    if (mod.Name == "steam.exe")
                                    {

                                        IntPtr addres = Utils.PointRead(Steam, mod.BaseAddress, new[] { 0x001F3F64, 0x1B4 });
                                        byte[] done = process.Memory.Read(addres, 70);
                                        List<byte> donev2 = new List<byte>(); ;
                                        for (int i = 0; i < done.Length; i++)
                                        {
                                            if (done[i] == 0 && done[i + 1] == 0 && done[i + 2] == 0)
                                            {
                                                donev2.Add(done[i]);
                                                break;
                                            }
                                            else
                                            {
                                                donev2.Add(done[i]);
                                            }
                                        }
                                        string donest = Encoding.Unicode.GetString(donev2.ToArray());
                                        return double.Parse(donest);
                                    }
                                }
                            }
                            catch
                            {
                                throw new Exceptions.Steam("Error when trying to get a balance.");
                            }
                        }
                    }
                    else
                    {
                        throw new Exceptions.Steam("Steam is not running.");
                    }
                    return -1;
                }
            }
        }
    }
}
