CREATE TABLE [dbo].[General_Table] (
    [Id]                      INT            IDENTITY (1, 1) NOT NULL,
    [Machine_Type]            NCHAR (25)     NULL,
    [Year_Built]              INT            NULL,
    [Original_Owner]          NCHAR (100)    NULL,
    [Date_Acquired]           DATE           NULL,
    [Description]             VARCHAR (MAX)  NULL,
    [Image]                   IMAGE          NULL,
    [Maintenence_Information] VARCHAR (MAX)  NULL,
    [Model]                   NCHAR (25)     NULL,
    [Horse_Power]             NCHAR (50)     NULL,
    [Display_Location]        NVARCHAR (MAX) NULL,
    [Restoration_Status]      NCHAR (50)     NULL,
    [Link_to_TractorData]     NVARCHAR (MAX) NULL,
    [Donated_Or_Loaned]       NCHAR (10)     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

