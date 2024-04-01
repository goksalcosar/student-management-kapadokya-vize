using Microsoft.EntityFrameworkCore;
using Öğrenci_İşleri_Otomasyonu.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Öğrenci_İşleri_Otomasyonu.DataTransferObject.UserDataModel
{
    public static class UpdateUserDataOperations
    {
        public static string UpdateUser(string name, string surName, string birthDate, string citionNumber, string gender, bool isActive, string password, string role, int userId)
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

            context.SaveChanges();

            return "Kullanıcı Kaydı Başarılı Bir Şekilde Güncellendi.";
        }
    }
}
