using System.Numerics;
using System.Xml.Serialization;

namespace PPM.Model
{



    public class EmployeeDetails
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        [XmlIgnore]
        public BigInteger? PhoneNumber { get; set; }

        [XmlElement("phoneNumber")]
        public string phoneNumberString
        {
            get { return PhoneNumber.ToString()!; }
            set { PhoneNumber = BigInteger.Parse(value); }
        }
        public string? Address { get; set; }
        public int RoleId { get; set; }
        



    }
}