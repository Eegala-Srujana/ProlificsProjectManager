using System.Xml.Serialization;
using PPM.Model;

namespace PPM.Domain
{
    public class SaveStateRepo
    {
        public  void SaveState()
        {
            XmlSerializer projectSerializer = new XmlSerializer(typeof(List<ProjectDetails>));
            using (FileStream stream = new FileStream(@"C:\Users\SEegala\Documents\ProlificsProjectManagement\XmlOutput\projectXmlOutput.xml", FileMode.Create, FileAccess.Write))
            {
                projectSerializer.Serialize(stream, Project.projectList);
            }
            XmlSerializer employeeSerializer = new XmlSerializer(typeof(List<EmployeeDetails>));
            using (FileStream stream = new FileStream(@"C:\Users\SEegala\Documents\ProlificsProjectManagement\XmlOutput\employeeXmlOutput.xml", FileMode.Create, FileAccess.Write))
            {
                employeeSerializer.Serialize(stream, Employee.employeeList);
            }
            XmlSerializer roleSerializer = new XmlSerializer(typeof(List<RoleDetails>));
            using (FileStream stream = new FileStream(@"C:\Users\SEegala\Documents\ProlificsProjectManagement\XmlOutput\roleXmlOutput.xml", FileMode.Create, FileAccess.Write))
            {
                roleSerializer.Serialize(stream, Role.roleList);
            }
            XmlSerializer employeeProjectSerializer = new XmlSerializer(typeof(List<EmployeeProjectProperties>));
            using (FileStream stream = new FileStream(@"C:\Users\SEegala\Documents\ProlificsProjectManagement\XmlOutput\employeeProjectXmlOutput.xml", FileMode.Create, FileAccess.Write))
            {
                employeeProjectSerializer.Serialize(stream, EmployeeProject.employeeProjectList);
            }





        }
    }
}