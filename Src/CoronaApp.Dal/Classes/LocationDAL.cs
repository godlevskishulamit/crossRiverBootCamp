namespace CoronaApp.Dal.Classes;

public class LocationDAL : ILocationDAL
{
    public LocationDAL()
    {

    }
    public async Task<List<Location>> GetAllLocations()
    {
        using (CoronaContext context = new CoronaContext())
        {
            return await context.Location.ToListAsync();
        }
    }
    public async Task<List<Location>> GetLocationsByCity(string city)
    {
        using (CoronaContext context = new CoronaContext())
        {
            return await context.Location.Where(c => c.City.ToLower().Contains(city.ToLower())).ToListAsync();
        }
    }

    public async Task<List<Location>> GetLocationsByDate(LocationSearch location)
    {
        using (CoronaContext context = new CoronaContext())
        {
            return await context.Location.Where(x =>
            ((x
            .StartDate <= location.StartDate) && (x.EndDate >= location.StartDate)) ||
            ((x.EndDate >= location.EndDate) && (x.StartDate <= location.EndDate)) ||
            ((x.StartDate >= location.StartDate) && (x.StartDate <= location.EndDate))).ToListAsync();
        }

    }
    public async Task<List<Location>> GetLocationByAge(LocationSearch location)
    {
        using (CoronaContext context = new CoronaContext())
        {
            List<string> patientsId = await context.Patient.Where(p => p.Age == location.Age).Select(p => p.Id).ToListAsync();
            return await context.Location.Where(l => patientsId.Contains(l.PatientId)).OrderByDescending(l => l.StartDate).ToListAsync();
        }
    }

    public async Task<List<Location>> GetLocationsByPatient(string id)
    {
        using (CoronaContext context = new CoronaContext())
        {
            return await context.Location.Where(l => l.PatientId.Equals(id)).ToListAsync();
        }

    }
    public async Task<bool> AddLocation(Location location)
    {
        try
        {
            using (CoronaContext context = new CoronaContext())
            {
                await context.Location.AddAsync(location);
                await context.SaveChangesAsync();
                return true;
            }
        }
        catch
        {
            return false;
        }

    }
    public async Task<bool> DeleteLocation(Location location)
    {
        try
        {
            using (CoronaContext context = new CoronaContext())
            {
                context.Location.Remove(location);
                await context.SaveChangesAsync();
                return true;
            }

        }
        catch
        {
            return false;
        }
    }
}
