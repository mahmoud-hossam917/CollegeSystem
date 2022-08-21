using AutoMapper;
using CollegeSystem.Models;

namespace CollegeSystem.Helper
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Student, Subject>();
        }
    }
}
