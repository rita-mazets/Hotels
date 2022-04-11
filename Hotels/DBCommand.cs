using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels
{
    public static class DBCommand
    {
        public static string SelecIdtUser = "SELECT Id FROM Users WHERE Login=@login";
        public static string conecctionSring= ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static string SelectUser = "SELECT Login, Password,Name, Surname, MiddleName, PassportSeries, PassportNumber,Telephone, Email FROM Users WHERE Login=@login AND Password=@password";
        public static string InsertUser = "INSERT INTO Users (Login, Password, Name, Surname, Middlename,PassportSeries, PassportNumber,Telephone, Email) " +
                                          "VALUES(@login, @password,@name, @surname, @middlename,@passportSeries, @passportNumber,@telephone, @email)";
        public static string SelectLoginUser = "Select @count=COUNT(Login) From Users Where Login=@login";
        public static string UpdateUser = "Update Users " +
                                          "SET Name=@name, Surname=@surname, Middlename=@middlename," +
                                          "Password=@password,PassportSeries=@passportSeries," +
                                          "PassportNumber=@passportNumber, Telephone=@telephone,Email=@email " +
                                          "WHERE Login=@login";

        public static string CountHotel = "SELECT COUNT([Id]) FROM[Application].[dbo].[Hotels]";

        public static string ReadNumber = "SELECT * FROM Number WHERE IdHotels=@id";

        public static string SearchHotelContry = "SELECT *" +
                                                "FROM[Application].[dbo].[Hotels]" +
                                                "JOIN[Application].[dbo].[Address]" +
                                                "ON[Address].[IdHotel]=[Hotels].[Id]" +
                                                "WHERE[Address].[Country]=@country AND [Address].[City]=@city ";

        public static string ReadHotel = "SELECT *" +
                                         "FROM [Hotels]" +
                                         "JOIN [Address]" +
                                         "ON [Address].[IdHotel]=[Hotels].[id]"+
                                         "Where [Hotels].[Id]=@id1 or [Hotels].[Id]=@id2 or [Hotels].[Id]=@id3 or [Hotels].Id=@id4 ";

        public static string ReadHotelsId = "SELECT Hotels.id FROM Hotels";
        public static string Command1= "SELECT *"+
                                       "FROM[Hotels]"+
                                       "JOIN[Address]"+
                                       "ON[Address].[IdHotel]=[Hotels].[id]"+
                                       "Where[Address].[Country]=@country";
        public static string Command2 = "SELECT *" +
                                      "FROM[Hotels]" +
                                      "JOIN[Address]" +
                                      "ON[Address].[IdHotel]=[Hotels].[id]" +
                                      "Where[Address].[Country]=@country and [Address].[City]=@city";
        public static string Command3 = "SELECT *" +
                                      "FROM[Hotels]" +
                                      "JOIN[Address]" +
                                      "ON[Address].[IdHotel]=[Hotels].[id]" +
                                      "Where[Address].[Country]=@country and [Address].[City]=@city and [Hotels].[BeginPrice]>@begin";
        public static string HotelAccauntId = "SELECT id " +
                                             "FROM[Hotels] " +
                                             "Where[Hotels].[Name]=@name";

        public static string SearchNumber = "SELECT distinct Name, Price, Type, Capacity, BedType, [Number].[Id] " +
                                           "FROM[Hotels].[dbo].[Number] " +
                                           "LEFT JOIN[Reserv] ON[Reserv].[IdNumbers]=[Number].[Id] " +
                                           "WHERE[IdHotels]=@id and([Type]= @type2 or[Type]= @type3 or[Type]= @type4 or[Type]= @type5 or[Type]= @type6 or[Type]= @type1) and " +
                                           "([Capacity]= @ctype1 or[Capacity]= @ctype2 or[Capacity]= @ctype3 or[Capacity]= @ctype4) and " +
                                           "([BedType]= @btype1 or[BedType]= @btype2 or[BedType]= @btype3) and " +
                                           "(([BeginD]>@endD or [EndD]<@beginD)  or ([BeginD]=null or [EndD]=null))";

        public static string SearchAllNumber = "SELECT distinct Name, Price, Type, Capacity, BedType, Id " +
                                         "FROM[Hotels].[dbo].[Number] " +
                                         "WHERE[IdHotels]=@id ";




        public static string SelectDateId = "SELECT [Id] "+
                                            "FROM [Reserv] " +
                                            "WHERE[IdNumbers]=@id  and(([BeginD]<@begin and [EndD]>@begin) or([BeginD]>@begin and [EndD]<@end))";


        public static string InsertDate = "INSERT INTO[Reserv] ([BeginD], [EndD], [IdNumbers], [IdUsers]) " +
                                          "VALUES(@begin, @end, @numberId, @userId)";

        public static string InsertDateAdmin = "INSERT INTO[Reserv] ([BeginD], [EndD], [IdNumbers], [IdAdmin]) " +
                                          "VALUES(@begin, @end, @numberId, @userId)";


        public static string SearchAdmin = "SELECT [Admin].[Id],[Login],[Password],[Key], [IdHotel] "+
                                           "FROM[Admin] "+
                                           "JOIN[Key] ON[Admin].[Key]=[Key].[Word] "+
                                           "WHERE[Login]=@login and[Password]=@password and [Key]=@key";

        public static string SearchKey = "SELECT id FROM [KEY] WHERE [Key].[Word]=@key";
        public static string InsertAdmin= "INSERT INTO[Admin] ([Login], [Password], [Key]) " +
                                          "VALUES(@login, @password, @key)";

        public static string SelectAllDate = "SELECT [Reserv].[id],[BeginD], [EndD], [Users].[Login], [Admin].[Login]"+
                                             "FROM[Hotels].[dbo].[Reserv] "+
                                             "LEFT JOIN[Users] ON[Users].[Id]=[Reserv].[IdUsers] "+
                                             "LEFT JOIN[Admin] ON[Admin].[Id]=[Reserv].[IdAdmin] "+
                                             "WHERE[IdNumbers]=@id ";

        public static string DeleteDate = "Delete [Reserv] Where[Id]=@id";



    }
}