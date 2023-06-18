using Academy.Context;
using Academy.Models;
using System;

Console.WriteLine();

AcademyDbContext context =new AcademyDbContext();

START:
Console.WriteLine("1. Create Group");
Console.WriteLine("2. Get All Groups");
Console.WriteLine("3. Get Group by Id");
Console.WriteLine("4. Delete Group");
Console.WriteLine("5. Create Student");
Console.WriteLine("6. Get All Students");
Console.WriteLine("7. Get Student by Id");
Console.WriteLine("8. Delete Student");
Console.WriteLine("9. Update Group");
Console.WriteLine("10. Update Student");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.Write("Enter your choice: ");
Console.ResetColor();
string selectMenu = Console.ReadLine();

switch (selectMenu)
{
    case "1":
        CreateGroup();
        goto START;
    case "2":
         GetAllGroups();
        goto START;
    case "3":
        GetGroupById();
        goto START;
    case "4":
         DeleteGroup();
        goto START;
    case "5":
        CreateStudent();
        goto START;
    case "6":
         GetAllStudents();
        goto START;
    case "7":
        GetStudentById();
        goto START;
    case "8":
         DeleteStudent();
        goto START;
    case "9":
        UpdateGroup();
        goto START;
    case "10":
        UpdateStudent();
        goto START;
    default:
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine("Please enter a valid option...");
        Console.ResetColor();
        goto START;
}


void CreateGroup()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("Enter group name: ");
    Console.ResetColor();
    string groupName = Console.ReadLine();

    Group group = new Group
    {
        Name = groupName,
        CreatedDate = DateTime.Now
    };

    context.Groups.Add(group);
    context.SaveChanges();
    Console.ForegroundColor = ConsoleColor.White;
    Console.BackgroundColor = ConsoleColor.Green;
    Console.WriteLine("Group created successfully");
    Console.ResetColor();
   
}

void CreateStudent()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("Enter student Name: ");
    string name = Console.ReadLine();
    Console.Write("Enter student Surname: ");
    string surname = Console.ReadLine();
    Console.Write("Enter student's group id: ");
    int groupId = int.Parse(Console.ReadLine());
    Console.ResetColor();

    Group group = context.Groups.FirstOrDefault(x => x.Id == groupId);
    if (group == null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Group ID does not exist");
        Console.ResetColor();
        return;
    }

    Student student = new Student
    {
        Name = name,
        Surname = surname,
        GroupId = groupId,
        CreatedDate = DateTime.Now
    };

    context.Students.Add(student);
    context.SaveChanges();

    Console.ForegroundColor = ConsoleColor.White;
    Console.BackgroundColor = ConsoleColor.Green;
    Console.WriteLine("Student added successfully");
    Console.ResetColor();
}

void GetAllGroups()
{
    List<Group> groups = context.Groups.ToList();
    foreach(Group group in groups)
    {
        Console.WriteLine(group.Id);
        Console.WriteLine(group.Name);
        Console.WriteLine(group.IsDeleted);
        Console.WriteLine(group.CreatedDate);
    }
}

void GetAllStudents()
{
    List<Student> students = context.Students.ToList();

    foreach (Student student in students)
    {
        Console.WriteLine("Student ID: " + student.Id);
        Console.WriteLine("Student Name: " + student.Name);
        Console.WriteLine("Student Surname: " + student.Surname);
        Console.WriteLine("Group ID: " + student.Group.Id);
        Console.WriteLine("Group Name: " + student.Group.Name);
        Console.WriteLine("IsDeleted: " + student.IsDeleted);
        Console.WriteLine("Created Date: " + student.CreatedDate);
        Console.WriteLine("Updated Date: " + student.UpdateDate);
    }
}

void GetGroupById()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("Enter group ID: ");
    Console.ResetColor();
    int groupId = int.Parse(Console.ReadLine());

    Group group = context.Groups.FirstOrDefault(x => x.Id == groupId);

    if (group == null)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine("Group is not found");
        Console.ResetColor();
    }
    else
    {
        Console.WriteLine("Group ID: " + group.Id);
        Console.WriteLine("Group Name: " + group.Name);
        Console.WriteLine("IsDeleted: " + group.IsDeleted);
        Console.WriteLine("Created Date: " + group.CreatedDate);
        Console.WriteLine("Updated Date: " + group.UpdateDate);
    }
}

void GetStudentById()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("Enter student ID: ");
    Console.ResetColor();
    int studentId = int.Parse(Console.ReadLine());

    Student student = context.Students.FirstOrDefault(x => x.Id == studentId);

    if (student == null)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine("Student is not found");
        Console.ResetColor();
    }
    else
    {
        Console.WriteLine("Student Name: " + student.Name);
        Console.WriteLine("Student Surname: " + student.Surname);
        Console.WriteLine("Group ID: " + student.Group.Id);
        Console.WriteLine("Group Name: " + student.Group.Name);
        Console.WriteLine("IsDeleted: " + student.IsDeleted);
        Console.WriteLine("Created Date: " + student.CreatedDate);
        Console.WriteLine("Updated Date: " + student.UpdateDate);
    }
}

void DeleteGroup()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Enter Group ID");
    Console.ResetColor();
    int.TryParse(Console.ReadLine(), out int id);

    Group group = context.Groups.FirstOrDefault(x => x.Id == id);
    if (group == null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Group is not Found");
        Console.ResetColor();
    }
    else
    {
        context.Groups.Remove(group);
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine("Group deleted successfully");
        Console.ResetColor();
        context.SaveChanges();
    }
}

void DeleteStudent()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Enter Student ID: ");
    int.TryParse(Console.ReadLine(), out int id);
    Console.ResetColor();

    Student student = context.Students.FirstOrDefault(x => x.Id == id);

    if (student == null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Student is not found");
        Console.ResetColor();
    }
    
    else
    {
        context.Students.Remove(student);
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine("Student deleted successfully");
        Console.ResetColor();
        context.SaveChanges();
    }
}

void UpdateGroup()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Enter Group ID: ");
    int groupId = int.Parse(Console.ReadLine());
    Console.ResetColor();

    Group group = context.Groups.FirstOrDefault(x => x.Id == groupId);

    if (group == null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Group is not found");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Enter new group name: ");
        string newGroupName = Console.ReadLine();
        Console.ResetColor();

        group.Name = newGroupName;

        group.UpdateDate = DateTime.Now;
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine("Group updated successfully");
        Console.ResetColor();
        context.SaveChanges();
    }
}

void UpdateStudent()
{
    Console.WriteLine("Enter Student ID: ");
    int studentId = int.Parse(Console.ReadLine());

    Student student = context.Students.FirstOrDefault(x => x.Id == studentId);

    if (student == null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Student is not found");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Enter new student name: ");
        string newStudentName = Console.ReadLine();
        student.Name = newStudentName;

        Console.Write("Enter new student surname: ");
        string newStudentSurname = Console.ReadLine();
        student.Surname = newStudentSurname;

        Console.Write("Enter new group ID: ");
        int newGroupId = int.Parse(Console.ReadLine());
        Console.ResetColor();

        Group newGroup = context.Groups.FirstOrDefault(x => x.Id == newGroupId);
        if (newGroup != null)
        {
            student.Group = newGroup;
            student.GroupId = newGroupId;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Group is not found");
            Console.ResetColor();
            return;
        }

        student.UpdateDate = DateTime.Now;
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine("Student updated successfully");
        Console.ResetColor();
        context.SaveChanges();
   
    }
}