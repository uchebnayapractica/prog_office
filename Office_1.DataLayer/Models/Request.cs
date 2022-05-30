namespace Office_1.DataLayer.Models;

public class Request
{
    
    public int Id { get; set; }
    public Client IdClient;
    public string DirectorName;
    public string Subject;
    public string Content;
    public string Resolution;
    public Status Status;


}