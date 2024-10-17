
using InvestmentDataModel.Model.Configurations;
using Microsoft.EntityFrameworkCore;

namespace InvestmentDataModel
{
    /// <summary>
    ///     Схема иерархии инвест. данных в базе данных SQL.
    /// </summary>
    public class InvestDataMetadata
    {
        public SqlTableMetadata this[SqlTargetTable table] => Metadata![table];       

        public IReadOnlyDictionary<SqlTargetTable, SqlTableMetadata>? Metadata { get; set; }

        public void Validate()
        {
            if (Metadata == null || Metadata.Count == 0)
                throw new Exception("SQL schema is empty.");

            foreach (var table in Metadata.Values)           
                table.Validate();
        }
    }
}
