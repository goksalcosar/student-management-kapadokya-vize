using System;
using System.Collections.Generic;

namespace Öğrenci_İşleri_Otomasyonu.DataObjects;

public partial class ClubsStudent
{
    public int ClubId { get; set; }

    public int StudentId { get; set; }

    public virtual Club Club { get; set; } = null!;

    public virtual User Student { get; set; } = null!;
}
