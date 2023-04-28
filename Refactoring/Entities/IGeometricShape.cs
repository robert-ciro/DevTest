namespace Refactoring.Entities
{
    public interface IGeometricShape
    {
        string Name { get; }
        double CalculateSurfaceArea();
    }
}