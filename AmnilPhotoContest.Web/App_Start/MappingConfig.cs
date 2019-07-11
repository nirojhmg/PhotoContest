using AmnilPhotoContest.Business;
using AmnilPhotoContest.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmnilPhotoContest.Web
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<District, DistrictDTO>().ReverseMap();
                config.CreateMap<Contestant, ContestantDTO>().ReverseMap();
                config.CreateMap<ContestantRating, ContestantRatingDTO>().ReverseMap();
                config.CreateMap<ContestantRatingModel, ContestantRatingDTO>().ReverseMap();
            });
        }
    }
}