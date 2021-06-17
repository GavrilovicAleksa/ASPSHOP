using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer.PhotoDataTransfer
{
    public class GetPhotoDto
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public Domain.User User { get; set; }

        public Domain.Product Product { get; set; }
    }
}
