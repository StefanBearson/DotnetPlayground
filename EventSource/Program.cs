using EventSource;
using EventSource.Events;

var studentDatabase = new StudentDatabase();
var studentId = Guid.Parse("410efa39-917b-45d4-83ff-f9a618d760a3");

var studentCreated = new StudentCreated()
{
    StudentId = studentId,
    FullName = "John Doe",
    Email = "mail@mail.com",
    DateOfBirth = new DateTime(1990, 1, 1)
};

studentDatabase.Append(studentCreated);

var studentUpdated = new StudentUpdated()
{
    StudentId = studentId,
    FullName = "Jane Doe",
    Email = "newmail@mail.com"
};

studentDatabase.Append(studentUpdated);

var studentEnrolled = new StudentEnrolled()
{
    StudentId = studentId,
    CourseName = "Math"
};

var studentEnrolled2 = new StudentEnrolled()
{
    StudentId = studentId,
    CourseName = "English"
};

studentDatabase.Append(studentEnrolled);
studentDatabase.Append(studentEnrolled2);

Student studentView = studentDatabase.GetStudentView(studentId);
Student student = studentDatabase.GetStudent(studentId);
Console.WriteLine("test");