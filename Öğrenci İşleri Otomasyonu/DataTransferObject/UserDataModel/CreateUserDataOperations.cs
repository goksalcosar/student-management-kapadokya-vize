using Microsoft.EntityFrameworkCore;
using Öğrenci_İşleri_Otomasyonu.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Öğrenci_İşleri_Otomasyonu.DataTransferObject.UserDataModel
{
    public static class CreateUserDataOperations
    {
        public static string CreateUser(string name, string surName, string birthDate, string citionNumber, string gender, bool isActive, string password, string role)
        {
            User user = new User
            {
                Name = name,
                Surname = surName,
                BirthDate = DateTime.Parse(birthDate),
                TcNo = citionNumber,
                Gender = gender,
                IsActive = isActive,
                Password = password,
                Role = role
            };

            using (MainContext context = new())
            {
                context.StudentManagementContext.Add(user);
                context.StudentManagementContext.SaveChanges();
            }

            return "Kullanıcı Kaydı Başarılı Bir Şekilde Oluşturulmuştur.";
        }
    }
}
