using Handy;

namespace DBQueryConstructor.DatabaseInteractions.Models;

[Table("TABLES", Schema = "INFORMATION_SCHEMA")]
public class TableModel
{
    [Column("TABLE_NAME", IsPrimaryKey = true)]
    public string Name { get; set; }

    [Column("TABLE_SCHEMA")]
    public string Schema { get; set; }

    public TableColumnModel[] Columns { get; set; }

    public string GetTableName() => $"{Schema}.{Name}";

    public override string ToString() => GetTableName();
}
