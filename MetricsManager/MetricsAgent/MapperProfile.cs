using AutoMapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetric, CpuMetricDto>().
                ForMember(dest => dest.Time, opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
            CreateMap<DotNetMetric, DotNetMetricDto>().
                ForMember(dest => dest.Time, opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
            CreateMap<HddMetric, HddMetricDto>().
                ForMember(dest => dest.Time, opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
            CreateMap<NetworkMetric, NetworkMetricDto>().
                ForMember(dest => dest.Time, opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
            CreateMap<RamMetric, RamMetricDto>().
                ForMember(dest => dest.Time, opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Time)));

            CreateMap<CpuMetricDto, CpuMetric>().
                ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time.ToUnixTimeSeconds()));
            CreateMap<DotNetMetricDto, DotNetMetric>().
                ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time.ToUnixTimeSeconds()));
            CreateMap<HddMetricDto, HddMetric>().
                ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time.ToUnixTimeSeconds()));
            CreateMap<NetworkMetricDto, NetworkMetric>().
                ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time.ToUnixTimeSeconds()));
            CreateMap<RamMetricDto, RamMetric>().
                ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time.ToUnixTimeSeconds()));
        }
    }


}
