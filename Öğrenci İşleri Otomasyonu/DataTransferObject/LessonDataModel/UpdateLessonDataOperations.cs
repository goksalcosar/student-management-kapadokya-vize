using Öğrenci_İşleri_Otomasyonu.DataObjects;
using Öğrenci_İşleri_Otomasyonu.DataTransferObject.UserDataModel;

namespace Öğrenci_İşleri_Otomasyonu.DataTransferObject.LessonDataModel
{
    public class UpdateLessonDataOperations
    {
        public static string UpdateLesson(string lessonName, string type)
        {
            var context = new MainContext().StudentManagementContext;

            Lesson lesson = SelectLessonDataOperations.GetFindByNameLesson(lessonName, context);

            lesson.Name = lessonName;
            lesson.Type = type;

            context.SaveChanges();

            return "Ders Kaydı Başarılı Bir Şekilde Güncellendi.";
        }

        public static string UpdateTeacherRelationLesson(string lessonName, string teacherName)
        {
            using (MainContext context = new())
            {
                // Dersin var olup olmadığını kontrol edin
                Lesson lesson = context.StudentManagementContext.Lessons.FirstOrDefault(l => l.Name == lessonName);

                // Eğer ders bulunamazsa hata mesajı döndürün
                if (lesson == null)
                {
                    return "Hata: Belirtilen ders bulunamadı.";
                }

                // Öğretmeni veritabanından alın
                User teacher = SelectUserDataOperations.GetFindByNameTeacher(teacherName, context.StudentManagementContext);

                // Eğer öğretmen bulunamazsa hata mesajı döndürün
                if (teacher == null)
                {
                    return "Hata: Belirtilen öğretmen bulunamadı.";
                }

                // Daha önce lesson_teacher tablosuna atanmış bir öğretmen var mı kontrol edin
                LessonTeacher existingRelation = context.StudentManagementContext.LessonTeachers.FirstOrDefault(lt => lt.LessonId == lesson.Id);

                // Eğer varsa, mevcut ilişkiyi güncelleyin
                if (existingRelation != null)
                {
                    existingRelation.Teacher = teacher;
                }
                // Yoksa, yeni bir ilişki oluşturun
                else
                {
                    LessonTeacher newRelation = new LessonTeacher()
                    {
                        Lesson = lesson,
                        Teacher = teacher
                    };
                    context.StudentManagementContext.LessonTeachers.Add(newRelation);
                }

                // Değişiklikleri kaydedin
                context.StudentManagementContext.SaveChanges();
            }

            return "Ders kaydı başarılı bir şekilde güncellendi.";
        }
    }
}
