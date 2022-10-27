using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadDiskInfor.DTO
{
    [Serializable]
    public class DiskInfor
    {
        public StringBuilder VolumeName;
        public uint SerialNumber;
        public ulong TotalDiskSpace;
        public ulong FreeDiskSpace;
        public ulong BytePerSectorNumber;
        public ulong SectoPerClusterNumber;
        public string DiskType;

        public DiskInfor()
        {
            this.VolumeName = new StringBuilder(256);
        }
        public DiskInfor(DiskInfor disk)
        {
            this.VolumeName = disk.VolumeName;
            this.SerialNumber = disk.SerialNumber;
            this.TotalDiskSpace = disk.TotalDiskSpace;
            this.FreeDiskSpace = disk.FreeDiskSpace;
            this.BytePerSectorNumber = disk.BytePerSectorNumber;
            this.SectoPerClusterNumber = disk.SectoPerClusterNumber;
            this.DiskType = disk.DiskType;
        }
        public double ConvertBytesToGigabytes(ulong bytes)
        {
            return Math.Round(((Convert.ToDouble(bytes) / 1024) / 1024) / 1024, 2);
        }

        public void GetDiskSpace(string volumeName, out ulong DiskSpace, out ulong DiskSpaceFree)
        {
            ulong avail = 0;
            MyClass.GetDiskFreeSpaceEx(volumeName, out avail, out DiskSpace, out DiskSpaceFree);
        }

        public string GetDiskType(string drive, StringBuilder VolumeName, out ulong SpC, out ulong BpS, out uint SerialNumber)
        {
            
            ulong NoFC = 0;
            ulong TNoC = 0;
            MyClass.GetDiskFreeSpace(drive, out SpC, out BpS, out NoFC, out TNoC);

            uint SerialNumberLength, fs, CheckType;
            StringBuilder fstype = new StringBuilder(256);
            CheckType = (uint)fstype.Capacity - 1;
            MyClass.GetVolumeInformation(drive, VolumeName, (uint)fstype.Capacity - 1, out SerialNumber, out SerialNumberLength, out fs, fstype, CheckType);
            if (CheckType == 255) return "NTFS";
            else return "FAT";
        }
    }
}
