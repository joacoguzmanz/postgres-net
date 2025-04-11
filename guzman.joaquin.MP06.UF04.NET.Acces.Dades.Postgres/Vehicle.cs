namespace guzman.joaquin.MP06.UF04.NET.Acces.Dades.Postgres;

internal class Vehicle
{
    internal int Id { get; set; }
    internal string Marca { get; set; } = string.Empty;
    internal string Model { get; set; } = string.Empty;
    internal int CapacitatMaleter { get; set; }
}