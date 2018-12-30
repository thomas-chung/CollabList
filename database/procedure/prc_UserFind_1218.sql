create procedure prc_UserFind_1218
(
    @email   nvarchar(512)
)
as

select UserId, Email, CreatedDateTime from tbl_User where Email = @email