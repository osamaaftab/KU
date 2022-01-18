using AutoMapper;
using KU_Banking.Configuration.MappingEntities;

namespace KU_Banking.Configuration {
    public class MappingProfile : MapperConfigurationExpression {
        public MappingProfile() {
            new AccountMappingProfile();
        }
    }
}
