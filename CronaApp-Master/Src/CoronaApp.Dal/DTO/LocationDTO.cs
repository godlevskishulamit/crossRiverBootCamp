using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal.DTO;

public record LocationDTO(string Address, string City, DateTime StartDate, DateTime EndDate, string PatientId);

