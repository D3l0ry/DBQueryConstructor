using System.Text;

using DBQueryConstructor.DatabaseInteractions.Models;
using DBQueryConstructor.QueryInteractions;

namespace DBQueryConstructor.Parameters;

internal class QueryConditionParameter : IComparable<QueryConditionParameter>
{
    public int Index { get; set; }

    public string TableName { get; set; }

    public QueryConditionType Condition { get; set; }

    public string Equal { get; set; }

    public TableColumnModel Column { get; set; }

    public object ParameterValue { get; set; }

    public bool IsNull { get; set; }

    public bool Valid() => Column != null;

    public int CompareTo(QueryConditionParameter other) => Index.CompareTo(other.Index);

    public override string ToString()
    {
        if (Column == null)
        {
            return string.Empty;
        }

        StringBuilder stringBuilder = new StringBuilder();

        string columnName = Column.GetColumnName();
        string value = IsNull ? "NULL" : Handy.TableInteractions.TableProperties.ConvertFieldQuery(ParameterValue);

        stringBuilder.Append(columnName);

        switch (Equal)
        {
            //"Равно","Не равно","Больше","Меньше","Больше либо равно","Меньше либо равно","Промежуток"

            default:
            case "Равно":
                stringBuilder.Append(IsNull ? " IS " : '=');
                break;

            case "Не равно":
                stringBuilder.Append(IsNull ? " IS NOT " : "!=");
                break;

            case "Больше":
                stringBuilder.Append('>');
                break;

            case "Меньше":
                stringBuilder.Append('<');
                break;

            case "Больше либо равно":
                stringBuilder.Append(">=");
                break;

            case "Меньше либо равно":
                stringBuilder.Append("<=");
                break;
        }

        stringBuilder.Append(value);

        return stringBuilder.ToString();
    }
}