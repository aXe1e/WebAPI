using System;
using MetricsAgent.DAL.Models;
using MetricsAgent.DTO;
using AutoMapper;

namespace MetricsAgent.Core
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetric, CpuMetricDto>()
                .ForMember("Time", opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
            CreateMap<DotNetMetric, DotNetMetricDto>()
                .ForMember("Time", opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
            CreateMap<HddMetric, HddMetricDto>()
                .ForMember("Time", opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
            CreateMap<NetworkMetric, NetworkMetricDto>()
                .ForMember("Time", opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
            CreateMap<RamMetric, RamMetricDto>()
                .ForMember("Time", opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));


        }
    }
}
