using Handy;

namespace DBQueryConstructor.DatabaseInteractions.Models;

[Table("COLUMNS", Schema = "INFORMATION_SCHEMA")]
public class TableColumnModel
{
    [Column("TABLE_SCHEMA", IsPrimaryKey = true)]
    public string TableSchema { get; set; }

    [Column("TABLE_NAME")]
    public string TableName { get; set; }

    [Column("COLUMN_NAME")]
    public string Name { get; set; }

    [Column("DATA_TYPE")]
    public string Type { get; set; }

    [Column("IS_NULLABLE")]
    public string IsNullable { get; set; }

    public ColumnConstraintModel Constraint { get; set; }

    public string GetTableName() => $"{TableSchema}.{TableName}";

    public string GetColumnName() => $"{TableSchema}.{TableName}.{Name}";

    public override bool Equals(object obj) => GetColumnName() == ((TableColumnModel)obj).GetColumnName();

    public override string ToString() => GetColumnName();
}