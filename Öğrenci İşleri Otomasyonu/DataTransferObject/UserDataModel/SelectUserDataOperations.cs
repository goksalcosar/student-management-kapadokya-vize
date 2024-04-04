using Microsoft.EntityFrameworkCore;
using Öğrenci_İşleri_Otomasyonu.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Öğrenci_İşleri_Otomasyonu.DataTransferObject.UserDataModel
{
    public static class SelectUserDataOperations
    {
        public static Object GetAllUser()
        {
            return (from item in (new MainContext()).StudentManagementContext.Users
                    select new
                    {
                        Kullanıcı_ID = item.Id,
                        Kullanıcı = item.Name + "" + item.Surname,
                        Kullanıcı_TC_No = item.TcNo,
                        Kullanıcı_Dogum_Tarihi = item.BirthDate,
                        Kullanıcı_Yetki = item.Role,
                        Hesap_Aktiflik_Durumu = item.IsActive ? "Aktif" : "Pasif",
                    }).ToList();
        }

        public static Object getAllTeacher()
        {
            return (from item in (new MainContext()).StudentManagementContext.Users
                    where item.Role != "Öğrenci"
                    select new
                    {
                        Kullanıcı_ID = item.Id,
                        Kullanıcı = item.Name + "" + item.Surname,
                        Kullanıcı_TC_No = item.TcNo,
                        Kullanıcı_Dogum_Tarihi = item.BirthDate,
                        Kullanıcı_Yetki = item.Role,
                        Hesap_Aktiflik_Durumu = item.IsActive ? "Aktif" : "Pasif",
                        Branşı = item.Expertise
                    }).ToList();
        }

        public static Dictionary<int, string> getTeacher()
        {
            return (from item in (new MainContext()).StudentManagementContext.Users
                    where item.Role != "Öğrenci"
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

        public static Dictionary<int, string> getStudent()
        {
            return (from item in (new MainContext()).StudentManagementContext.Users
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

        public static User GetFindByIdUser(int userId, StudentManagementContext studentManagementContext)
        {
            return studentManagementContext.Users.Find(userId);
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
    }
}
