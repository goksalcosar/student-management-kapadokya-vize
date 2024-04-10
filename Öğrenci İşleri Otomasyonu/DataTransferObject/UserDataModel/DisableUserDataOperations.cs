using Öğrenci_İşleri_Otomasyonu.DataObjects;

namespace Öğrenci_İşleri_Otomasyonu.DataTransferObject.UserDataModel
{
    public class DisableUserDataOperations
    {
        public static string UserStatusUpdate(string lastName, string citionNumber, bool status)
        {
            var context = new MainContext().StudentManagementContext;

            User user = SelectUserDataOperations.GetFindByLastNameCitionNumber(lastName, citionNumber, context);

            user.IsActive = status;

            context.SaveChanges();

            return "Kullanıcı Hesabının Aktiflik Durumu Başarılı Bir Şekilde Değiştirildi.";
        }
    }
}
