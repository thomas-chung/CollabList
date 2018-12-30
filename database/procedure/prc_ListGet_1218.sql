create procedure prc_ListGet_1218
(
    @listId                         uniqueidentifier
    ,@returnItems                   bit
    ,@onlyReturnUncompletedItems    bit
)
as

-- First result set returns data about the list
select ListId, OwnerId, CreatedDateTime, Title, Description from tbl_List where ListId = @listId

if @returnItems = 1
begin
    -- second result set for the list items
    select  ItemId
            ,ListId
            ,CreatorId
            ,CreatedDateTime
            ,Title
            ,Description
            ,IsComplete
            ,ExecutorId
            ,CompletedDateTime 
    from    tbl_ListItem
    where   ListId = @listId
            and (@onlyReturnUncompletedItems = 0 
                or (@onlyReturnUncompletedItems = 1 and IsComplete = 0))
end