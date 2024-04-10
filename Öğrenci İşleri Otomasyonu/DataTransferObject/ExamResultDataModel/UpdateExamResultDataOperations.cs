using Öğrenci_İşleri_Otomasyonu.DataObjects;
using Öğrenci_İşleri_Otomasyonu.DataTransferObject.UserDataModel;

namespace Öğrenci_İşleri_Otomasyonu.DataTransferObject.ExamResultDataModel
{
    public class UpdateExamResultDataOperations
    {
        public static string UpdateExamResult(int examResultId, string lessonName, string type, string studentFullName, string score)
        {
            var context = new MainContext().StudentManagementContext;

            ExamResult examResult = SelectExamResultDataOpertions.GetFindByIdExamResult(examResultId, context);
            var student = SelectUserDataOperations.GetFindByFullNameStudent(studentFullName, context);


            if (examResult == null)
            {
                return "Hata! İlgili Not Değeri Bulunamadı";
            }

            examResult.Type = type;
            examResult.User = student;
            examResult.Score = float.Parse(score);

            context.SaveChanges();

            return "Not Kaydı Başarılı Bir Şekilde Güncellendi.";
        }
    }
}
