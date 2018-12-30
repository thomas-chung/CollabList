create procedure prc_ListItemGet_1218
(
    @itemId             uniqueidentifier
)
as

select ItemId, ListId, CreatorId, CreatedDateTime, Title, Description, IsComplete, ExecutorId, CompletedDateTime from tbl_ListItem where ItemId = @itemId