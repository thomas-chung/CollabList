create table tbl_User
(
    UserId              uniqueidentifier not null
    ,Email              nvarchar(512) not null
    ,CreatedDateTime    datetime
    ,constraint pk_User_UserId primary key (UserId)
    ,constraint uc_email unique (Email)
    ,index ix_User_Email nonclustered (Email)
)