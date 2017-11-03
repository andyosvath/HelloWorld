CREATE TABLE [tblPerson] (
	[PersonID] [int] IDENTITY (1, 1) NOT NULL ,
	[FirstName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[LastName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Email] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	CONSTRAINT [PK_tblPerson] PRIMARY KEY  CLUSTERED 
	(
		[PersonID]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO