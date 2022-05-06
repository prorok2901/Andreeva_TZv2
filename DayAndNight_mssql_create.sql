CREATE TABLE [user] (
	id int NOT NULL,
	name varchar(255) NOT NULL,
	role bigint NOT NULL
)
GO
CREATE TABLE [role] (
	name varchar(255) NOT NULL,
  CONSTRAINT [PK_ROLE] PRIMARY KEY CLUSTERED
  (
  [name] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [booking_history] (
	id bigint NOT NULL,
	borrow_room bigint NOT NULL,
	date_departure date NOT NULL,
  CONSTRAINT [PK_BOOKING_HISTORY] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [borrow_room] (
	id int NOT NULL,
	room bigint NOT NULL,
	client varchar(16) NOT NULL,
	administrator int NOT NULL,
	status varchar(8) NOT NULL,
	count_day int NOT NULL,
	date_settlement date NOT NULL,
  CONSTRAINT [PK_BORROW_ROOM] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [client] (
	phone varchar(16) NOT NULL,
	name bigint NOT NULL,
	passport_details varchar(10),
  CONSTRAINT [PK_CLIENT] PRIMARY KEY CLUSTERED
  (
  [phone] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [info_room] (
	num_room bigint NOT NULL,
	count_room bigint NOT NULL,
	capacity bigint NOT NULL,
	type_room varchar(255) NOT NULL,
  CONSTRAINT [PK_INFO_ROOM] PRIMARY KEY CLUSTERED
  (
  [num_room] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [type_room] (
	name varchar(255) NOT NULL,
  CONSTRAINT [PK_TYPE_ROOM] PRIMARY KEY CLUSTERED
  (
  [name] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
ALTER TABLE [user] WITH CHECK ADD CONSTRAINT [user_fk0] FOREIGN KEY ([role]) REFERENCES [role]([name])
ON UPDATE CASCADE
GO
ALTER TABLE [user] CHECK CONSTRAINT [user_fk0]
GO


ALTER TABLE [booking_history] WITH CHECK ADD CONSTRAINT [booking_history_fk0] FOREIGN KEY ([borrow_room]) REFERENCES [borrow_room]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [booking_history] CHECK CONSTRAINT [booking_history_fk0]
GO

ALTER TABLE [borrow_room] WITH CHECK ADD CONSTRAINT [borrow_room_fk0] FOREIGN KEY ([room]) REFERENCES [info_room]([num_room])
ON UPDATE CASCADE
GO
ALTER TABLE [borrow_room] CHECK CONSTRAINT [borrow_room_fk0]
GO
ALTER TABLE [borrow_room] WITH CHECK ADD CONSTRAINT [borrow_room_fk1] FOREIGN KEY ([client]) REFERENCES [client]([phone])
ON UPDATE CASCADE
GO
ALTER TABLE [borrow_room] CHECK CONSTRAINT [borrow_room_fk1]
GO
ALTER TABLE [borrow_room] WITH CHECK ADD CONSTRAINT [borrow_room_fk2] FOREIGN KEY ([administrator]) REFERENCES [user]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [borrow_room] CHECK CONSTRAINT [borrow_room_fk2]
GO


ALTER TABLE [info_room] WITH CHECK ADD CONSTRAINT [info_room_fk0] FOREIGN KEY ([type_room]) REFERENCES [type_room]([name])
ON UPDATE CASCADE
GO
ALTER TABLE [info_room] CHECK CONSTRAINT [info_room_fk0]
GO


