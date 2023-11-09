
using NUnit.Framework;
using PPM.Model;
using PPM.Domain;
using PPM.Ui.Consoles;
using NUnit.Framework.Internal;
using System.Threading.Tasks.Dataflow;

namespace TestProject2;
[TestFixture]
public class Tests
{

    [Test]
    public void AddProjectTest()
    {
        ProjectDetails projectDetails = new ProjectDetails()
        {
            ProjectId = 3,
            ProjectName = "onlinebookstore",
            StartDate = new DateOnly(2020, 02, 02),

            EndDate = new DateOnly(2021, 02, 02),

        };
        Project project = new Project();
        project.AddEntity(projectDetails);


        CollectionAssert.Contains(Project.projectList, projectDetails);

      //  Assert.That(Project.projectList[0].ProjectName, Is.EqualTo("onlinebookstore"));
        // Assert.That(Project.projectList[0].ProjectId, Is.EqualTo(1));
    }

    [Test]
    public void DeleteProjectTest()
    {

        Project project = new Project();
        ProjectDetails projectDetails = new ProjectDetails
        {
            ProjectId = 2,
            ProjectName = "abc",
            StartDate = new DateOnly(2020, 02, 02),
            EndDate = new DateOnly(2021, 02, 02),
        };

        project.AddEntity(projectDetails);


        project.DeleteById(2);


        Assert.That(Project.projectList, Has.None.EqualTo(projectDetails));
    }


    [Test]

    public void AddEmployeeValidUser()

    {



        EmployeeDetails employeeProperties = new EmployeeDetails()



        {

            EmployeeId = 1,

            FirstName = "srujana",

            LastName = "eegala",

            Email = "srujana@gmail.com",

            PhoneNumber = 9303586432,

            Address = "hyd",

            RoleId = 2,

        };
        Employee employee = new Employee();
        employee.AddEntity(employeeProperties);
        CollectionAssert.Contains(Employee.employeeList, employeeProperties);

        System.Console.WriteLine("Test passed");



    }
    [Test]
    public void DeleteEmployeeTest()
    {

        EmployeeDetails employeeProperties = new EmployeeDetails()



        {

            EmployeeId = 5,

            FirstName = "srujana",

            LastName = "eegala",

            Email = "srujana@gmail.com",

            PhoneNumber = 9303586432,

            Address = "hyd",

            RoleId = 2,

        };
        Employee employee = new Employee();
        employee.AddEntity(employeeProperties);
        employee.DeleteById(11);


        Assert.That(Project.projectList, Has.None.EqualTo(employeeProperties));
    }

    [Test]
    public void AdddRoleTest()
    {
        RoleDetails roleDetails = new RoleDetails()
        {
            RoleId = 3,
            RoleName = "developer"

        };
        Role role = new Role();
        role.AddEntity(roleDetails);

        CollectionAssert.Contains(Role.roleList, roleDetails);
        //Assert.That(Role.roleList[0].RoleId, Is.EqualTo(3));
        // Assert.That(Role.roleList[0].RoleName, Is.EqualTo("developer"));
    }
    [Test]
    public void DeleteRoleTest()
    {
         RoleDetails roleDetails = new RoleDetails()
        {
            RoleId = 2,
            RoleName = "developer"

        };
        Role role = new Role();
        role.AddEntity(roleDetails);
         role.DeleteById(2);


        Assert.That(Role.roleList, Has.None.EqualTo(roleDetails));
    }

[Test]
     public void ListAllTestCase()
    {
        // Arrange
       
      RoleDetails roleDetails = new RoleDetails()
        {
            RoleId = 4,
            RoleName = "Testing",

        };
        Role role = new Role();
        role.AddEntity(roleDetails);      

        List<RoleDetails> details = role.ListAll();

        Assert.IsTrue(details.Contains(roleDetails));


    }






    [Test]
    public void AddEmployeeToPrjectTest()
    {
        EmployeeProjectProperties employeeProjectProperties = new EmployeeProjectProperties()

        {
            ProjectId = 1,
            ProjectName = "abc",
            EmployeeId = 1,
            FirstName = "srujana",
            LastName = "Eegala",
            RoleId = 1

        };
        EmployeeProject employeeProject = new EmployeeProject();
        employeeProject.AddEmployeeToProject(employeeProjectProperties.ProjectId, employeeProjectProperties.ProjectName, employeeProjectProperties.EmployeeId, employeeProjectProperties.FirstName, employeeProjectProperties.LastName, employeeProjectProperties.RoleId);


        bool containsItem = EmployeeProject.employeeProjectList.Any(item =>
               item.ProjectId == employeeProjectProperties.ProjectId &&
               item.EmployeeId == employeeProjectProperties.EmployeeId &&
               item.FirstName == employeeProjectProperties.FirstName &&
               item.LastName == employeeProjectProperties.LastName &&
               item.RoleId == employeeProjectProperties.RoleId);

        Assert.IsTrue(containsItem);



    }
    [Test]
    public void RemoveEmployeeFromPrjectTest()
    {
        EmployeeProjectProperties employeeProjectProperties = new EmployeeProjectProperties()

        {
            ProjectId = 2,
            EmployeeId = 2,

        };
        EmployeeProject employeeProject = new EmployeeProject();
        employeeProject.DeleteEmployeeFromProject(employeeProjectProperties.ProjectId, employeeProjectProperties.EmployeeId);

        bool containsItem = EmployeeProject.employeeProjectList.Any(item =>
               item.ProjectId == employeeProjectProperties.ProjectId &&
               item.EmployeeId == employeeProjectProperties.EmployeeId);


        Assert.IsFalse(containsItem);

    }


}














