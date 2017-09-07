using System;

namespace MyClasses
{
    public class Person
    {
        public int ObjectId { get; set; }
        public String StateFileNumber { get; set; }
        public String SocialSecurityNumber { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public int BirthYear { get; set; }
        public int BirthMonth { get; set; }
        public int BirthDay { get; set; }
        public String Gender { get; set; }
        public String NewbornScreeningNumber { get; set; }
        public String IsPartOfMultipleBirth { get; set; }
        public int BirthOrder { get; set; }
        public String BirthCounty { get; set; }
        public String MotherFirstName { get; set; }
        public String MotherMiddleName { get; set; }
        public String MotherLastName { get; set; }
        public String Phone1 { get; set; }
        public String Phone2 { get; set; }

        public override string ToString()
        {
            return $"ObjectId = {ObjectId} \n" +
                $"StateFileNumber = {StateFileNumber} \n" +
                $"SocialSecurityNumber = {SocialSecurityNumber} \n" +
                $"FirstName = {FirstName} \n" +
                $"MiddleName = {MiddleName} \n" +
                $"LastName = {LastName} \n" +
                $"BirthYear = {BirthYear} \n" +
                $"BirthMonth = {BirthMonth} \n" +
                $"BirthDay = {BirthDay} \n" +
                $"Gender = {Gender} \n" +
                $"NewbornScreeningNumber = {NewbornScreeningNumber} \n" +
                $"IsPartOfMultipleBirth = {IsPartOfMultipleBirth} \n" +
                $"BirthOrder = {BirthOrder} \n" +
                $"BirthCounty = {BirthCounty} \n" +
                $"MotherFirstName = {MotherFirstName} \n" +
                $"MotherMiddleName = {MotherMiddleName} \n" +
                $"MotherLastName = {MotherLastName} \n" +
                $"Phone1 = {Phone1} \n" +
                $"Phone2 = {Phone2} \n";
        }
    }
}
