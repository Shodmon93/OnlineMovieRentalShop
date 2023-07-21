using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Web;
using VidlyWithData.Dtos;
using VidlyWithData.Models;

namespace VidlyWithData.App_Start
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());


            Mapper.CreateMap<Movie, MovieDto>()
                .ForMember(m=> m.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());


        }

    }
}