using Öğrenci_İşleri_Otomasyonu.DataObjects;
using Öğrenci_İşleri_Otomasyonu.DataTransferObject.UserDataModel;

namespace Öğrenci_İşleri_Otomasyonu.DataTransferObject.DiscontinuityDataModel
{
    public class CreateAbsenceDataOperations
    {
        public static string CreateStudentAbsence(string studentFullName, bool discontinuityType)
        {
            using (MainContext context = new())
            {
                var student = SelectUserDataOperations.GetFindByFullNameStudent(studentFullName, context.StudentManagementContext);

                Absence absence = new Absence();

                absence.User = student;
                absence.ExcusedAbsence = discontinuityType ? "1" : "-";
                absence.UnexcusedAbsence = discontinuityType ? "-" : "1";
                absence.CreatedAt = DateTime.Now;

                context.StudentManagementContext.Add(absence);
                context.StudentManagementContext.SaveChanges();
            }

            return "İlgili Öğrencinin Devamsızlık Kaydı Kayıt Edilmiştir.";
        }
    }
}