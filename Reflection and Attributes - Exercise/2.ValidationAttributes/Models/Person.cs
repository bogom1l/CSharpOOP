namespace ValidationAttributes.Models
{
    using ValidationAttributes.Utilities;

    public class Person
    {
        [MyRequiered]
        public string FullName { get; set; }

        [MyRange(12, 90)]
        public int Age { get; set; }


        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }
    }
}
