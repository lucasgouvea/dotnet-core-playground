using System;

namespace dotnet_playground
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public UserContact Contact { get; set; }

        public UserDocument Document { get; set; }
    }
}
