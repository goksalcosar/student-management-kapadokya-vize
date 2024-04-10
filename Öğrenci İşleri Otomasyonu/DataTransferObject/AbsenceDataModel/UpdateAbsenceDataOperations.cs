using Öğrenci_İşleri_Otomasyonu.DataObjects;
using Öğrenci_İşleri_Otomasyonu.DataTransferObject.UserDataModel;

namespace Öğrenci_İşleri_Otomasyonu.DataTransferObject.AbsenceDataModel
{
    public class UpdateAbsenceDataOperations
    {
        public static string UpdateAbsence(int absenceId, string studentFullName, bool discontinuityType)
        {
            var context = new MainContext().StudentManagementContext;

            Absence absence = SelectAbsenceDataOperations.GetFindByIdAbsence(absenceId, context);
            User student = SelectUserDataOperations.GetFindByFullNameStudent(studentFullName, context);

            if (absence == null)
            {
                return "Hata! İlgili Devamsızlık Verisi Bulunamadı";
            }

            absence.User = student;
            absence.ExcusedAbsence = discontinuityType ? "1" : "-";
            absence.UnexcusedAbsence = discontinuityType ? "-" : "1";

            context.SaveChanges();

            return "Devamsızlık Kaydı Başarılı Bir Şekilde Güncellendi.";
        }
    }
}
