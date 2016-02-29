using System;

namespace PKMDS_RBY_Lib
{
    public interface ISave
    {
    }

    //[StructLayout(LayoutKind.Explicit, Size = 0x100000, Pack = 1, CharSet = CharSet.Unicode)]
    [Serializable]
    public class RBSave : ISave
    {
    }

    //[StructLayout(LayoutKind.Explicit, Size = 0x100000, Pack = 1, CharSet = CharSet.Unicode)]
    [Serializable]
    public class YSave : ISave
    {
    }
}