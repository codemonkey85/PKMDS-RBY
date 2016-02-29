using System.Data;

namespace PKMDS_RBY_Lib
{
    public static class DBTools
    {
        private static DataTable PokemonDataTable;
        private static DataTable ItemDataTable;
        private static DataTable MoveDataTable;

        public enum MoveDataTableColumns
        {
            id,
            name,
            type_id,
            power,
            pp,
            accuracy,
            flavor_text
        }

        public static DataTable GetMoveDataTable
        {
            get
            {
                return null;
            }
        }
    }
}