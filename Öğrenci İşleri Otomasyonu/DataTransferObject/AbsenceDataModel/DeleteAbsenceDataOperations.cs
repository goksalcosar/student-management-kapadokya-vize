using Öğrenci_İşleri_Otomasyonu.DataObjects;

namespace Öğrenci_İşleri_Otomasyonu.DataTransferObject.AbsenceDataModel
{
    public class DeleteAbsenceDataOperations
    {
        public static string DeleteAbsence(int absenceId)
        {
            var context = new MainContext().StudentManagementContext;

            Absence absence = SelectAbsenceDataOperations.GetFindByIdAbsence(absenceId, context);

            if (absence == null)
            {
                return "Hata! İlgili Devamsızlık Verisi Bulunamadı";
            }

            context.Remove(absence);
            context.SaveChanges();

            return "Devamsızlık Kaydı Başarılı Bir Şekilde Silindi.";
        }
    }
}
