
create table Ticket(
                   [Id] int not null identity(1,1) primary key,
                   [UserName] nvarchar(20) not null,
				   [NumberOfSeats] int not null,
				   [ShowTime] nvarchar(10),
				   [TheatreId] int references Theatre(id),
                   [MovieId] int references Movie(id),
				   [CreatedDate] datetime,
				   [UpdatedDate] datetime,
                   [DeletedDate] datetime,
				   [IsDeleted] bit
				   )


