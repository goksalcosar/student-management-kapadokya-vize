using Microsoft.EntityFrameworkCore;
using Öğrenci_İşleri_Otomasyonu.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace Öğrenci_İşleri_Otomasyonu.DataTransferObject.UserDataModel
{
    public static class UpdateUserDataOperations
    {
        public static string UpdateStudent(string name, string surName, string birthDate, string citionNumber, string gender, bool isActive, string password, string role, string phoneNumber, string email, string address, int userId)
        {
            var context = new MainContext().StudentManagementContext;

            User user = SelectUserDataOperations.GetFindByIdUser(userId, context);

            user.Name = name;
            user.Surname = surName;
            user.BirthDate = DateTime.Parse(birthDate);
            user.TcNo = citionNumber;
            user.Gender = gender;
            user.IsActive = isActive;
            user.Password = password;
            user.Role = role;
            user.PhoneNumber = phoneNumber;
            user.Email = email;
            user.Address = address;
            user.Password = password;

            context.SaveChanges();

            return "Öğrenci Kaydı Başarılı Bir Şekilde Güncellendi.";
        }

        public static string UpdateTeacher(string name, string surName, string birthDate, string citionNumber, string gender, bool isActive, string password, string role, string phoneNumber, string email, string address, int userId, string expertise)
        {
            var context = new MainContext().StudentManagementContext;

            User user = SelectUserDataOperations.GetFindByIdUser(userId, context);

            user.Name = name;
            user.Surname = surName;
            user.BirthDate = DateTime.Parse(birthDate);
            user.TcNo = citionNumber;
            user.Gender = gender;
            user.IsActive = isActive;
            user.Password = password;
            user.Role = role;
            user.PhoneNumber = phoneNumber;
            user.Email = email;
            user.Address = address;
            user.Password = password;
            user.Expertise = expertise;

            context.SaveChanges();

            return "Öğretmen Kaydı Başarılı Bir Şekilde Güncellendi.";
        }
    }
}
