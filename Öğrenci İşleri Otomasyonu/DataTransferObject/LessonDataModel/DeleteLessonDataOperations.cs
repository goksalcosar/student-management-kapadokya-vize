using Öğrenci_İşleri_Otomasyonu.DataObjects;

namespace Öğrenci_İşleri_Otomasyonu.DataTransferObject.LessonDataModel
{
    public class DeleteLessonDataOperations
    {
        public static string DeleteLesson(int lessonId)
        {
            var context = new MainContext().StudentManagementContext;

            LessonTeacher lessonTeacher = SelectLessonDataOperations.GetFindByIdLessonTeacher(lessonId, context);
            Lesson lesson = SelectLessonDataOperations.GetFindByIdNotLeftJoinLesson(lessonId, context);

            if (lessonTeacher != null)
            {
                context.Remove(lessonTeacher);
            }

            context.Remove(lesson);
            context.SaveChanges();

            return "Ders Başarılı Bir Şekilde Silindi.";
        }
    }
}
