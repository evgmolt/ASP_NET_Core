using AutoMapper;
using MetricsManager.DAL.Models;
using MetricsManager.Responses;
using MetricsManager.Responses.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AgentInfo, AgentInfoDto>();

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

            CreateMap<AgentInfoDto, AgentInfo>();

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
