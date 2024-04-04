using Öğrenci_İşleri_Otomasyonu.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static List<object> getAllLessons()
        {
            var context = new MainContext().StudentManagementContext;

            return (from item in context.Lessons
                    join lessonTeacher in context.LessonTeachers
                    on item.Id equals lessonTeacher.LessonId into lessonTeachers
                    from lt in lessonTeachers.DefaultIfEmpty()
                    select new
                    {
                        Ders_Adı = item.Name,
                        Ders_Tipi = item.Type,
                        İlgili_Öğretim_Görvlisi = lt.Teacher.Name + " " + lt.Teacher.Surname
                    }).ToList<object>();
        }
    }
}
