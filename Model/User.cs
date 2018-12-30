using System;

namespace CollabList.Model
{
    public class User
    {
        public Guid Id 
        {
            get;
            private set;
        }

        public string Email 
        {
            get;
            private set;
        }

        public DateTime CreatedDateTime 
        {
            get;
            private set;
        }

        internal User(Guid id, string email, DateTime createdDateTime)
        {
            this.Id = id;
            this.Email = email;
            this.CreatedDateTime = createdDateTime;
        }
    }
}