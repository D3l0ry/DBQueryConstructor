using System.Text;

using DBQueryConstructor.Database.Models;

namespace DBQueryConstructor.QueryInteractions
{
    internal class QueryConditionParameter
    {
        public QueryConditionType Condition { get; set; }

        public string Equal { get; set; }

        public TableColumnModel Column { get; set; }

        public object ParameterValue { get; set; }

        public bool Valid() => Column != null && ParameterValue != null;

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            string columnName = Column.GetColumnName();
            string value = Handy.TableInteractions.TableProperties.ConvertFieldQuery(ParameterValue);

            stringBuilder.Append(columnName);

            switch (Equal)
            {
                //"Равно", "Не равно", "Диапазон", "Промежуток"
                default:
                case "Равно":
                stringBuilder.Append('=');
                break;

                case "Не равно":
                stringBuilder.Append("!=");
                break;
            }

            stringBuilder.Append(value);

            return stringBuilder.ToString();
        }
    }
}