using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.DTO
{
    public record LocationPostDTO(DateTime StartDate,DateTime EndDate,string City, string Address,int PatientId);
    
}
