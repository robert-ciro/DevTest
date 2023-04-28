namespace Domain
{
    using System.Collections.Generic;
    using Domain.Entities;

    public class SurfaceAreaCalculator
    {
        private List<IGeometricShape> geometricShapes;
        private List<double> surfaceAreas;

        public IReadOnlyList<IGeometricShape> GeometricShapes => this.geometricShapes.AsReadOnly();
        public IReadOnlyList<double> SurfaceAreas => this.surfaceAreas.AsReadOnly();

        public SurfaceAreaCalculator()
        {
            this.geometricShapes = new List<IGeometricShape>();
            this.surfaceAreas = new List<double>();
        }

        public void Add(IGeometricShape geometryShape)
        {
            this.geometricShapes.Add(geometryShape);
        }

        public void CalculateSurfaceAreas()
        {
            try
            {
                this.surfaceAreas = new List<double>();

                foreach (var geometricShape in this.geometricShapes)
                {
                    this.surfaceAreas.Add(geometricShape.CalculateSurfaceArea());
                }
            }
            catch
            {
                this.geometricShapes = new List<IGeometricShape>();
            }
        }

        public void Reset()
        {
            this.surfaceAreas = new List<double>();
            this.geometricShapes = new List<IGeometricShape>();
        }
    }
}