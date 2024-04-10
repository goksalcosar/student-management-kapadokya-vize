using Öğrenci_İşleri_Otomasyonu.DataObjects;
using Öğrenci_İşleri_Otomasyonu.Definition;

namespace Öğrenci_İşleri_Otomasyonu.DataTransferObject.UserDataModel
{
    public static class SelectUserDataOperations
    {
        public static Object GetAllStudent()
        {
            return (from item in (new MainContext()).StudentManagementContext.Users
                    where item.Role == UserDefinition.Student
                    select new
                    {
                        Öğrenci_ID = item.Id,
                        Öğrenci = item.Name + " " + item.Surname,
                        Öğrenci_TC_No = item.TcNo,
                        Öğrenci_Adres = item.Address,
                        Öğrenci_Dogum_Tarihi = item.BirthDate,
                        Öğrenci_Yetki = item.Role,
                        Hesap_Aktiflik_Durumu = item.IsActive ? "Aktif" : "Pasif",
                    }).ToList();
        }

        public static Object getAllTeacher()
        {
            return (from item in (new MainContext()).StudentManagementContext.Users
                    where item.Role == UserDefinition.Teahcer
                    select new
                    {
                        Öğretmen_ID = item.Id,
                        Öğretmen = item.Name + "" + item.Surname,
                        Öğretmen_TC_No = item.TcNo,
                        Öğretmen_Adres = item.Address,
                        Öğretmen_Dogum_Tarihi = item.BirthDate,
                        Öğretmen_Yetki = item.Role,
                        Hesap_Aktiflik_Durumu = item.IsActive ? "Aktif" : "Pasif",
                        Branşı = item.Expertise
                    }).ToList();
        }

        public static Dictionary<int, string> getTeacher()
        {
            return (from item in (new MainContext()).StudentManagementContext.Users
                    where item.Role == UserDefinition.Teahcer
                    select new
                    {
                        item.Id,
                        item.Name
                    })
                     .AsEnumerable()
                    .ToDictionary(
                        x => x.Id,
                        x => x.Name
                    );
        }

        public static Dictionary<string, string> getStudent()
        {
            return (from item in (new MainContext()).StudentManagementContext.Users
                    where item.Role == UserDefinition.Student
                    select new
                    {
                        item.Name,
                        item.Surname
                    })
                     .AsEnumerable()
                    .ToDictionary(
                        x => x.Name,
                        x => x.Surname
                    );
        }

        public static User GetFindByIdUser(int userId, StudentManagementContext studentManagementContext)
        {
            return studentManagementContext.Users.Find(userId);
        }

        public static User GetFindByNameUser(string name, StudentManagementContext studentManagementContext)
        {
            return studentManagementContext.Users.FirstOrDefault(f => f.Name == name);
        }

        public static User GetFindByLastNameCitionNumber(string lastName, string citionNumber, StudentManagementContext studentManagementContext)
        {
            return studentManagementContext.Users.FirstOrDefault(f => f.Surname == lastName && f.TcNo == citionNumber);
        }

        public static User GetFindByNameTeacher(string name, StudentManagementContext studentManagementContext)
        {
            return studentManagementContext.Users.FirstOrDefault(f => f.Name == name && f.Role == "Öğretmen");
        }

        public static User GetFindByNameStudent(string name, StudentManagementContext studentManagementContext)
        {
            return studentManagementContext.Users.FirstOrDefault(f => f.Name == name && f.Role == "Öğrenci");
        }

        public static User GetFindByCitionNumberPassowrd(string citionNumber, string password, StudentManagementContext studentManagementContext)
        {
            return studentManagementContext.Users.FirstOrDefault(f => f.TcNo == citionNumber && f.Password == password);
        }

        public static User GetFindByFullNameStudent(string fullName, StudentManagementContext studentManagementContext)
        {
            return studentManagementContext.Users.FirstOrDefault(u => (u.Name + " " + u.Surname) == fullName && u.Role == "Öğrenci");
        }
    }
}
