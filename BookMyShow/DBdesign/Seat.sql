create table Seat(
                   [Id] int not null identity(1,1) primary key,
                   [Number] nvarchar(5) not null,
				   [ShowTime] nvarchar(10) ,
				   [ShowId] int references Show(id),
				   [TheatreId] int references Theatre(id),
                   [MovieId] int references Movie(id),
				   [TicketId] int,
				   [Availability] nvarchar(20) not null,
				   [CreatedDate] datetime,
				   [UpdatedDate] datetime,
                   [DeletedDate] datetime,
				   [IsDeleted] bit
				   )

