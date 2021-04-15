using Process.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClientAPI
{
    public static class Utils
    {
        public static IntPtr PointRead(System.Diagnostics.Process procc, IntPtr baseAddres, int[] offsets)
        {
            var vam = new ProcessSharp(procc, Process.NET.Memory.MemoryType.Remote);
            for (int i = 0; i < offsets.Count() - 1; i++)
            {
                baseAddres = vam.Memory.Read<IntPtr>(IntPtr.Add(baseAddres, offsets[i]));
            }
            return baseAddres + offsets[offsets.Count() - 1];
        }
    }
}
