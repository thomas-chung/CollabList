create procedure prc_ListItemAdd_1218
(
    @listId             uniqueidentifier
    ,@creatorId         uniqueidentifier
    ,@title             nvarchar(2048)
    ,@description       nvarchar(max)
)
as

begin tran ListItemAdd

declare @itemId UNIQUEIDENTIFIER
select @itemId = newid()

begin try
    insert into tbl_ListItem (ItemId, ListId, CreatorId, CreatedDateTime, Title, Description)
    values (@itemId, @listId, @creatorId, getutcdate(), @title, @description)

    commit tran ListItemAdd
end try
begin catch
    rollback tran ListItemAdd;

    throw
end catch

exec prc_ListItemGet_1218 @itemId