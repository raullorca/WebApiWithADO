CREATE TABLE [dbo].[Employee] (
    [Id]        INT            NOT NULL,
    [CompanyId] INT            NOT NULL,
    [CreatedOn] DATETIME2 (7)  NOT NULL,
    [DeletedOn] DATETIME2 (7)  NOT NULL,
    [Email]     NVARCHAR (MAX) NOT NULL,
    [Fax]       NVARCHAR (MAX) NOT NULL,
    [Name]      NVARCHAR (MAX) NOT NULL,
    [LastLogin] DATETIME2 (7)  NOT NULL,
    [Password]  NVARCHAR (MAX) NOT NULL,
    [PortalId]  INT            NOT NULL,
    [RoleId]    INT            NOT NULL,
    [StatusId]  INT            NOT NULL,
    [Telephone] NVARCHAR (MAX) NOT NULL,
    [UpdatedOn] DATETIME2 (7)  NOT NULL,
    [Username]  NVARCHAR (MAX)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

