CREATE PROCEDURE [dbo].[Register_Channel]
	@ChannelName nvarchar (max),
	@Keywords nvarchar (max),
	@ChannelId int,
	@FirstName nvarchar (max),
	@LastName nvarchar (max),
	@Country nvarchar(max),
	@HomeAddress nvarchar(max),
	@PaymentMethod nvarchar(max),
	@userId int
AS
BEGIN
	INSERT INTO [dbo].[Channels]([ChannelName],[Keywords]) VALUES (@ChannelName, @Keywords);
	SELECT @ChannelId=SCOPE_IDENTITY();
	UPDATE [dbo].[AspNetUsers] SET [ChannelId] = @ChannelId, 
		[FirstName] = @FirstName, [SecondName] = @LastName, [Country] = @Country, [HomeAddress] = @HomeAddress, [PaymentMethod] = @PaymentMethod
		WHERE [Id] = @userId;
END

