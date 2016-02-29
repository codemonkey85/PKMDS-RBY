using System.IO;
using System.Runtime.InteropServices;

namespace PKMDS_RBY_Lib
{
    public class StructUtils
    {
        public static TType RawDeserialize<TType>(byte[] rawData, int position = 0)
        {
            var anyType = typeof(TType);
            var rawsize = Marshal.SizeOf(anyType);
            if (rawsize > rawData.Length) return default(TType);
            var buffer = Marshal.AllocHGlobal(rawsize);
            Marshal.Copy(rawData, position, buffer, rawsize);
            var retobj = Marshal.PtrToStructure(buffer, anyType);
            Marshal.FreeHGlobal(buffer);
            return (TType)retobj;
        }

        public static TType RawDeserialize<TType>(string fileName, int position = 0)
        {
            if (!File.Exists(fileName)) return default(TType);
            byte[] data;
            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var br = new BinaryReader(fs))
                {
                    data = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();
                }
            }
            return RawDeserialize<TType>(data, position);
        }

        private static void RawSerialize(object anything, string fileName)
        {
            if (anything == null || string.IsNullOrEmpty(fileName))
            {
                return;
            }
            var data = RawSerialize(anything);
            if (data == null) return;
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                using (var bw = new BinaryWriter(fs))
                {
                    bw.Write(data);
                    bw.Close();
                    fs.Close();
                }
            }
        }

        private static byte[] RawSerialize(object anything)
        {
            var rawSize = Marshal.SizeOf(anything);
            var buffer = Marshal.AllocHGlobal(rawSize);
            Marshal.StructureToPtr(anything, buffer, false);
            var rawDatas = new byte[rawSize];
            Marshal.Copy(buffer, rawDatas, 0, rawSize);
            Marshal.FreeHGlobal(buffer);
            return rawDatas;
        }

        public static FileInfo GetTempFileInfo()
        {
            return new FileInfo(Path.GetTempFileName());
        }

        public static FileStream GetTempFileStream(FileMode fileMode, FileAccess fileAccess)
        {
            return new FileStream(Path.GetTempFileName(), fileMode, fileAccess);
        }

        public static void WriteObject<T>(T _object, string fileName)
        {
            if (_object == null || !(_object is ISave)) return;
            RawSerialize(_object, fileName);
        }
    }
}