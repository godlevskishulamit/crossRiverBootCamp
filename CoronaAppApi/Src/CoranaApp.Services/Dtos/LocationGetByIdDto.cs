﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Dtos;

public record LocationGetByIdDto(
    int Id,
    DateTime StartDate,
    DateTime EndDate,
    string City,
    string Address
    );
