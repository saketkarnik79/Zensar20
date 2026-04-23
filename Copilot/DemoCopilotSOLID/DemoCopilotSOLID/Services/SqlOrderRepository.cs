using System.Data.SqlClient;

namespace DemoCopilotSOLID.Services
{
    public class SqlOrderRepository : IOrderRepository
    {
        private readonly string _connectionString;

        public SqlOrderRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public void Save(Order order, decimal total)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand(
                "INSERT INTO Orders (CustomerId, Total) VALUES (@CustomerId, @Total)",
                connection);

            command.Parameters.AddWithValue("@CustomerId", order.CustomerId);
            command.Parameters.AddWithValue("@Total", total);

            command.ExecuteNonQuery();
        }
    }
}