create procedure prc_UserAdd_1218
(
    @userId   uniqueidenfier
)
as

select UserId, Email, CreatedDateTime from tbl_User where UserId = @userId