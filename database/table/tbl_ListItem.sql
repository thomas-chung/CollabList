create table tbl_ListItem
(
    ItemId              uniqueidentifier not null
    ,ListId             uniqueidentifier not null
    ,CreatorId          uniqueidentifier not null
    ,CreatedDateTime    datetime not null
    ,Title              nvarchar(2048) not null
    ,Description        nvarchar(max)
    ,IsComplete         bit
    ,ExecutorId         uniqueidentifier
    ,CompletedDateTime  datetime
    ,constraint pk_ListItem_ItemId primary key (ItemId)
    ,constraint fk_User_Executor foreign key (ExecutorId) references tbl_User(UserId)
    ,constraint fk_User_Creator foreign key (CreatorId) references tbl_User(UserId)
    ,constraint fk_List_ListId foreign key (ListId) references tbl_List(ListId)
    ,index ix_ListItemId nonclustered (ListId)
);