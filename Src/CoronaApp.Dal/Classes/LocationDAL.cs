namespace CoronaApp.Dal.Classes;
public class LocationDAL : ILocationDAL
{
    public async Task<List<Location>> GetAllLocations(string city = "")
    {
        List<Location> result;
        using (var _context = new CoronaContext())
        {
            result = await _context.Location.Where(x => x.City.ToLower().Contains(city.ToLower())).OrderByDescending(x => x.StartDate).ToListAsync();
        }
        return result;
    }

    public async Task<List<Location>> GetLocationsByDate(LocationSearch location)
    {
        List<Location> result;
        using (var _context = new CoronaContext())
        {
            result = await _context.Location.Where(x =>
            ((x.StartDate <= location.StartDate) && (x.EndDate >= location.StartDate)) ||
            ((x.EndDate >= location.EndDate) && (x.StartDate <= location.EndDate)) ||
            ((x.StartDate >= location.StartDate) && (x.StartDate <= location.EndDate))).OrderByDescending(x => x.StartDate).ToListAsync();
        }
        return result;

    }
    public async Task<List<Location>> GetLocationByAge(LocationSearch location)
    {
        List<Location> result;
        using (var _context = new CoronaContext())
        {
            List<string> patientsId = await _context.Patient.Where(x => x.Age == location.Age).Select(x => x.Id).ToListAsync();
            result = await _context.Location.Where(x=>patientsId.Contains(x.PatientId)).OrderByDescending(x => x.StartDate).ToListAsync();
        }
        return result;
        //List<Location> result= await _context.Location.Include(l => l.Patient).Where(x => x.Patient.Age == location.Age).ToListAsync();
        //return result;
    }

    public async Task<List<Location>> GetLocationsPerPatient(string id)
    {
        List<Location> locations;
        using (var _context = new CoronaContext())
        {
            locations = await _context.Location.Where(x => x.PatientId.Equals(id)).ToListAsync();
        }
        return locations;
    }
    public async Task<bool> AddLocation(Location location)
    {
        try
        {
            using (var _context = new CoronaContext())
            {
                await _context.Location.AddAsync(location);
                await _context.SaveChangesAsync();
            }
            return true;
        }
        catch
        {
            return false;
        }

    }
    public async Task<bool> DeleteLocation(int id)
    {
        try
        {
            using (var _context = new CoronaContext())
            {
                _context.Location.Remove(await _context.Location.FirstOrDefaultAsync(x=>x.Id==id));
                await _context.SaveChangesAsync();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
}
