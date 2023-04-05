using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

using DBQueryConstructor.DatabaseInteractions.Models;

namespace DBQueryConstructor.Parameters;

internal class QueryFieldParameter : INotifyPropertyChanged
{
    private string _columnAlias;

    public TableColumnModel Column { get; set; }

    public string ColumnAlias
    {
        get => _columnAlias;
        set
        {
            if (_columnAlias == value)
            {
                return;
            }

            _columnAlias = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new(propertyName));

    public bool Valid() => Column != null;

    public override string ToString()
    {
        if (Column == null)
        {
            return string.Empty;
        }

        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append(Column.GetColumnName());

        if (!string.IsNullOrWhiteSpace(ColumnAlias))
        {
            stringBuilder.Append(" AS ");
            stringBuilder.Append('[');
            stringBuilder.Append(ColumnAlias);
            stringBuilder.Append(']');
        }

        return stringBuilder.ToString();
    }
}