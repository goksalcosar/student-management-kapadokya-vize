﻿using System;
using System.Collections.Generic;

namespace Öğrenci_İşleri_Otomasyonu.DataObjects;

public partial class ExamResult
{
    public int Id { get; set; }

    public int LessonId { get; set; }

    public int UserId { get; set; }

    public int AuthorId { get; set; }

    public float Score { get; set; }

    public string? Type { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
