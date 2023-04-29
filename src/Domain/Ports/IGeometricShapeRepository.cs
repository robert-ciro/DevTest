namespace Domain.Ports;

using Domain.Entities;

public interface IGeometricShapeRepository
{ 
    bool Save(IGeometricShape geometricShape);
    
    bool Update(IGeometricShape geometricShape);

    IEnumerable<IGeometricShape> FindAll();

    bool RemoveAll();
}