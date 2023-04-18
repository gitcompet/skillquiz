using System;
using System.Collections.Generic;

namespace WebApiMiniPj.Modeles;

public partial class Answer
{
    public int AnswerId { get; set; }

    public string? Answer1 { get; set; }

    public string? Comment { get; set; }

    public byte IsActive { get; set; }

    public byte IsDeleted { get; set; }
}
