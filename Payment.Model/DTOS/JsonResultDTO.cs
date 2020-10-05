using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Model.DTOS
{
    public class JsonResultDTO
    {
        public bool IsSuccess { get; set; }
        public Guid TransactionId { get; set; }
        public IList<string> Errors { get; set; }

        public JsonResultDTO()
        {
            IsSuccess = true;
            Errors = new List<string>();
        }
    }
}
