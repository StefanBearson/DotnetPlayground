namespace PlayWithXUnit;

public class NameThing
{
    private string Name { get; set; } = "Kalle";

    internal string ChangeNameTo(string newName, int age)
    {
        if(newName == "Erik")
            throw new System.Exception("Name cannot be Erik");

        if (newName == "")
        {
            Name = "John Doe";
            return Name;
        }
        
        if (age < 18)
        {
            Name = "Child";
            return Name;
        }
            
        
        Name = newName;

        return Name;
    }
}