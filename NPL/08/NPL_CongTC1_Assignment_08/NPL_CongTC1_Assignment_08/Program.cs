using System;

namespace NPL_CongTC1_Assignment_08
{
    class Program
    {
        static void Main(string[] args)
        {
            // Student full param
            Student s0 = new Student("Do Van H", "CNTT1", "Male", DateTime.Parse("5/4/2021"), 21, "Hà Nội", "Single", 7.5m, "A");

            //Student object initialization, using Optional Arguments
            Student s1 = new Student("Tran Chien Cong","CNTT1","Male", DateTime.Parse("5/4/2021"), 21, "Hà Nội", mark: 8m);

            // using Named Arguments
            Student s2 = new Student(@class: "CNTT1", name: "Đo Ba Hoat", age: 21, relationship: "album", mark: 8.5m,  address: "Hà Nội", gender: "Male", entryDate: DateTime.Parse("5/4/2021"));
          
            //Graduate method transmission parameter
            Console.WriteLine($"Graduate method transmission parameter S1: {s1.Graduate(3.6f)}");
            //Graduate method no parameter transmission.
            Console.WriteLine($"Graduate method transmission parameter S2: {s2.Graduate()}");

            Console.WriteLine("=================================================================");
            Console.WriteLine("{0,-20}{1,-10}{2,-10}{3,-20}{4,-10}{5,-10}", "Name", "Class", "Gender", "Relationship", "Age", "Grade");
            //ToString method transmission parameter.
            Console.WriteLine(s1.toString(s1.Name, s1.Class, s1.Gender, s1.Relationship, s1.Age, s1.Graduate(3.5f)));
            //ToString method no parameter transmission.
            Console.WriteLine(s0.toString());
            Console.WriteLine(s2.toString());
            
            Console.ReadLine();

            // Commenting on the benefits of using Optional Arguments, Named Arguments.
            /* 1.Named Arguments:
             * Named arguments free you from matching the order of parameters in the parameter lists of called methods
             * If you don't remember the order of the parameters but know their names, you can send the arguments in any order
                => example: Student s2 = new Student(@class: "CNTT1", name: "Đo Ba Hoat", age: 21, relationship: "album", mark: 8.5m,  address: "Hà Nội", gender: "Male", entryDate: DateTime.Parse("5/4/2021"));
             * ======================================================================================================== 
             * 2. Optional Arguments
             * it is not necessary to introduce additional “overloaded” the implementation of the method
             * simplified call of complex methods or class constructors
                => example: Add(1,2)
                            Add(1,2,3)
                            Add(1,2,3,4)
                   We must write overload 4 times of function Add
                - With  optional argument we have one time 
                            Add(int a, int b, int c=0, int d=0)
               It actually similar with class cóntructors
            */

            // Note the rules when using Optional Arguments, Named Arguments.
            /* Named arguments
             * 1. Can combine named arguments with correct position => ex:new Student("Tran Chien Cong","CNTT1","Male", DateTime.Parse("5/4/2021"), 21, "Hà Nội");
             * 2. Positional arguments that follow any out-of-order named arguments are invalid 
                => ex: new Student("CNTT1", name:"Tran Chien Cong","Male", DateTime.Parse("5/4/2021"), 21, "Hà Nội");
             
             * Optional Arguments:
             * 1. A default value must be a constant expression
             * 2. Optional parameters are defined at the end of the parameter list, after any required parameters 
                => ex: public Student(string name, string @class, string gender,
                                      DateTime entryDate, int age, string address,
                                      string relationship = "Single", decimal mark = 0, string grade ="F"
                                      )
             */
        }
    }
}
