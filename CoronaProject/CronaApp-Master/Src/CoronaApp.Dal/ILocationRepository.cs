using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Dal;

public interface ILocationRepository
{
    ICollection<Location> Get(LocationSearch locationSearch);
}
