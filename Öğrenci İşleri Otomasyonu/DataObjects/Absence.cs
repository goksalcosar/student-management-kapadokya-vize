using System;
using System.Collections.Generic;

namespace Öğrenci_İşleri_Otomasyonu.DataObjects;

public partial class Absence
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string ExcusedAbsence { get; set; } = null!;

    public string UnexcusedAbsence { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
