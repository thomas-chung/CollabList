using System;

namespace CollabList.Model
{
    public class List
    {
        public Guid Id
        {
            get;
            private set;
        }

        public User Owner
        {
            get;
            private set;
        }

        public DateTime CreatedDateTime
        {
            get;
            private set;
        }

        public string Title
        {
            get;
            private set;
        }

        public string Description
        {
            get;
            private set;
        }

        public List(Guid id, User owner, DateTime createdDateTime, string title, string description)
        {
            this.Id = id;
            this.Owner = owner;
            this.CreatedDateTime = createdDateTime;
            this.Title = title;
            this.Description = description;
        }
    }
}