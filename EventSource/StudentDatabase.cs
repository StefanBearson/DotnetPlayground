using System.Reflection.Metadata;
using System.Text.Json;
using EventSource.Events;

namespace EventSource;

public class StudentDatabase
{
    private readonly Dictionary<Guid, SortedList<DateTime, Event>> _studentData = new();
    private readonly Dictionary<Guid, Student> _students = new();
    public void Append(Event @event)
    {
        var steam = _studentData!.GetValueOrDefault(@event.StreamId, null);
        if (steam is null)
        {
            _studentData[@event.StreamId] = new SortedList<DateTime, Event>();
        }
        @event.CreatedAtUtc = DateTime.UtcNow;
        _studentData[@event.StreamId].Add(@event.CreatedAtUtc, @event);
        
        _students[@event.StreamId] = GetStudent(@event.StreamId)!;
    }
    
    public Student? GetStudentView(Guid studentId)
    {
        if(!_students!.ContainsKey(studentId))
        {
            return null;
        }
        return _students[studentId];
    }
    public Student? GetStudent(Guid studentId)
    {
        if(!_studentData.ContainsKey(studentId))
        {
            return null;
        }
        var student = new Student();
        var studentEvents = _studentData[studentId].Values;
        foreach (var @event in studentEvents)
        {
            student.Apply(@event);
        }
 
        return student;
    }
    
}