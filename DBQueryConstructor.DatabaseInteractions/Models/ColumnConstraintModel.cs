using Handy;

namespace DBQueryConstructor.DatabaseInteractions.Models;

[Table("CONSTRAINT_COLUMN_USAGE", Schema = "INFORMATION_SCHEMA")]
public class ColumnConstraintModel
{
    [Column("CONSTRAINT_NAME", IsPrimaryKey = true)]
    public string Name { get; set; }

    [Column("TABLE_SCHEMA")]
    public string SchemaName { get; set; }

    [Column("TABLE_NAME")]
    public string TableName { get; set; }

    [Column("COLUMN_NAME")]
    public string ColumnName { get; set; }
}