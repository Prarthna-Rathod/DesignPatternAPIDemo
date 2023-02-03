using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.Core.Domain.ResponseModel
{
    public record ResultResponseModel
    {
        public int Id { get; set; }
        public int m1 { get; set; }
        public int m2 { get; set; }
        public int m3 { get; set; }
        public string StudentName { get; set; }
    }
}
