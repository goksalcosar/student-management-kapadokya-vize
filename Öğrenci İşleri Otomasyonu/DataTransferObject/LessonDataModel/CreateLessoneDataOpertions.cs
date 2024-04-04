using Öğrenci_İşleri_Otomasyonu.DataObjects;
using Öğrenci_İşleri_Otomasyonu.DataTransferObject.UserDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Öğrenci_İşleri_Otomasyonu.DataTransferObject.LessonDataModel
{
    public class CreateLessoneDataOpertions
    {
        public static string CreateLesson(string name, string type)
        {
            using (MainContext context = new())
            {
                Lesson lesson = new Lesson()
                {
                    Name = name,
                    Type = type
                };

                context.StudentManagementContext.Add(lesson);
                context.StudentManagementContext.SaveChanges();
            }

            return "Ders Başarılı Bir Şekilde Oluşturulmuştur.";
        }

        public static string SetLessonTeacher(string teacherName, string lessonName)
        {
            using (MainContext context = new())
            {
                var teacher = SelectUserDataOperations.GetFindByNameTeacher(teacherName, context.StudentManagementContext);
                var lesson = SelectLessonDataOperations.GetFindByNameLesson(lessonName, context.StudentManagementContext);

                LessonTeacher lessonTeacher = new LessonTeacher()
                {
                    Lesson = lesson,
                    Teacher = teacher
                };

                context.StudentManagementContext.Add(lessonTeacher);
                context.StudentManagementContext.SaveChanges();
            }

            return "Öğretmen Kaydı Başarılı Bir Şekilde Oluşturulmuştur.";
        }
    }
}
