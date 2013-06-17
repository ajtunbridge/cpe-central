
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/17/2013 13:18:42
-- Generated from EDMX file: C:\Users\atunbridge\Documents\GitHub\cpe-central\CPECentral\CPECentral.Data.EF5\CPECentralModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CPECentral];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Documents_Operations]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Documents] DROP CONSTRAINT [FK_Documents_Operations];
GO
IF OBJECT_ID(N'[dbo].[FK_Documents_Parts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Documents] DROP CONSTRAINT [FK_Documents_Parts];
GO
IF OBJECT_ID(N'[dbo].[FK_Documents_PartVersions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Documents] DROP CONSTRAINT [FK_Documents_PartVersions];
GO
IF OBJECT_ID(N'[dbo].[FK_Employees_EmployeeGroups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_Employees_EmployeeGroups];
GO
IF OBJECT_ID(N'[dbo].[FK_Employees_Parts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_Employees_Parts];
GO
IF OBJECT_ID(N'[dbo].[FK_Holders_HolderGroups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Holders] DROP CONSTRAINT [FK_Holders_HolderGroups];
GO
IF OBJECT_ID(N'[dbo].[FK_HolderTools_Holders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HolderTools] DROP CONSTRAINT [FK_HolderTools_Holders];
GO
IF OBJECT_ID(N'[dbo].[FK_HolderTools_Tools]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HolderTools] DROP CONSTRAINT [FK_HolderTools_Tools];
GO
IF OBJECT_ID(N'[dbo].[FK_Methods_PartVersions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Methods] DROP CONSTRAINT [FK_Methods_PartVersions];
GO
IF OBJECT_ID(N'[dbo].[FK_Operations_MachineGroups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operations] DROP CONSTRAINT [FK_Operations_MachineGroups];
GO
IF OBJECT_ID(N'[dbo].[FK_Operations_PartVersions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operations] DROP CONSTRAINT [FK_Operations_PartVersions];
GO
IF OBJECT_ID(N'[dbo].[FK_OperationTools_Operations]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OperationTools] DROP CONSTRAINT [FK_OperationTools_Operations];
GO
IF OBJECT_ID(N'[dbo].[FK_OperationTools_Tools]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OperationTools] DROP CONSTRAINT [FK_OperationTools_Tools];
GO
IF OBJECT_ID(N'[dbo].[FK_Parts_Customers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Parts] DROP CONSTRAINT [FK_Parts_Customers];
GO
IF OBJECT_ID(N'[dbo].[FK_PartVersions_Parts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PartVersions] DROP CONSTRAINT [FK_PartVersions_Parts];
GO
IF OBJECT_ID(N'[dbo].[FK_Tools_ToolGroups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tools] DROP CONSTRAINT [FK_Tools_ToolGroups];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Documents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Documents];
GO
IF OBJECT_ID(N'[dbo].[EmployeeGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeGroups];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[HolderGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HolderGroups];
GO
IF OBJECT_ID(N'[dbo].[Holders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Holders];
GO
IF OBJECT_ID(N'[dbo].[HolderTools]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HolderTools];
GO
IF OBJECT_ID(N'[dbo].[MachineGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MachineGroups];
GO
IF OBJECT_ID(N'[dbo].[Methods]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Methods];
GO
IF OBJECT_ID(N'[dbo].[Operations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Operations];
GO
IF OBJECT_ID(N'[dbo].[OperationTools]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OperationTools];
GO
IF OBJECT_ID(N'[dbo].[Parts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Parts];
GO
IF OBJECT_ID(N'[dbo].[PartVersions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PartVersions];
GO
IF OBJECT_ID(N'[dbo].[ToolGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ToolGroups];
GO
IF OBJECT_ID(N'[dbo].[Tools]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tools];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [ModifiedBy] int  NOT NULL
);
GO

-- Creating table 'Documents'
CREATE TABLE [dbo].[Documents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FileName] varchar(150)  NOT NULL,
    [IsLocked] bit  NOT NULL,
    [PartId] int  NULL,
    [PartVersionId] int  NULL,
    [OperationId] int  NULL,
    [CreatedBy] int  NOT NULL,
    [ModifiedBy] int  NOT NULL
);
GO

-- Creating table 'EmployeeGroups'
CREATE TABLE [dbo].[EmployeeGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(30)  NOT NULL,
    [Permissions] int  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] varchar(30)  NOT NULL,
    [LastName] varchar(30)  NOT NULL,
    [UserName] varchar(30)  NOT NULL,
    [Password] char(88)  NOT NULL,
    [Salt] char(24)  NOT NULL,
    [EmployeeGroupId] int  NOT NULL,
    [LastViewedPartId] int  NULL
);
GO

-- Creating table 'HolderGroups'
CREATE TABLE [dbo].[HolderGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(30)  NOT NULL
);
GO

-- Creating table 'Holders'
CREATE TABLE [dbo].[Holders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [HolderGroupId] int  NOT NULL
);
GO

-- Creating table 'HolderTools'
CREATE TABLE [dbo].[HolderTools] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HolderId] int  NOT NULL,
    [ToolId] int  NOT NULL
);
GO

-- Creating table 'MachineGroups'
CREATE TABLE [dbo].[MachineGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(30)  NOT NULL,
    [NextNumber] int  NOT NULL
);
GO

-- Creating table 'Methods'
CREATE TABLE [dbo].[Methods] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(255)  NOT NULL,
    [IsPreferred] bit  NOT NULL,
    [PartVersionId] int  NOT NULL
);
GO

-- Creating table 'Operations'
CREATE TABLE [dbo].[Operations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Sequence] int  NOT NULL,
    [Description] varchar(255)  NOT NULL,
    [Notes] varbinary(max)  NULL,
    [SetupTime] int  NULL,
    [CycleTime] float  NULL,
    [MethodId] int  NOT NULL,
    [MachineGroupId] int  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [ModifiedBy] int  NOT NULL
);
GO

-- Creating table 'OperationTools'
CREATE TABLE [dbo].[OperationTools] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Position] int  NOT NULL,
    [Offset] int  NOT NULL,
    [UseOnePer] int  NOT NULL,
    [Holder] varchar(50)  NULL,
    [Notes] varchar(255)  NULL,
    [OperationId] int  NOT NULL,
    [ToolId] int  NOT NULL
);
GO

-- Creating table 'Parts'
CREATE TABLE [dbo].[Parts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DrawingNumber] varchar(50)  NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [ToolingLocation] varchar(50)  NULL,
    [CustomerId] int  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [ModifiedBy] int  NOT NULL
);
GO

-- Creating table 'PartVersions'
CREATE TABLE [dbo].[PartVersions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [VersionNumber] varchar(10)  NOT NULL,
    [PartId] int  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [ModifiedBy] int  NOT NULL
);
GO

-- Creating table 'ToolGroups'
CREATE TABLE [dbo].[ToolGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(30)  NOT NULL,
    [ParentGroupId] int  NULL
);
GO

-- Creating table 'Tools'
CREATE TABLE [dbo].[Tools] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(50)  NOT NULL,
    [ToolGroupId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [PK_Documents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmployeeGroups'
ALTER TABLE [dbo].[EmployeeGroups]
ADD CONSTRAINT [PK_EmployeeGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HolderGroups'
ALTER TABLE [dbo].[HolderGroups]
ADD CONSTRAINT [PK_HolderGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Holders'
ALTER TABLE [dbo].[Holders]
ADD CONSTRAINT [PK_Holders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HolderTools'
ALTER TABLE [dbo].[HolderTools]
ADD CONSTRAINT [PK_HolderTools]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MachineGroups'
ALTER TABLE [dbo].[MachineGroups]
ADD CONSTRAINT [PK_MachineGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Methods'
ALTER TABLE [dbo].[Methods]
ADD CONSTRAINT [PK_Methods]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Operations'
ALTER TABLE [dbo].[Operations]
ADD CONSTRAINT [PK_Operations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OperationTools'
ALTER TABLE [dbo].[OperationTools]
ADD CONSTRAINT [PK_OperationTools]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Parts'
ALTER TABLE [dbo].[Parts]
ADD CONSTRAINT [PK_Parts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PartVersions'
ALTER TABLE [dbo].[PartVersions]
ADD CONSTRAINT [PK_PartVersions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ToolGroups'
ALTER TABLE [dbo].[ToolGroups]
ADD CONSTRAINT [PK_ToolGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tools'
ALTER TABLE [dbo].[Tools]
ADD CONSTRAINT [PK_Tools]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerId] in table 'Parts'
ALTER TABLE [dbo].[Parts]
ADD CONSTRAINT [FK_Parts_Customers]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Parts_Customers'
CREATE INDEX [IX_FK_Parts_Customers]
ON [dbo].[Parts]
    ([CustomerId]);
GO

-- Creating foreign key on [OperationId] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [FK_Documents_Operations]
    FOREIGN KEY ([OperationId])
    REFERENCES [dbo].[Operations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Documents_Operations'
CREATE INDEX [IX_FK_Documents_Operations]
ON [dbo].[Documents]
    ([OperationId]);
GO

-- Creating foreign key on [PartId] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [FK_Documents_Parts]
    FOREIGN KEY ([PartId])
    REFERENCES [dbo].[Parts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Documents_Parts'
CREATE INDEX [IX_FK_Documents_Parts]
ON [dbo].[Documents]
    ([PartId]);
GO

-- Creating foreign key on [PartVersionId] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [FK_Documents_PartVersions]
    FOREIGN KEY ([PartVersionId])
    REFERENCES [dbo].[PartVersions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Documents_PartVersions'
CREATE INDEX [IX_FK_Documents_PartVersions]
ON [dbo].[Documents]
    ([PartVersionId]);
GO

-- Creating foreign key on [EmployeeGroupId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employees_EmployeeGroups]
    FOREIGN KEY ([EmployeeGroupId])
    REFERENCES [dbo].[EmployeeGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Employees_EmployeeGroups'
CREATE INDEX [IX_FK_Employees_EmployeeGroups]
ON [dbo].[Employees]
    ([EmployeeGroupId]);
GO

-- Creating foreign key on [LastViewedPartId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employees_Parts]
    FOREIGN KEY ([LastViewedPartId])
    REFERENCES [dbo].[Parts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Employees_Parts'
CREATE INDEX [IX_FK_Employees_Parts]
ON [dbo].[Employees]
    ([LastViewedPartId]);
GO

-- Creating foreign key on [HolderGroupId] in table 'Holders'
ALTER TABLE [dbo].[Holders]
ADD CONSTRAINT [FK_Holders_HolderGroups]
    FOREIGN KEY ([HolderGroupId])
    REFERENCES [dbo].[HolderGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Holders_HolderGroups'
CREATE INDEX [IX_FK_Holders_HolderGroups]
ON [dbo].[Holders]
    ([HolderGroupId]);
GO

-- Creating foreign key on [HolderId] in table 'HolderTools'
ALTER TABLE [dbo].[HolderTools]
ADD CONSTRAINT [FK_HolderTools_Holders]
    FOREIGN KEY ([HolderId])
    REFERENCES [dbo].[Holders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HolderTools_Holders'
CREATE INDEX [IX_FK_HolderTools_Holders]
ON [dbo].[HolderTools]
    ([HolderId]);
GO

-- Creating foreign key on [ToolId] in table 'HolderTools'
ALTER TABLE [dbo].[HolderTools]
ADD CONSTRAINT [FK_HolderTools_Tools]
    FOREIGN KEY ([ToolId])
    REFERENCES [dbo].[Tools]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HolderTools_Tools'
CREATE INDEX [IX_FK_HolderTools_Tools]
ON [dbo].[HolderTools]
    ([ToolId]);
GO

-- Creating foreign key on [MachineGroupId] in table 'Operations'
ALTER TABLE [dbo].[Operations]
ADD CONSTRAINT [FK_Operations_MachineGroups]
    FOREIGN KEY ([MachineGroupId])
    REFERENCES [dbo].[MachineGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Operations_MachineGroups'
CREATE INDEX [IX_FK_Operations_MachineGroups]
ON [dbo].[Operations]
    ([MachineGroupId]);
GO

-- Creating foreign key on [PartVersionId] in table 'Methods'
ALTER TABLE [dbo].[Methods]
ADD CONSTRAINT [FK_Methods_PartVersions]
    FOREIGN KEY ([PartVersionId])
    REFERENCES [dbo].[PartVersions]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Methods_PartVersions'
CREATE INDEX [IX_FK_Methods_PartVersions]
ON [dbo].[Methods]
    ([PartVersionId]);
GO

-- Creating foreign key on [MethodId] in table 'Operations'
ALTER TABLE [dbo].[Operations]
ADD CONSTRAINT [FK_Operations_PartVersions]
    FOREIGN KEY ([MethodId])
    REFERENCES [dbo].[Methods]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Operations_PartVersions'
CREATE INDEX [IX_FK_Operations_PartVersions]
ON [dbo].[Operations]
    ([MethodId]);
GO

-- Creating foreign key on [OperationId] in table 'OperationTools'
ALTER TABLE [dbo].[OperationTools]
ADD CONSTRAINT [FK_OperationTools_Operations]
    FOREIGN KEY ([OperationId])
    REFERENCES [dbo].[Operations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OperationTools_Operations'
CREATE INDEX [IX_FK_OperationTools_Operations]
ON [dbo].[OperationTools]
    ([OperationId]);
GO

-- Creating foreign key on [ToolId] in table 'OperationTools'
ALTER TABLE [dbo].[OperationTools]
ADD CONSTRAINT [FK_OperationTools_Tools]
    FOREIGN KEY ([ToolId])
    REFERENCES [dbo].[Tools]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OperationTools_Tools'
CREATE INDEX [IX_FK_OperationTools_Tools]
ON [dbo].[OperationTools]
    ([ToolId]);
GO

-- Creating foreign key on [PartId] in table 'PartVersions'
ALTER TABLE [dbo].[PartVersions]
ADD CONSTRAINT [FK_PartVersions_Parts]
    FOREIGN KEY ([PartId])
    REFERENCES [dbo].[Parts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PartVersions_Parts'
CREATE INDEX [IX_FK_PartVersions_Parts]
ON [dbo].[PartVersions]
    ([PartId]);
GO

-- Creating foreign key on [ToolGroupId] in table 'Tools'
ALTER TABLE [dbo].[Tools]
ADD CONSTRAINT [FK_Tools_ToolGroups]
    FOREIGN KEY ([ToolGroupId])
    REFERENCES [dbo].[ToolGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Tools_ToolGroups'
CREATE INDEX [IX_FK_Tools_ToolGroups]
ON [dbo].[Tools]
    ([ToolGroupId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------