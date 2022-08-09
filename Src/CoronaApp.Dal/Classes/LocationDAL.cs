namespace CoronaApp.Dal.Classes;

public class LocationDAL : ILocationDAL
{
    public LocationDAL()
    {

    }
    public async Task<List<Location>> GetAllLocations(string city = "")
    {
        using (CoronaContext context = new CoronaContext())
        {
            List<Location> locations = await context.Location.ToListAsync();
            List<Location> result = new List<Location>();
            result.AddRange(locations.FindAll(x => x.City.Contains(city, StringComparison.InvariantCultureIgnoreCase)));
            result.Sort();
            return result;
        }
    }

    public async Task<List<Location>> GetLocationsByDate(LocationSearch location)
    {
        using (CoronaContext context = new CoronaContext())
        {
            List<Location> locations = await context.Location.ToListAsync();
            List<Location> result = new List<Location>();

            result = locations.FindAll(x =>
            ((x.StartDate <= location.StartDate) && (x.EndDate >= location.StartDate)) ||
            ((x.EndDate >= location.EndDate) && (x.StartDate <= location.EndDate)) ||
            ((x.StartDate >= location.StartDate) && (x.StartDate <= location.EndDate)));

            return result;
        }

    }
    public async Task<List<Location>> GetLocationByAge(LocationSearch location)
    {
        using (CoronaContext context = new CoronaContext())
        {
            List<Location> result = new List<Location>();
            List<Location> locations = await context.Location.ToListAsync();
            List<Patient> allPatients = await context.Patient.ToListAsync();
            List<Patient> patients = new List<Patient>();
            patients.AddRange(allPatients.FindAll(x => x.Age == location.Age));
            List<string> patientsId = new List<string>();
            patients.ForEach(x => patientsId.Add(x.Id));
            result = locations.FindAll(x => patientsId.IndexOf(x.PatientId) != -1);
            return result;
        }

    }

    public async Task<List<Location>> GetLocationsPerPatient(string id)
    {
        using (CoronaContext context = new CoronaContext())
        {
            List<Location> list = await context.Location.ToListAsync();
            List<Location> p = list.FindAll(x => x.PatientId.Equals(id));
            return p;
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
