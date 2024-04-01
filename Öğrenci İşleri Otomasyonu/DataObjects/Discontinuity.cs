using System;
using System.Collections.Generic;

namespace Öğrenci_İşleri_Otomasyonu.DataObjects;

public partial class Discontinuity
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int DiasbledDiscontinuity { get; set; }

    public int UnexcusedDiacountinulatiy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
