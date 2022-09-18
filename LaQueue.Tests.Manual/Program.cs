using System;
using System.Threading.Tasks;
using LaQueue.Web.Clients;

Console.WriteLine("Hello, World!");

var apiServerClient = new ApiClient();
apiServerClient.CreatePublisherEndpoint<Student>(HandlerOfThings, "students");
apiServerClient.RunApiServer("https://localhost:1985");

ValueTask HandlerOfThings(Student student)
{
    DoSomethingWithStudent(student);

    return ValueTask.CompletedTask;
} 

static void DoSomethingWithStudent(Student student) =>
    Console.WriteLine(student.Name);

public class Student
{
    public string Name { get; set; }
}
