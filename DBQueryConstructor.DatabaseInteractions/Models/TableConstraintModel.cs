using Handy;

namespace DBQueryConstructor.DatabaseInteractions.Models;

[Table("TABLE_CONSTRAINTS", Schema = "INFORMATION_SCHEMA")]
public class TableConstraintModel
{
    [Column("CONSTRAINT_NAME", IsPrimaryKey = true)]
    public string Name { get; set; }

    [Column("TABLE_SCHEMA")]
    public string SchemaName { get; set; }

    [Column("TABLE_NAME")]
    public string TableName { get; set; }

    [Column("CONSTRAINT_TYPE")]
    public string Type { get; set; }
}