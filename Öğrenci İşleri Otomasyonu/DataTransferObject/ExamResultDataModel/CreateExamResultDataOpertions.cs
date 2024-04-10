using Öğrenci_İşleri_Otomasyonu.DataObjects;
using Öğrenci_İşleri_Otomasyonu.DataTransferObject.LessonDataModel;
using Öğrenci_İşleri_Otomasyonu.DataTransferObject.UserDataModel;

namespace Öğrenci_İşleri_Otomasyonu.DataTransferObject.ExamResultDataModel
{
    public class CreateExamResultDataOpertions
    {
        public static string CreateLessonNote(string authorName, string lessonName, string studenFullName, float score, string type)
        {
            using (MainContext context = new())
            {
                var author = SelectUserDataOperations.GetFindByNameUser(authorName, context.StudentManagementContext);
                var student = SelectUserDataOperations.GetFindByFullNameStudent(studenFullName, context.StudentManagementContext);
                var lesson = SelectLessonDataOperations.GetFindByNameLesson(lessonName, context.StudentManagementContext);

                ExamResult examResult = new ExamResult()
                {
                    Lesson = lesson,
                    Author = author,
                    User = student,
                    Score = score,
                    Type = type
                };

                context.StudentManagementContext.Add(examResult);
                context.StudentManagementContext.SaveChanges();
            }

            return "Öğrenci Notu Başarılı Bir Şekilde Oluşturulmuştur.";
        }
    }
}
