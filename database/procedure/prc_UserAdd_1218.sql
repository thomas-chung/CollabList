create procedure prc_UserAdd_1218
(
    @email   nvarchar(1024)
)
as

declare @newUserId UNIQUEIDENTIFIER
select @newUserId = newid()

if not exists (select 1 from tbl_User where Email = @email)
begin
    begin tran UserAdd

    begin try
        insert into tbl_User (UserId, Email, CreatedDateTime) 
            values (@newUserId, @email, getutcdate())
    end try
    begin catch
        rollback tran UserAdd;

        throw
    end catch
end

exec prc_UserGet_1218 @newUserId