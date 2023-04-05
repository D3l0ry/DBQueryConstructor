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

    public static bool operator ==(TableModel x1, TableModel x2) => x1.Equals(x2);

    public static bool operator !=(TableModel x1, TableModel x2) => !x1.Equals(x2);

    public string GetTableName() => $"{Schema}.{Name}";

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }

        return GetTableName() == ((TableModel)obj).GetTableName();
    }

    public override string ToString() => GetTableName();
}
