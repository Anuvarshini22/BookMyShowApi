create table Theatre(
                   [Id] int not null identity(1,1) primary key,
                   [Name] nvarchar(20) not null,
				   [Location] nvarchar(20) not null,
				   [CreatedDate] datetime,
				   [UpdatedDate] datetime,
                   [DeletedDate] datetime,
				   [IsDeleted] bit 
				   )


