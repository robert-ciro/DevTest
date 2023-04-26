namespace Refactoring
{
    using System;
    using System.Collections.Generic;
    using Refactoring.Entities;

    public class SurfaceAreaCalculator
    {
        private List<IGeometricShape> geometricShapes;
        private List<double> surfaceAreas;
        private readonly ILogger logger;

        public IReadOnlyList<IGeometricShape> GeometricShapes => this.geometricShapes.AsReadOnly();
        public IReadOnlyList<double> SurfaceAreas => this.surfaceAreas.AsReadOnly();

        public SurfaceAreaCalculator(ILogger logger)
        {
            this.geometricShapes = new List<IGeometricShape>();
            this.surfaceAreas = new List<double>();
            this.logger = logger;
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
            catch (Exception ex)
            {
                this.logger.Log(ex.ToString());
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