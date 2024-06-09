using CourseERP.Business.Services.Implementations;
using CourseERP.Business.Services.Interfaces;
using CourseERP.Core.CoreModels;
using CourseERP.DataBase.DAL;
using System.ComponentModel.Design;

namespace CourseERP.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IGroup groupService = new GroupServiceImplementation();
            IStudent studentSevice = new StudentServiceImplementation();
            Student student = null;
            Group group = null;

            while (true) 
            {
                Console.WriteLine("Main menu:");
                Console.WriteLine("1.Group Operations:");
                Console.WriteLine("2.Student Operations:");
                Console.WriteLine("3.Add student to Group");                
                Console.Write("Select an option (1, 2, 3 or 0): ");
                string option = Console.ReadLine();
                if (option == "1")
                {
                    while (true)
                    {
                        
                        Console.WriteLine("1.Create Group");
                        Console.WriteLine("2.Get Group");
                        Console.WriteLine("3.Get All Groups");
                        Console.WriteLine("4.Remove Group");
                        Console.WriteLine("5.Exit");
                        string groupOptions = Console.ReadLine();
                        if (groupOptions == "1")
                        {
                            Console.Write("Enter group name: ");
                            string name = Console.ReadLine();
                            group = new Group();
                            group.Name = name;
                            groupService.Create(group);
                            Console.WriteLine("Group was created succesfully!");
                            Console.WriteLine(group);
                        }
                        if (groupOptions == "2")
                        {
                            Console.Write("Enter group Id: ");
                            if (int.TryParse(Console.ReadLine(), out int Id))
                            {
                                try
                                {
                                    group = groupService.GetGroup(Id);
                                    Console.WriteLine(group);

                                }
                                catch (NullReferenceException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {

                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Id format.");
                            }
                        }
                        if (groupOptions == "3")
                        {
                            groupService.GetAll().ForEach(x => Console.WriteLine(x));
                        }
                        if (groupOptions == "4")
                        {
                            Console.Write("Enter group Id: ");
                            if (int.TryParse(Console.ReadLine(), out int Id))
                            {
                                try
                                {
                                    groupService.Remove(Id);
                                }
                                catch (NullReferenceException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {

                                    Console.WriteLine(ex.Message);
                                }

                            }
                            else
                            {
                                Console.WriteLine("Invalid Id format.");
                            }

                        }
                        if (groupOptions == "5")
                        {
                            Console.WriteLine("Exiting group options and going back to the Main Menu");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid option. Please select 1, 2, 3, 4, or 5.");
                        }

                    }
                }
                if (option == "2")
                {
                    while (true)
                    {
                      
                        Console.WriteLine("1.Create Student");
                        Console.WriteLine("2.Get Student");
                        Console.WriteLine("3.Get All Students");
                        Console.WriteLine("4.Remove Student");
                        Console.WriteLine("5.Exit");
                        string studentOptions = Console.ReadLine();
                        if (studentOptions == "1")
                        {
                            Console.Write("Enter student name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter student grade: ");
                            double.TryParse(Console.ReadLine(), out double grade);
                            student = new Student();
                            student.FullName = name;
                            student.Grade = grade;
                            studentSevice.Create(student);
                            Console.WriteLine("Student was created succesfully!");
                            Console.WriteLine(student);
                        }
                        if (studentOptions == "2")
                        {
                            Console.Write("Enter student Id: ");
                            if (int.TryParse(Console.ReadLine(), out int Id))
                            {
                                try
                                {
                                    student = studentSevice.GetStudent(Id);
                                    Console.WriteLine(group);

                                }
                                catch (NullReferenceException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {

                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Id format.");
                            }
                        }
                        if (studentOptions == "3")
                        {
                            studentSevice.GetAll().ForEach(x => Console.WriteLine(x));
                        }
                        if (studentOptions == "4")
                        {
                            Console.Write("Enter student Id: ");
                            if (int.TryParse(Console.ReadLine(), out int Id))
                            {
                                try
                                {
                                    studentSevice.Remove(Id);
                                }
                                catch (NullReferenceException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {

                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Id format.");
                            }
                        }
                        if (studentOptions == "5")
                        {
                            Console.WriteLine("Exiting group options and going back to the Main Menu");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid option. Please select 1, 2, 3, 4, or 5.");
                        }
                    }
                }                
                if (option == "3")
                {
                    Console.Write("Enter student Id: ");
                    if (int.TryParse(Console.ReadLine(), out int studentId))
                    {
                        try
                        {
                             student = studentSevice.GetStudent(studentId);

                            Console.Write("Enter group Id: ");
                            if (int.TryParse(Console.ReadLine(), out int groupId))
                            {
                                try
                                {
                                     group = groupService.GetGroup(groupId);

                                    // Check if the student is already in any group
                                    bool studentExistsInAnyGroup = CourseERPDataBase.Groups.Any(g => g.Students.Contains(student));
                                    if (studentExistsInAnyGroup)
                                    {
                                        Console.WriteLine("Student is already in a group and cannot be added to another group.");
                                    }
                                    else
                                    {
                                        group.Students.Add(student);
                                        Console.WriteLine($"Student {student.FullName} added to group {group.Name}.");
                                    }
                                }
                                catch (NullReferenceException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid group Id format.");
                            }
                        }
                        catch (NullReferenceException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid student Id format.");
                    }
                }
                if (option == "0") 
                {
                    Console.WriteLine("Exiting menu...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please select 1, 2, 3 or 0.");
                }







                


            }
            


        }
    }
}
