using System;
using System.Collections.Generic;

namespace Öğrenci_İşleri_Otomasyonu.DataObjects;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Gender { get; set; }

    public string TcNo { get; set; } = null!;

    public string? Role { get; set; }

    public DateTime BirthDate { get; set; }

    public string? Expertise { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Absence> Absences { get; set; } = new List<Absence>();

    public virtual ICollection<ExamResult> ExamResultAuthors { get; set; } = new List<ExamResult>();

    public virtual ICollection<ExamResult> ExamResultUsers { get; set; } = new List<ExamResult>();

    public virtual ICollection<LessonTeacher> LessonTeachers { get; set; } = new List<LessonTeacher>();
}
