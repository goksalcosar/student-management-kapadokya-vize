using Microsoft.EntityFrameworkCore;
using Öğrenci_İşleri_Otomasyonu.DataObjects;

namespace Öğrenci_İşleri_Otomasyonu.DataTransferObject.LessonDataModel
{
    internal class SelectLessonDataOperations
    {
        public static Dictionary<int, string> getKeyValueLessons()
        {
            return (from item in (new MainContext()).StudentManagementContext.Lessons
                    select new
                    {
                        item.Id,
                        item.Name
                    })
                     .AsEnumerable()
                    .ToDictionary(
                        x => x.Id,
                        x => x.Name
                    );
        }

        public static Lesson GetFindByNameLesson(string name, StudentManagementContext studentManagementContext)
        {
            return studentManagementContext.Lessons.FirstOrDefault(f => f.Name == name);
        }

        public static Lesson GetFindByIdLesson(int lessonId, StudentManagementContext studentManagementContext)
        {
            return studentManagementContext.LessonTeachers
                    .Include(lessonTeacher => lessonTeacher.Lesson)
                    .Include(teacher => teacher.Teacher)
                    .FirstOrDefault(lessonTeacher => lessonTeacher.Lesson.Id == lessonId)?.Lesson;
        }

        public static Lesson GetFindByIdNotLeftJoinLesson(int lessonId, StudentManagementContext studentManagementContext)
        {
            return studentManagementContext.Lessons.Find(lessonId);
        }

        public static LessonTeacher GetFindByIdLessonTeacher(int lessonId, StudentManagementContext studentManagementContext)
        {
            return studentManagementContext.LessonTeachers
                   .Include(lessonTeacher => lessonTeacher.Lesson)
                   .Include(lessonTeacher => lessonTeacher.Teacher)
                   .FirstOrDefault(lessonTeacher => lessonTeacher.Lesson.Id == lessonId);
        }

        public static List<object> getAllLessons()
        {
            var context = new MainContext().StudentManagementContext;

            return (from item in context.Lessons
                    join lessonTeacher in context.LessonTeachers
                    on item.Id equals lessonTeacher.LessonId into lessonTeachers
                    from lt in lessonTeachers.DefaultIfEmpty()
                    select new
                    {
                        Ders_Id = item.Id,
                        Ders_Adı = item.Name,
                        Ders_Tipi = item.Type,
                        İlgili_Öğretim_Görvlisi = lt.Teacher.Name + " " + lt.Teacher.Surname
                    }).ToList<object>();
        }
    }
}
