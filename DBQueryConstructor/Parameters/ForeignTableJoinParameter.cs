using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

using DBQueryConstructor.DatabaseInteractions.Models;
using DBQueryConstructor.QueryInteractions;

namespace DBQueryConstructor.Parameters;

internal class ForeignTableJoinParameter : IComparable<ForeignTableJoinParameter>, INotifyPropertyChanged
{
    private TableColumnModel _mainColumn;
    private TableColumnModel _joinedColumn;
    private QueryJoinType _join;

    public int Index { get; set; }

    public string TableName { get; set; }

    public TableColumnModel MainColumnTable
    {
        get => _mainColumn;
        set
        {
            if (_mainColumn == value)
            {
                return;
            }

            _mainColumn = value;
            OnPropertyChanged();
        }
    }

    public TableColumnModel JoinedColumnTable
    {
        get => _joinedColumn;
        set
        {
            if (_joinedColumn == value)
            {
                return;
            }

            _joinedColumn = value;
            OnPropertyChanged();
        }
    }

    public QueryJoinType Join
    {
        get => _join;
        set
        {
            if (_join == value)
            {
                return;
            }

            _join = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new(propertyName));

    public bool Validate() => JoinedColumnTable != null && MainColumnTable != null;

    public int CompareTo(ForeignTableJoinParameter other) => Index.CompareTo(other.Index);

    public override string ToString()
    {
        if (MainColumnTable == null || JoinedColumnTable == null)
        {
            return string.Empty;
        }

        StringBuilder stringBuilder = new StringBuilder();

        switch (Join)
        {
            case QueryJoinType.Join:
                stringBuilder.Append("JOIN ");
                break;

            case QueryJoinType.LeftJoin:
                stringBuilder.Append("LEFT JOIN ");
                break;
        }

        string joinTableName = JoinedColumnTable.GetTableName();
        string joinTableColumn = JoinedColumnTable.GetColumnName();
        string mainTableColumn = MainColumnTable.GetColumnName();

        stringBuilder.Append(joinTableName);
        stringBuilder.Append(" ON ");
        stringBuilder.Append(joinTableColumn);
        stringBuilder.Append('=');
        stringBuilder.Append(mainTableColumn);

        return stringBuilder.ToString();
    }
}