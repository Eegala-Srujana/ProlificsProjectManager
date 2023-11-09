using PPM.Model;
using System.Linq;
namespace PPM.Domain
{
    public class Project : IEntityOperatio<ProjectDetails>
    {
        public static List<ProjectDetails> projectList = new List<ProjectDetails>();
        public void AddEntity(ProjectDetails projectDetails)
        {
            projectList.Add(projectDetails);
        }
        public void DeleteById(int id)
        {
            for (int i = 0; i < projectList.Count; i++)
            {
                if (projectList[i].ProjectId == id)
                {
                    projectList.Remove(projectList[i]);
                }
            }



        }
        public List<ProjectDetails> ListAll()
        {
            return projectList;
        }

        public ProjectDetails ListById(int id)
        {
            return Project.projectList.SingleOrDefault(p => p.ProjectId == id)!;


        }
    }
}