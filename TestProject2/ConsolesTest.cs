using NUnit;
using PPM.Model;
using PPM.Domain;
using PPM.Ui.Consoles;
using NUnit.Framework;

using System.Threading.Tasks.Dataflow;

namespace PPM.TestProject2
{
[TestFixture]
public class TestConsoles
{

    [Test]
    public void ViewProjectsTest()
    {

        ProjectDetails projectDetails = new ProjectDetails()
        {
            ProjectId = 1,

            ProjectName = "abc",

            StartDate = new DateOnly(2020, 02, 02),

            EndDate = new DateOnly(2021, 02, 02)


        };
        Project project = new Project();
        project.AddEntity(projectDetails);
        Consoles.ViewProjects();

        List<ProjectDetails> details = Consoles.ViewProjects();

        Assert.IsTrue(details.Contains(projectDetails));

    }

    [Test]
    public void ViewEmployeeTest()
    {

        EmployeeDetails employeeDetails = new EmployeeDetails()
        {
            EmployeeId = 1,

            FirstName = "srujana",

            LastName = "Eegala",

            Email = "srujana@gmail.com",
            PhoneNumber = 9999999999,
            Address = "Hyderabad",
            RoleId = 1



        };
        Employee employee = new Employee();
        employee.AddEntity(employeeDetails);
        Consoles.ViewEmployees();

        List<EmployeeDetails> details = Consoles.ViewEmployees();

        Assert.IsTrue(details.Contains(employeeDetails));

    }


    [Test]
    public void ViewRolesTest()
    {

        RoleDetails roleDetails = new RoleDetails()
        {
            RoleId = 3,
            RoleName = "Developer",

        };
        Role role = new Role();
        role.AddEntity(roleDetails);
        Consoles.ViewRoles();

        List<RoleDetails> details = Consoles.ViewRoles();

        Assert.IsTrue(details.Contains(roleDetails));

    }
    [Test]
    public void ViewEmployeeProjectTest()
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

        EmployeeProject.employeeProjectList.Add(employeeProjectProperties);
        Consoles.ViewEmployeeProject();
        //List<EmployeeProjectProperties>details=Consoles.ViewEmployeeProject();
        Assert.IsTrue(EmployeeProject.employeeProjectList.Contains(employeeProjectProperties));

    }

    [Test]

    public void AddEmployeeValidInput()
    {

        var data = "1\n20\nsrujana\neegala\nsrujana@gmail.com\n3456543234\ninugurthy\n1\n";

        StringReader input = new StringReader(data);

        Console.SetIn(input);

        EmployeeRepo repo = new();

        repo.AddEmployeeMethod();
    }

    [Test]

    public void AddEmployeeNegativeIdValidInput()
    {
        var data = "1\n-1\n1\nsrujana\neegala\nsrujana@gmail.com\n3456543234\ninugurthy\n1\n";

        StringReader input = new StringReader(data);

        Console.SetIn(input);

        EmployeeRepo repo = new();

        repo.AddEmployeeMethod();

    }

    [Test]

    public void AddEmployeeDuplicateIdValidInput()
    {
        var data = "2\n14\nsrujana\neegala\nsrujana@gmail.com\n3456543234\ninugurthy\n1\n18\nsunny\neegala\nsunny@gmail.com\n3456543234\ninuhurthy\n1\n";

        StringReader input = new StringReader(data);

        Console.SetIn(input);

        EmployeeRepo consoles = new();

        consoles.AddEmployeeMethod();


    }

    [Test]

    public void AddEmployeeEmailIdValidInput()
    {
        var data = "1\n15\nsrujana\neegala\nsrujana.com\nsrujana@gmail.com\n3456543234\ninugurthy\n1\n";

        StringReader input = new StringReader(data);

        Console.SetIn(input);

        EmployeeRepo consoles = new();

        consoles.AddEmployeeMethod();


    }

    [Test]

    public void AddEmployeePhoneNumberValidInput()
    {
        var data = "1\n28\nsrujana\neegala\nsrujana.com\nsrujana@gmail.com\n345654\n5456456545\nfdshg\n1\n";

        StringReader input = new StringReader(data);

        Console.SetIn(input);

        EmployeeRepo consoles = new();

        consoles.AddEmployeeMethod();


    }


    [Test]
    public void AddProjectValidInput()
    {
        var data = "1\n12\nppm\n2023-7-9\n2024-4-6\n";
        StringReader input = new StringReader(data);
        Console.SetIn(input);
        ProjectRepo consoles = new();
        consoles.AddProjectMethod();
    }

    [Test]
    public void AddProjectNegativeValidInput()
    {
        var data = "1\n-1\n1\nppm\n2021-7-9\n2025-4-6\n";
        StringReader input = new StringReader(data);
        Console.SetIn(input);
        ProjectRepo consoles = new();
        consoles.AddProjectMethod();
    }

    [Test]
    public void AddProjectDuplicateValidInput()
    {
        var data = "2\n10\nonlinebookstore\n2021-7-9\n2025-4-6\n11\nfdr\n2021-7-9\n2025-4-6\n";
        StringReader input = new StringReader(data);
        Console.SetIn(input);
        ProjectRepo consoles = new();
        consoles.AddProjectMethod();
    }

    [Test]
    public void AddProjectValidEndDateInput()
    {
        var data = "1\n13\nfdr\n2021-7-9\n2026-4-6\n";
        StringReader input = new StringReader(data);
        Console.SetIn(input);
        ProjectRepo consoles = new();
        consoles.AddProjectMethod();
    }

    [Test]
    public void AddRoleValidInput()
    {
        var data = "1\n1\ndeveloper\n";
        StringReader input = new StringReader(data);
        Console.SetIn(input);
        RoleRepo consoles = new();
        consoles.AddRoleMethods();
    }

    [Test]
    public void AddNegativeRoleValidInput()
    {
        var data = "1\n-2\n2\ndeveloper\n";
        StringReader input = new StringReader(data);
        Console.SetIn(input);
        RoleRepo consoles = new();
        consoles.AddRoleMethods();
    }

    [Test]
    public void AddDuplicateRoleValidInput()
    {
        var data = "2\n91\ndeveloper\n31\ntesting\n";
        StringReader input = new StringReader(data);
        Console.SetIn(input);
        RoleRepo consoles = new();
        consoles.AddRoleMethods();
    }


}
}




