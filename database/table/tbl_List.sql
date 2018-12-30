create table tbl_List
(
    ListId              uniqueidentifier not null
    ,OwnerId            uniqueidentifier not null
    ,CreatedDateTime    datetime not null
    ,Title              nvarchar(2048) not null
    ,Description        nvarchar(max)
    ,constraint pk_User_UserId primary key (UserId)
    ,constraint fk_User_List_UserId foreign key (OwnerId) references tbl_User(UserId)
)