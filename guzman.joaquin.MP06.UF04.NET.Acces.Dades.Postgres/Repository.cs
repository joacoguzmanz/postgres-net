using Npgsql;

namespace guzman.joaquin.MP06.UF04.NET.Acces.Dades.Postgres;

internal class VehicleRepository(string connectionString)
{
    private readonly string _connectionString = connectionString;

    public void Crear(Vehicle vehicle)
    {
        using var conn = new NpgsqlConnection(_connectionString);
        conn.Open();
        var cmd = new NpgsqlCommand("INSERT INTO vehicles (marca, model, capacitat_maleter) VALUES (@marca, @model, @capacitat_maleter)", conn);
        cmd.Parameters.AddWithValue("@marca", vehicle.Marca);
        cmd.Parameters.AddWithValue("@model", vehicle.Model);
        cmd.Parameters.AddWithValue("@capacitat_maleter", vehicle.CapacitatMaleter);
        cmd.ExecuteNonQuery();
    }

    public List<Vehicle> ListarTodos()
    {
        var vehicles = new List<Vehicle>();
        using var conn = new NpgsqlConnection(_connectionString);
        conn.Open();
        var cmd = new NpgsqlCommand("SELECT * FROM vehicles", conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            vehicles.Add(new Vehicle
            {
                Id = reader.GetInt32(0),
                Marca = reader.GetString(1),
                Model = reader.GetString(2),
                CapacitatMaleter = reader.GetInt32(3)
            });
        }
        return vehicles;
    }

    public void Actualitzar(Vehicle vehicle)
    {
        using var conn = new NpgsqlConnection(_connectionString);
        conn.Open();
        var cmd = new NpgsqlCommand("UPDATE vehicles SET marca = @marca, model = @model, capacitat_maleter = @capacitat_maleter WHERE id = @id", conn);
        cmd.Parameters.AddWithValue("@marca", vehicle.Marca);
        cmd.Parameters.AddWithValue("@model", vehicle.Model);
        cmd.Parameters.AddWithValue("@capacitat_maleter", vehicle.CapacitatMaleter);
        cmd.Parameters.AddWithValue("@id", vehicle.Id);
        cmd.ExecuteNonQuery();
    }

    public void Eliminar(int vehicleId)
    {
        using var conn = new NpgsqlConnection(_connectionString);
        conn.Open();
        var cmd = new NpgsqlCommand("DELETE FROM vehicles WHERE id = @id", conn);
        cmd.Parameters.AddWithValue("@id", vehicleId);
        cmd.ExecuteNonQuery();
    }
}