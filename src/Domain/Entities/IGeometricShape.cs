namespace Domain.Entities
{
    public interface IGeometricShape
    {
        Guid Id { get; set; }
        string Name { get; }
        double SurfaceArea { get; }
        double CalculateSurfaceArea();
    }
}