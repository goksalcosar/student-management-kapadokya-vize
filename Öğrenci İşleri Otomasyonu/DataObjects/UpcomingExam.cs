using System;
using System.Collections.Generic;

namespace Öğrenci_İşleri_Otomasyonu.DataObjects;

public partial class UpcomingExam
{
    public int Id { get; set; }

    public int LessonId { get; set; }

    public DateTime ExamDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
