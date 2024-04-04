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
        public static string CreateStudent(string name, string surName, string birthDate, string citionNumber, string gender, bool isActive, string password, string role, string phoneNumber, string email, string address)
        {
            User user = new User
            {
                Name = name,
                Surname = surName,
                TcNo = citionNumber,
                Gender = gender,
                IsActive = isActive,
                Role = role,
                BirthDate = DateTime.Parse(birthDate),
                PhoneNumber = phoneNumber,
                Email = email,
                Address = address,
                Password = password
            };

            using (MainContext context = new())
            {
                context.StudentManagementContext.Add(user);
                context.StudentManagementContext.SaveChanges();
            }

            return "Öğrenci Kaydı Başarılı Bir Şekilde Oluşturulmuştur.";
        }

        public static string CreateTeacher(string name, string surName, string birthDate, string citionNumber, string gender, bool isActive, string password, string role, string phoneNumber, string email, string address, string expertise)
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
                Role = role,
                Expertise = role == "Öğrenci" ? null : expertise
            };

            using (MainContext context = new())
            {
                context.StudentManagementContext.Add(user);
                context.StudentManagementContext.SaveChanges();
            }

            return "Öğretmen Kaydı Başarılı Bir Şekilde Oluşturulmuştur.";
        }
    }
}
