using TransportWebApp.Domain.Repositories;
using TransportWebApp.Persistence.Data;

namespace TransportWebApp.Persistence.Reposirories;

public class VehicleRepository : IVehicleRepository
{
    private readonly ApplicationDbContext dbContext;

    public VehicleRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
}
