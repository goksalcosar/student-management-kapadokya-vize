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
                        Kullanıcı_Yetki = item.Role
                    }).ToList();
        }

        public static User GetFindByIdUser(int userId, StudentManagementContext studentManagementContext)
        {
            return studentManagementContext.Users.Find(userId);
        }

        public static User GetFindByLastNameCitionNumber(string lastName, string citionNumber , StudentManagementContext studentManagementContext)
        {
            return studentManagementContext.Users.FirstOrDefault(f => f.Surname == lastName && f.TcNo == citionNumber);
        }
    }
}
