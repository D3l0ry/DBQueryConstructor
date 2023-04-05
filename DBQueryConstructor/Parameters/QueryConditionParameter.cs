using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

using DBQueryConstructor.DatabaseInteractions.Models;
using DBQueryConstructor.QueryInteractions;

namespace DBQueryConstructor.Parameters;

internal class QueryConditionParameter : IComparable<QueryConditionParameter>, INotifyPropertyChanged
{
    private QueryConditionType _condition;
    private string _equal;
    private TableColumnModel _column;
    private object _parameterValue;
    private bool _isNull;

    public int Index { get; set; }

    public string TableName { get; set; }

    public QueryConditionType Condition
    {
        get => _condition;
        set
        {
            if (_condition == value)
            {
                return;
            }

            _condition = value;
            OnPropertyChanged();
        }
    }

    public string Equal
    {
        get => _equal;
        set
        {
            if (_equal == value)
            {
                return;
            }

            _equal = value;
            OnPropertyChanged();
        }
    }

    public TableColumnModel Column
    {
        get => _column;
        set
        {
            if (_column == value)
            {
                return;
            }

            _column = value;
            OnPropertyChanged();
        }
    }

    public object ParameterValue
    {
        get => _parameterValue;
        set
        {
            if (_parameterValue == value)
            {
                return;
            }

            _parameterValue = value;
            OnPropertyChanged();
        }
    }

    public bool IsNull
    {
        get => _isNull;
        set
        {
            if (_isNull == value)
            {
                return;
            }

            _isNull = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new(propertyName));

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