create procedure prc_ListAdd_1218
(
    @ownerId        uniqueidentifier
    ,@title         nvarchar(2048)
    ,@description   nvarchar(max)
)
as

declare @newListId uniqueidentifier
select @newListId = newid()

begin tran ListAdd

begin try
    insert into tbl_List (ListId, OwnerId, CreatedDateTime, Title, Description)
    values (@newListId, @ownerId, getutcdate(), @title, @description)

    commit tran ListAdd
end try
begin catch
    rollback tran ListAdd;

    throw
end catch

exec prc_ListGet_1218 @newListId