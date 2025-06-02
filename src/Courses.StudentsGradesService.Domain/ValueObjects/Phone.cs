using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.StudentsGradesService.Domain.ValueObjects
{
    public class Phone
    {
        public string Number { get; set; }
        public string Area { get; set; }
        public string CountryCode { get; set; }
        public override string ToString()
        {
            return $"{CountryCode} {Area} {Number}";
        }
    }

}