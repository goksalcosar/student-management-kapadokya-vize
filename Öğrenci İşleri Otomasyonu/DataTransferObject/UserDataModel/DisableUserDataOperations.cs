using Öğrenci_İşleri_Otomasyonu.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Öğrenci_İşleri_Otomasyonu.DataTransferObject.UserDataModel
{
    public class DisableUserDataOperations
    {
        public static string disableUserData(string lastName, string citionNumber)
        {
            var context = new MainContext().StudentManagementContext;

            User user = SelectUserDataOperations.GetFindByLastNameCitionNumber(lastName, citionNumber, context);

            user.IsActive = false;

            context.SaveChanges();

            return "Kullanıcı Hesabı Başarılı Bir Şekilde Kapatıldı.";
        }
    }
}
