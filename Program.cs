using System;

namespace access_modifiers
{
    public class person
    {
        private DateTime _birthday;
        public void SetBirthday(DateTime birthday)
        {
            _birthday = birthday;
        }
        public DateTime GetBirthday()
        {
            return _birthday;
        }
    }
    class bday { 
        static void Main(string[] args)
        {
            var person = new person();
            person.SetBirthday(new DateTime(1998, 2, 2));
            Console.WriteLine(person.GetBirthday());
        }
    }
}
