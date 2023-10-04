namespace Akhmetov2.Domain;

public class Hospital
{
    
    public string hospital_name = "";
    public List<EmergencyDep> departments = new List<EmergencyDep>();
    
    
    
    
    public Hospital(string name)
    {
        hospital_name = name;
    }

    public Hospital(string name, List<EmergencyDep> dep)
    {
        this.hospital_name = name;
        departments = dep;
    }

    public Hospital()
    {
    }



    public void add_department(EmergencyDep dep)
    {
        departments.Add(dep);
    }

    

}