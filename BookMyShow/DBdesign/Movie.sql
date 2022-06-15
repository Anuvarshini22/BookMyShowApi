create table Movie(
                   [Id] int not null identity(1,1) primary key,
                   [Title] nvarchar(20) not null,
				   [Language] nvarchar(10) not null,
				   [Genre] nvarchar(10) not null,
				   [ImageUrl] nvarchar(30) not null,
                   [Description] nvarchar(100) not null,
				   [Price] int not null,
				   [CreatedDate] datetime,
				   [UpdatedDate] datetime,
                   [DeletedDate] datetime,
				   [IsDeleted] bit
				   )


