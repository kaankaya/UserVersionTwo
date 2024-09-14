using UserVersionTwo.Entities;

namespace UserVersionTwo.Models
{
    public static class StaticData
    {
        public static List<UserEntity> _users = new List<UserEntity>()
        {
            new UserEntity{Id=1,Name="Sertan",LastName="Bozkuş",Email="sertan@hotmail.com",Birthday = new DateTime(1990,04,04),UserName="sertan",Password="123123",IsActive=true,Role="Admin"},
            new UserEntity{Id=2,Name="Aleyna",LastName="Avcı",Email="aleyna@hotmail.com",Birthday = new DateTime(1995,04,04),UserName="aleyna",Password="123123",IsActive=true,Role="Admin"},
            new UserEntity{Id=3,Name="Ajda",LastName="Pekkan",Email="ajda@hotmail.com",Birthday = new DateTime(1975,04,04),UserName="ajda",Password="123123",IsActive=false,Role="User"},
        };

    }
}
