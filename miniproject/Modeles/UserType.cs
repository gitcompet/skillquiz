using System;
using System.Collections.Generic;

namespace WebApiMiniPj.Modeles;

public partial class UserType
{
    public int UserTypeid { get; set; }

    public string Descriptiontst { get; set; } = null!;

    public byte IsActive { get; set; }

    public byte IsDeleted { get; set; }
}
