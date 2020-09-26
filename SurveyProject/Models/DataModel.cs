using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyProject.Models
{
    public class DataModel
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "nvarchar(12)")]
        public string AccountNumber { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string BenificiaryName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string BankName { get; set; }
        [Column(TypeName = "nvarchar(11)")]
        public string SWIFTCode { get; set; }
        public int Amount { get; set; }
    }
}
