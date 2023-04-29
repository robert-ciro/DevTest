namespace Infrastructure.FileDB;

using Domain.Entities;
using Domain.Ports;
using LiteDB;

public class GeometricShapeRepository :  IGeometricShapeRepository
{
    private readonly LiteDatabase database;

    public GeometricShapeRepository(LiteDatabase database)
    {
        this.database = database;
    }

    public bool Save(IGeometricShape geometricShape)
    {
        return database.GetCollection<IGeometricShape>().Insert(geometricShape) != null;
    }

    public bool Update(IGeometricShape geometricShape)
    {
        return database.GetCollection<IGeometricShape>().Update(geometricShape);
    }

    public IEnumerable<IGeometricShape> FindAll()
    {
        return database.GetCollection<IGeometricShape>().FindAll();
    }
    
    public bool RemoveAll()
    {
        return database.DropCollection(nameof(IGeometricShape));
    }
}