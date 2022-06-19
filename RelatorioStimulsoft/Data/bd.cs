using System.Data;

namespace RelatorioStimulsoft.Data
{
    public class bd
    {
        private string _connectionString = @"Data Source = DESKTOP-UAD6I0B; Initial Catalog =ControleFinanceiroPessoal; Integrated Security = True";

        public DataTable retornaDataTable<T>(string query) where T : IDbConnection, new()
        {
            using (var conn = new T())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.Connection.ConnectionString = _connectionString;
                    cmd.Connection.Open();
                    var table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    return table;
                }
            }
        }
    }
}
