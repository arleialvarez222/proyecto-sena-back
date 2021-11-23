﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sena.core.DTO
{
    public class RegistrationResponseDto
    {
        public bool IsSuccessfulRegistration { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
