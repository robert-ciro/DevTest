namespace Domain
{
    using System.Collections.Generic;
    using Domain.Entities;
    using Domain.Ports;

    public record CalculatedSurfaceArea
    {
       public double SurfaceArea { get; }
       public string ShapeName { get; }
    };
    
    public class SurfaceAreaCalculator
    {
        private List<double> surfaceAreas;

        private readonly IGeometricShapeRepository repository;
        public IReadOnlyList<IGeometricShape> GeometricShapes => repository.FindAll().ToList().AsReadOnly();
        public IReadOnlyList<double> SurfaceAreas => this.surfaceAreas.AsReadOnly();

        public SurfaceAreaCalculator(IGeometricShapeRepository repository)
        {
            this.surfaceAreas = new List<double>();
            this.repository = repository;
        }

        public void Add(IGeometricShape geometryShape)
        {
            repository.Save(geometryShape);
        }

        public void CalculateSurfaceAreas()
        {
            this.surfaceAreas = new List<double>();

            foreach (var geometricShape in this.GeometricShapes)
            {
                this.surfaceAreas.Add(geometricShape.CalculateSurfaceArea());
            }
        }

        public void Reset()
        {
            surfaceAreas = new List<double>();
            repository.RemoveAll();
        }
    }
}