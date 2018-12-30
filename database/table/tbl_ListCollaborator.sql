create table tbl_ListCollaborator
(
    ListId              uniqueidentifier not null
    ,CollaboratorId     uniqueidentifier not null
    ,AddedDateTime      datetime not null
    ,constraint pk_ListCollaborators primary key (ListId, CollaboratorId)
    ,constraint fk_User_List_CollaboratorId foreign key (CollaboratorId) references tbl_User(UserId)
    ,constraint fk_User_List_ListId foreign key (ListId) references tbl_List(ListId)
)