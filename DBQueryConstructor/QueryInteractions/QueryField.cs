using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DBQueryConstructor.Database.Models;

namespace DBQueryConstructor.QueryInteractions
{
    internal class QueryField
    {
        public TableColumnModel Column { get; set; }

        public string ColumnAlias { get; set; }

        public bool Valid() => Column != null;

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(Column.GetColumnName());

            if(!string.IsNullOrWhiteSpace(ColumnAlias))
            {
                stringBuilder.Append(" AS ");
                stringBuilder.Append('[');
                stringBuilder.Append(ColumnAlias);
                stringBuilder.Append(']');
            }

            return stringBuilder.ToString();
        }
    }
}