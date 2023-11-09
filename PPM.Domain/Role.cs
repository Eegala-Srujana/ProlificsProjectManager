using PPM.Model;

namespace PPM.Domain
{
    public class Role : IEntityOperatio<RoleDetails>
    {
        public static List<RoleDetails> roleList = new List<RoleDetails>();
        public void AddEntity(RoleDetails roleDetails)
        {
            roleList.Add(roleDetails);
        }

         public List<RoleDetails> ListAll()
         {
            return roleList;
         }

        public RoleDetails ListById(int id)
        {
            return roleList.Find(r => r.RoleId == id)!;
        }



        public void DeleteById(int id)
        {
            for (int i = 0; i < roleList.Count; i++)
            {
                if (roleList[i].RoleId == id)
                {
                    roleList.Remove(roleList[i]);
                }
            }
        }
       
    }
}
