create procedure prc_ListItemComplete_1218
(
    @itemId             uniqueidentifier
    ,@executorId        uniqueidentifier
)
as

begin tran ListItemComplete

begin try
    update tbl_ListItem set IsComplete = 1, ExecutorId = @executorId, CompletedDateTime = getutcdate() where ItemId = @itemId

    commit tran ListItemComplete
end try
begin catch
    rollback tran ListItemComplete;

    throw
end catch

exec prc_ItemListGet_1218 @itemId