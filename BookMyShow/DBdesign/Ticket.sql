use BMSTask7;

create table Movie(
                   [Id] int not null identity(1,1) primary key,
                   [Title] nvarchar(20) not null,
				   [Language] nvarchar(10) not null,
				   [Genre] nvarchar(10) not null,
				   [ImageUrl] nvarchar(30) not null,
                   [Description] nvarchar(100) not null,
				   [Price] int not null,
				   [CreatedDate] nvarchar(15),
				   [UpdatedDate] nvarchar(15),
                   [DeletedDate] nvarchar(15),
				   [IsDeleted] bit
				   )
create table Theatre(
                   [Id] int not null identity(1,1) primary key,
                   [Name] nvarchar(20) not null,
				   [Location] nvarchar(20) not null,
				   [CreatedDate] nvarchar(15),
				   [UpdatedDate] nvarchar(15),
                   [DeletedDate] nvarchar(15),
				   [IsDeleted] bit 
				   )
create table Show(
                   [Id] int not null identity(1,1) primary key,
                   [Name] nvarchar(20) not null,
				   [ShowTime] nvarchar(15) not null,
				   [TheatreId] int references Theatre(id),
                   [MovieId] int references Movie(id),
				   [Capacity] int not null,
				   [CreatedDate] nvarchar(15),
				   [UpdatedDate] nvarchar(15),
                   [DeletedDate] nvarchar(15),
				   [IsDeleted] bit 
				   )
create table Ticket(
                   [Id] int not null identity(1,1) primary key,
                   [UserName] nvarchar(20) not null,
				   [NumberOfSeats] int not null,
				   [ShowTime] nvarchar(10),
				   [TheatreId] int references Theatre(id),
                   [MovieId] int references Movie(id),
				   [CreatedDate] nvarchar(15),
				   [UpdatedDate] nvarchar(15),
                   [DeletedDate] nvarchar(15),
				   [IsDeleted] bit
				   )
create table Seat(
                   [Id] int not null identity(1,1) primary key,
                   [Number] nvarchar(5) not null,
				   [ShowTime] nvarchar(10) ,
				   [ShowId] int references Show(id),
				   [TheatreId] int references Theatre(id),
                   [MovieId] int references Movie(id),
				   [TicketId] int,
				   [Availability] nvarchar(20) not null
				   )

