namespace InvestmentDataModel
{
    public class SqlTableMetadata
    {
        public SqlTableMetadata()
        {
            SchemaName = string.Empty;
            TableName = string.Empty;
            KeyName = string.Empty;
            Columns = new();
            Ignored = Array.Empty<string>();
            Conversions = Array.Empty<string>();
        }

        public string SchemaName { get; set; }
        public string TableName { get; set; }
        public string KeyName { get; set; }
        public Dictionary<string, string> Columns { get; set; }
        public string[] Ignored { get; set; }
        public string[] Conversions { get; set; }


        public void Validate()
        {
            if (string.IsNullOrEmpty(SchemaName))
                throw new Exception();

            if (string.IsNullOrEmpty(TableName))
                throw new Exception();

            foreach (var column in Columns.Values)
                if (string.IsNullOrEmpty(column))
                    throw new Exception();
        }
    }
}
