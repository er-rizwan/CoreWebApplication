﻿using System;
using System.Collections.Generic;

namespace CoreWebApi.Models;

public partial class Student
{
    public int Id { get; set; }

    public string StudentName { get; set; } = null!;

    public string StudentGender { get; set; } = null!;

    public int StudentAge { get; set; }

    public int Standard { get; set; }

    public string? FatherName { get; set; }
}
