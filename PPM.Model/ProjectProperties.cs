using System.Xml.Serialization;
namespace PPM.Model
{
    public class ProjectDetails
    {
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        [XmlIgnore]
        public DateOnly StartDate { get; set; }

        [XmlIgnore]
        public DateOnly EndDate { get; set; }

        [XmlElement("Startdate")]
        public string startDateString
        {
            get { return StartDate.ToString(); }
            set { StartDate = DateOnly.Parse(value); }
        }

        [XmlElement("Enddate")]
        public string endDateString
        {
            get { return EndDate.ToString(); }
            set { EndDate = DateOnly.Parse(value); }
        }

        public List<int>? list { get; set; }

       


    }
}