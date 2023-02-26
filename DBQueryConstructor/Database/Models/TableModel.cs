using Handy;

namespace DBQueryConstructor.Database.Models
{
    [Table("TABLES", Schema = "INFORMATION_SCHEMA")]
    internal class TableModel
    {
        [Column("TABLE_NAME", IsPrimaryKey = true)]
        public string Name { get; set; }

        [Column("TABLE_SCHEMA")]
        public string Schema { get; set; }

        public TableColumnModel[] Columns { get; set; }

        public string GetTableName() => $"{Schema}.{Name}";

        public override string ToString() => GetTableName();
    }
}
