using System;
using System.Collections.Generic;

namespace Öğrenci_İşleri_Otomasyonu.DataObjects;

public partial class LessonTeacher
{
    public int Id { get; set; }

    public int LessonId { get; set; }

    public int TeacherId { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual User Teacher { get; set; } = null!;
}
