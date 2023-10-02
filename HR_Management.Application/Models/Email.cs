using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace HR_Management.Application.Models
{
    public class Email
    {
        public string To { get; set; }
        public string subject { get; set; }


        public string body { get; set; }


    }
}
