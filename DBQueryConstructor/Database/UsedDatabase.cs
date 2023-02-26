using DBQueryConstructor.Database.Models;

using Handy;
using Handy.MsSql;

namespace DBQueryConstructor.Database
{
    internal class UsedDatabase : DatabaseContext
    {
        public UsedDatabase(string connection) : base(connection) { }

        public Table<TableModel> Table => GetTable<TableModel>();

        public Table<TableColumnModel> TableColumn => GetTable<TableColumnModel>();

        public Table<TableConstraintModel> TableConstraint => GetTable<TableConstraintModel>();

        public Table<ColumnConstraintModel> ColumnConstraint => GetTable<ColumnConstraintModel>();

        protected override void OnConfigure(ContextOptionsBuilder options) => options.UseSqlServer();
    }
}