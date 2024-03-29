﻿using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Queries.GetDistrictList;
public class GetDistrictListCityListItemDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<DistrictDto> District { get; set; }
}

