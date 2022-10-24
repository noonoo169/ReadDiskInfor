using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReadDiskInfor.DTO
{
    public class MyClass
    {
        // import from kernel32.dll function GetDiskFreeSpaceEx (total amount)
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetDiskFreeSpaceEx(string lpDirectoryName,
            out ulong lpFreeBytesAvailable,
            out ulong lpTotalNumberOfBytes,
            out ulong lpTotalNumberOfFreeBytes);

        // import from kernel32.dll function GetDiskFreeSpaceEx
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetDiskFreeSpace(string GetDiskFreeSpace,
                                                out ulong lpSectorsPerCluster,
                                                out ulong lpBytesPerSector,
                                                out ulong lpNumberOfFreeClusters,
                                                out ulong lpTotalNumberOfCluster);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetVolumeInformation(string Volume,
            StringBuilder VolumeName,
            uint VolumeNameSize,
            out uint SerialNumber,
            out uint SerialNumberLength,
            out uint flags,
            StringBuilder fs,
            uint fs_size);
    }
}
