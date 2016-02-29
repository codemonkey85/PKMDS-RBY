using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace PKMDS_RBY_Lib
{
    [StructLayout(LayoutKind.Explicit, Pack = 1, CharSet = CharSet.Unicode)]
    [Serializable]
    public class Pokemon : IEquatable<Pokemon>, IComparable<Pokemon>
    {
        #region Constructors and Methods

        public Pokemon()
        {
            data = new byte[33];
        }

        public int SortBySpeciesAscending(string name1, string name2)
        {
            return name1.CompareTo(name2);
        }

        public override bool Equals(object obj)
        {
            var objAsPart = obj as Pokemon;
            return objAsPart != null && Equals(objAsPart);
        }

        public int CompareTo(Pokemon comparePokemon)
        {
            if (comparePokemon == null)
                return 1;
            if (comparePokemon.Species == Species.NoSpecies)
                return 0;
            return Species.CompareTo(comparePokemon.Species);
        }

        public override int GetHashCode()
        {
            //return string.Format("{0}-{1}-{2}-{3}", Checksum, PID, EncryptionKey, species).GetHashCode();
            return 0;
        }

        public bool Equals(Pokemon other)
        {
            return other != null && (data.SequenceEqual(other.data));
        }

        public static bool operator ==(Pokemon a, Pokemon b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }
            return (a.data.SequenceEqual(b.data));
        }

        public static bool operator !=(Pokemon a, Pokemon b)
        {
            return !(a == b);
        }

        public bool Equals(Species other)
        {
            return (Species == other);
        }

        public static bool operator ==(Pokemon a, Species b)
        {
            if ((object)a == null)
            {
                return false;
            }
            return (a.Species == b);
        }

        public static bool operator !=(Pokemon a, Species b)
        {
            return !(a == b);
        }

        public void CloneFrom(Pokemon pokemon)
        {
            Array.Copy(pokemon.data, 0, data, 0, 33);
        }

        public static void Swap(Pokemon a, Pokemon b)
        {
            var c = new Pokemon();
            c.CloneFrom(a);
            a.CloneFrom(b);
            b.CloneFrom(c);
        }

        #endregion Constructors and Methods

        #region Data Structure

        [FieldOffset(0x00)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        internal byte[] data;

        private ushort species
        {
            get
            {
                return BitConverter.ToUInt16(data, 0x08);
            }
            set
            {
                Array.Copy(BitConverter.GetBytes(value), 0, data, 0x08, 2);
            }
        }

        #endregion Data Structure

        #region Properties

        [DisplayName("Species")]
        public Species Species
        {
            get
            {
                return Enum.IsDefined(typeof(Species), species)
                    ? (Species)species
                    : Species.NoSpecies;
            }
            set
            {
                species = (ushort)value;
            }
        }

        #endregion Properties
    }
}