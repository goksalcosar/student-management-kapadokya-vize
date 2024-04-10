using System;
using System.Collections.Generic;

namespace Öğrenci_İşleri_Otomasyonu.DataObjects;

public partial class Lesson
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Type { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();

    public virtual ICollection<LessonTeacher> LessonTeachers { get; set; } = new List<LessonTeacher>();
}
