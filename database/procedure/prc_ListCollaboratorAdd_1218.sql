create procedure prc_ListAdd_1218
(
    @collaboratorId uniqueidentifier
    ,@listId        uniqueidentifier
)
as

begin tran ListCollaboratorAdd

begin try
    insert into tbl_ListCollaborator (ListId, CollaboratorId, AddedDateTime)
    values (@listId, @collaboratorId, getutcdate())

    commit tran ListCollaboratorAdd
end try
begin catch
    rollback tran ListCollaboratorAdd;

    throw
end catch