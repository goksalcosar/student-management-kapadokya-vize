using Öğrenci_İşleri_Otomasyonu.DataObjects;

namespace Öğrenci_İşleri_Otomasyonu.DataTransferObject.ExamResultDataModel
{
    public class DeleteExamResultDataOperations
    {
        public static string DeleteExamResult(int examResultId)
        {
            var context = new MainContext().StudentManagementContext;

            ExamResult examResult = SelectExamResultDataOpertions.GetFindByIdExamResult(examResultId, context);

            if (examResult == null)
            {
                return "Hata! İlgili Not Değeri Bulunamadı";
            }

            context.Remove(examResult);
            context.SaveChanges();

            return "Not Kaydı Başarılı Bir Şekilde Silindi.";
        }
    }
}
