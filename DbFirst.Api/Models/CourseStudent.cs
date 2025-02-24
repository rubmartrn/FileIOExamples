﻿using System;
using System.Collections.Generic;

namespace DbFirst.Api.Models;

public partial class CourseStudent
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int StudentId { get; set; }

    public bool Paid { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
