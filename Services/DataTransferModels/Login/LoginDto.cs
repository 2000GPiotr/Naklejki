using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataTransferModels.Login
{
    public class LoginDto
    {
        public string Login { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }
}
