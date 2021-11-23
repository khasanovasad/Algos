using System;

namespace DesignPatterns
{
    public class UserObject
    {
        public UserObject(uint id, string username, string password, string firstName, string middleName, string lastName, DateTime dateOfBirth, string currentAddress, string birthPlace)
        {
            Id = id;
            Username = username;
            Password = password;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            CurrentAddress = currentAddress;
            BirthPlace = birthPlace;
        }

        public uint Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CurrentAddress { get; set; }
        public string BirthPlace { get; set; }
    }

    public class UserObjectBuilder
    {
        private Lazy<UserObject> _user;

        private uint _id;
        private string _username;
        private string _password;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private string _currentAddress;
        private string _birthPlace;

        public Lazy<UserObject> Build()
        {
            _user = new Lazy<UserObject>(() => new UserObject(_id, _username, _password, _firstName, _middleName, _lastName, _dateOfBirth, _currentAddress, _birthPlace));
            return _user;
        }

        public UserObjectBuilder WithId(uint id)
        {
            _id = id;
            return this;
        }

        public UserObjectBuilder WithUsername(string username)
        {
            _username = username;
            return this;
        }

        public UserObjectBuilder WithPassword(string password)
        {
            _password = password;
            return this;
        }

        public UserObjectBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public UserObjectBuilder WithMiddleName(string middleName)
        {
            _middleName = middleName;
            return this;
        }

        public UserObjectBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public UserObjectBuilder WithDateOfBirth(DateTime dateOfBirth)
        {
            _dateOfBirth = dateOfBirth;
            return this;
        }

        public UserObjectBuilder WithCurrentAddress(string currentAddress)
        {
            _currentAddress = currentAddress;
            return this;
        }

        public UserObjectBuilder WithBirthPlace(string birthPlace)
        {
            _birthPlace = birthPlace;
            return this;
        }
    }
}