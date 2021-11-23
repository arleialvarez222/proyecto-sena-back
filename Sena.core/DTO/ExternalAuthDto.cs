using System;
using System.Collections.Generic;
using System.Text;

namespace Sena.core.DTO
{
	public class ExternalAuthDto
	{
		public string Provider { get; set; }
		public string IdToken { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string Email { get; set; }
    }
}
