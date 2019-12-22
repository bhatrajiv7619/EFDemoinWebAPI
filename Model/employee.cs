using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFDemoinWebAPI.Model
{
    public class employee
    {

        [Key]

        public int EmpId { get; set; }

        public string Name { get; set; }
        public decimal Salary { get; set; }

    }
}
