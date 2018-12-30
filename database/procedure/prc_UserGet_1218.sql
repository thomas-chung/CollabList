create procedure prc_UserGet_1218
(
    @userId   uniqueidentifier
)
as

select UserId, Email, CreatedDateTime from tbl_User where UserId = @userId