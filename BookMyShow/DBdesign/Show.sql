create table Show(
                   [Id] int not null identity(1,1) primary key,
                   [Name] nvarchar(20) not null,
				   [ShowTime] nvarchar(15) not null,
				   [TheatreId] int references Theatre(id),
                   [MovieId] int references Movie(id),
				   [Capacity] int not null,
				   [CreatedDate] datetime,
				   [UpdatedDate] datetime,
                   [DeletedDate] datetime,
				   [IsDeleted] bit 
				   )


