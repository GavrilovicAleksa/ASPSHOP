using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer
{
    public class RemoveEntityDto
    {
        public int Id { get; set; }

        public bool Hard { get; set; }
    }
}
