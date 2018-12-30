create procedure prc_UserFind_1218
(
    @email   nvarchar(1024)
)
as

select UserId, Email, CreatedDateTime from tbl_User where Email = @email