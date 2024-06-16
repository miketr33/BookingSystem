using AutoMapper;
using EventBookingApi.Dtos;
using EventBookingApi.Models;
using EventBookingShared.Dtos;

namespace EventBookingApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ModifyBookingDto, Booking>().ReverseMap();
        CreateMap<ModifyActivityDto, ActivityDetails>().ReverseMap();
        CreateMap<ModifiedAttendeeDto, Attendee>().ReverseMap();
        CreateMap<Booking, BookingDto>().ReverseMap();
        CreateMap<Attendee, AttendeeDto>().ReverseMap();
        CreateMap<ActivityDetails, ActivityDto>().ReverseMap();
    }
}