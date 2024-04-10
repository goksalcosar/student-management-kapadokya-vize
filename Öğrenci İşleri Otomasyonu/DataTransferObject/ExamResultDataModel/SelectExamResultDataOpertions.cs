using Microsoft.EntityFrameworkCore;
using Öğrenci_İşleri_Otomasyonu.DataObjects;

namespace Öğrenci_İşleri_Otomasyonu.DataTransferObject.ExamResultDataModel
{
    public class SelectExamResultDataOpertions
    {
        public static List<object> getAllExamResult()
        {
            var context = new MainContext().StudentManagementContext;

            return (from item in context.ExamResults
                    select new
                    {
                        Not_Id = item.Id,
                        Ders_Adı = item.Lesson.Name,
                        Sınav_Türü = item.Type,
                        Not_Bilgisi = item.Score,
                        Öğrenci_Adı = item.User.Name + " " + item.User.Surname,
                        Oluşturan_Eğitim_Görevlisi = item.Author.Name + " " + item.Author.Surname
                    }).ToList<object>();
        }

        public static ExamResult GetFindByIdExamResult(int examResultId, StudentManagementContext studentManagementContext)
        {
            return studentManagementContext.ExamResults
                                         .Include(er => er.User)
                                         .Include(er => er.Author)
                                         .Include(er => er.Lesson)
                                         .FirstOrDefault(er => er.Id == examResultId);
        }
        public static List<object> getAllFilteringExamResult(string citionNumber)
        {
            var context = new MainContext().StudentManagementContext;

            return (from item in context.ExamResults
                    where item.User.TcNo == citionNumber
                    select new
                    {
                        Not_Id = item.Id,
                        Ders_Adı = item.Lesson.Name,
                        Sınav_Türü = item.Type,
                        Not_Bilgisi = item.Score
                    }).ToList<object>();
        }
    }
}
