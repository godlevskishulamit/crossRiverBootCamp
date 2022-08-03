using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal.DTO
{
    public record LocationDTO(int LocaionId,DateTime StartDate,DateTime EndDate, string Address,string City);
    
}
