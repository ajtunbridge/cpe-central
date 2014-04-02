
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/02/2014 21:40:28
-- Generated from EDMX file: S:\Adam\Documents\GitHub\cpe-central\CPECentral\CPECentral.Data.EF5\CPECentralModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CPECentral];
GO
IF SCHEMA_ID(N'cpe') IS NULL EXECUTE(N'CREATE SCHEMA [cpe]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Parts_Customers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Parts] DROP CONSTRAINT [FK_Parts_Customers];
GO
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
IF OBJECT_ID(N'[dbo].[FK_Holders_HolderGroups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Holders] DROP CONSTRAINT [FK_Holders_HolderGroups];
GO
IF OBJECT_ID(N'[dbo].[FK_HolderTools_Holders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HolderTools] DROP CONSTRAINT [FK_HolderTools_Holders];
GO
IF OBJECT_ID(N'[dbo].[FK_OperationTools_Holders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OperationTools] DROP CONSTRAINT [FK_OperationTools_Holders];
GO
IF OBJECT_ID(N'[dbo].[FK_HolderTools_Tools]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HolderTools] DROP CONSTRAINT [FK_HolderTools_Tools];
GO
IF OBJECT_ID(N'[dbo].[FK_Operations_MachineGroups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operations] DROP CONSTRAINT [FK_Operations_MachineGroups];
GO
IF OBJECT_ID(N'[dbo].[FK_Methods_PartVersions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Methods] DROP CONSTRAINT [FK_Methods_PartVersions];
GO
IF OBJECT_ID(N'[dbo].[FK_Operations_Methods]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operations] DROP CONSTRAINT [FK_Operations_Methods];
GO
IF OBJECT_ID(N'[dbo].[FK_OperationTools_Operations]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OperationTools] DROP CONSTRAINT [FK_OperationTools_Operations];
GO
IF OBJECT_ID(N'[dbo].[FK_OperationTools_Tools]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OperationTools] DROP CONSTRAINT [FK_OperationTools_Tools];
GO
IF OBJECT_ID(N'[dbo].[FK_PartVersions_Parts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PartVersions] DROP CONSTRAINT [FK_PartVersions_Parts];
GO
IF OBJECT_ID(N'[dbo].[FK_ToolGroups_ToolGroups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ToolGroups] DROP CONSTRAINT [FK_ToolGroups_ToolGroups];
GO
IF OBJECT_ID(N'[dbo].[FK_Tools_ToolGroups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tools] DROP CONSTRAINT [FK_Tools_ToolGroups];
GO
IF OBJECT_ID(N'[dbo].[FK_TricornTools_Tools]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TricornTools] DROP CONSTRAINT [FK_TricornTools_Tools];
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
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TricornTools]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TricornTools];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [cpe].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [ModifiedBy] int  NOT NULL,
    [TricornReference] int  NULL
);
GO

-- Creating table 'Documents'
CREATE TABLE [cpe].[Documents] (
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
CREATE TABLE [cpe].[EmployeeGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(30)  NOT NULL,
    [Permissions] int  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [cpe].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] varchar(30)  NOT NULL,
    [LastName] varchar(30)  NOT NULL,
    [UserName] varchar(30)  NOT NULL,
    [Password] char(88)  NOT NULL,
    [Salt] char(24)  NOT NULL,
    [EmployeeGroupId] int  NOT NULL,
    [LastViewedPartId] int  NULL,
    [PreferredMachineGroup] int  NULL
);
GO

-- Creating table 'HolderGroups'
CREATE TABLE [cpe].[HolderGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(30)  NOT NULL
);
GO

-- Creating table 'Holders'
CREATE TABLE [cpe].[Holders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [HolderGroupId] int  NOT NULL
);
GO

-- Creating table 'HolderTools'
CREATE TABLE [cpe].[HolderTools] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HolderId] int  NOT NULL,
    [ToolId] int  NOT NULL
);
GO

-- Creating table 'MachineGroups'
CREATE TABLE [cpe].[MachineGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(30)  NOT NULL,
    [NextNumber] int  NOT NULL
);
GO

-- Creating table 'Methods'
CREATE TABLE [cpe].[Methods] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(255)  NOT NULL,
    [IsPreferred] bit  NOT NULL,
    [PartVersionId] int  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [ModifiedBy] int  NOT NULL
);
GO

-- Creating table 'Operations'
CREATE TABLE [cpe].[Operations] (
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
CREATE TABLE [cpe].[OperationTools] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Position] int  NOT NULL,
    [Offset] int  NOT NULL,
    [UseOnePer] int  NOT NULL,
    [Notes] varchar(255)  NULL,
    [OperationId] int  NOT NULL,
    [HolderId] int  NULL,
    [ToolId] int  NOT NULL
);
GO

-- Creating table 'Parts'
CREATE TABLE [cpe].[Parts] (
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
CREATE TABLE [cpe].[PartVersions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [VersionNumber] varchar(10)  NOT NULL,
    [PartId] int  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [ModifiedBy] int  NOT NULL
);
GO

-- Creating table 'ToolGroups'
CREATE TABLE [cpe].[ToolGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(30)  NOT NULL,
    [ParentGroupId] int  NULL
);
GO

-- Creating table 'Tools'
CREATE TABLE [cpe].[Tools] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(50)  NOT NULL,
    [ToolGroupId] int  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [cpe].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TricornTools'
CREATE TABLE [cpe].[TricornTools] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ToolId] int  NOT NULL,
    [TricornReference] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [cpe].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Documents'
ALTER TABLE [cpe].[Documents]
ADD CONSTRAINT [PK_Documents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmployeeGroups'
ALTER TABLE [cpe].[EmployeeGroups]
ADD CONSTRAINT [PK_EmployeeGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [cpe].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HolderGroups'
ALTER TABLE [cpe].[HolderGroups]
ADD CONSTRAINT [PK_HolderGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Holders'
ALTER TABLE [cpe].[Holders]
ADD CONSTRAINT [PK_Holders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HolderTools'
ALTER TABLE [cpe].[HolderTools]
ADD CONSTRAINT [PK_HolderTools]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MachineGroups'
ALTER TABLE [cpe].[MachineGroups]
ADD CONSTRAINT [PK_MachineGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Methods'
ALTER TABLE [cpe].[Methods]
ADD CONSTRAINT [PK_Methods]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Operations'
ALTER TABLE [cpe].[Operations]
ADD CONSTRAINT [PK_Operations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OperationTools'
ALTER TABLE [cpe].[OperationTools]
ADD CONSTRAINT [PK_OperationTools]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Parts'
ALTER TABLE [cpe].[Parts]
ADD CONSTRAINT [PK_Parts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PartVersions'
ALTER TABLE [cpe].[PartVersions]
ADD CONSTRAINT [PK_PartVersions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ToolGroups'
ALTER TABLE [cpe].[ToolGroups]
ADD CONSTRAINT [PK_ToolGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tools'
ALTER TABLE [cpe].[Tools]
ADD CONSTRAINT [PK_Tools]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [cpe].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'TricornTools'
ALTER TABLE [cpe].[TricornTools]
ADD CONSTRAINT [PK_TricornTools]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerId] in table 'Parts'
ALTER TABLE [cpe].[Parts]
ADD CONSTRAINT [FK_Parts_Customers]
    FOREIGN KEY ([CustomerId])
    REFERENCES [cpe].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Parts_Customers'
CREATE INDEX [IX_FK_Parts_Customers]
ON [cpe].[Parts]
    ([CustomerId]);
GO

-- Creating foreign key on [OperationId] in table 'Documents'
ALTER TABLE [cpe].[Documents]
ADD CONSTRAINT [FK_Documents_Operations]
    FOREIGN KEY ([OperationId])
    REFERENCES [cpe].[Operations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Documents_Operations'
CREATE INDEX [IX_FK_Documents_Operations]
ON [cpe].[Documents]
    ([OperationId]);
GO

-- Creating foreign key on [PartId] in table 'Documents'
ALTER TABLE [cpe].[Documents]
ADD CONSTRAINT [FK_Documents_Parts]
    FOREIGN KEY ([PartId])
    REFERENCES [cpe].[Parts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Documents_Parts'
CREATE INDEX [IX_FK_Documents_Parts]
ON [cpe].[Documents]
    ([PartId]);
GO

-- Creating foreign key on [PartVersionId] in table 'Documents'
ALTER TABLE [cpe].[Documents]
ADD CONSTRAINT [FK_Documents_PartVersions]
    FOREIGN KEY ([PartVersionId])
    REFERENCES [cpe].[PartVersions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Documents_PartVersions'
CREATE INDEX [IX_FK_Documents_PartVersions]
ON [cpe].[Documents]
    ([PartVersionId]);
GO

-- Creating foreign key on [EmployeeGroupId] in table 'Employees'
ALTER TABLE [cpe].[Employees]
ADD CONSTRAINT [FK_Employees_EmployeeGroups]
    FOREIGN KEY ([EmployeeGroupId])
    REFERENCES [cpe].[EmployeeGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Employees_EmployeeGroups'
CREATE INDEX [IX_FK_Employees_EmployeeGroups]
ON [cpe].[Employees]
    ([EmployeeGroupId]);
GO

-- Creating foreign key on [HolderGroupId] in table 'Holders'
ALTER TABLE [cpe].[Holders]
ADD CONSTRAINT [FK_Holders_HolderGroups]
    FOREIGN KEY ([HolderGroupId])
    REFERENCES [cpe].[HolderGroups]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Holders_HolderGroups'
CREATE INDEX [IX_FK_Holders_HolderGroups]
ON [cpe].[Holders]
    ([HolderGroupId]);
GO

-- Creating foreign key on [HolderId] in table 'HolderTools'
ALTER TABLE [cpe].[HolderTools]
ADD CONSTRAINT [FK_HolderTools_Holders]
    FOREIGN KEY ([HolderId])
    REFERENCES [cpe].[Holders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HolderTools_Holders'
CREATE INDEX [IX_FK_HolderTools_Holders]
ON [cpe].[HolderTools]
    ([HolderId]);
GO

-- Creating foreign key on [HolderId] in table 'OperationTools'
ALTER TABLE [cpe].[OperationTools]
ADD CONSTRAINT [FK_OperationTools_Holders]
    FOREIGN KEY ([HolderId])
    REFERENCES [cpe].[Holders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OperationTools_Holders'
CREATE INDEX [IX_FK_OperationTools_Holders]
ON [cpe].[OperationTools]
    ([HolderId]);
GO

-- Creating foreign key on [ToolId] in table 'HolderTools'
ALTER TABLE [cpe].[HolderTools]
ADD CONSTRAINT [FK_HolderTools_Tools]
    FOREIGN KEY ([ToolId])
    REFERENCES [cpe].[Tools]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HolderTools_Tools'
CREATE INDEX [IX_FK_HolderTools_Tools]
ON [cpe].[HolderTools]
    ([ToolId]);
GO

-- Creating foreign key on [MachineGroupId] in table 'Operations'
ALTER TABLE [cpe].[Operations]
ADD CONSTRAINT [FK_Operations_MachineGroups]
    FOREIGN KEY ([MachineGroupId])
    REFERENCES [cpe].[MachineGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Operations_MachineGroups'
CREATE INDEX [IX_FK_Operations_MachineGroups]
ON [cpe].[Operations]
    ([MachineGroupId]);
GO

-- Creating foreign key on [PartVersionId] in table 'Methods'
ALTER TABLE [cpe].[Methods]
ADD CONSTRAINT [FK_Methods_PartVersions]
    FOREIGN KEY ([PartVersionId])
    REFERENCES [cpe].[PartVersions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Methods_PartVersions'
CREATE INDEX [IX_FK_Methods_PartVersions]
ON [cpe].[Methods]
    ([PartVersionId]);
GO

-- Creating foreign key on [MethodId] in table 'Operations'
ALTER TABLE [cpe].[Operations]
ADD CONSTRAINT [FK_Operations_Methods]
    FOREIGN KEY ([MethodId])
    REFERENCES [cpe].[Methods]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Operations_Methods'
CREATE INDEX [IX_FK_Operations_Methods]
ON [cpe].[Operations]
    ([MethodId]);
GO

-- Creating foreign key on [OperationId] in table 'OperationTools'
ALTER TABLE [cpe].[OperationTools]
ADD CONSTRAINT [FK_OperationTools_Operations]
    FOREIGN KEY ([OperationId])
    REFERENCES [cpe].[Operations]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OperationTools_Operations'
CREATE INDEX [IX_FK_OperationTools_Operations]
ON [cpe].[OperationTools]
    ([OperationId]);
GO

-- Creating foreign key on [ToolId] in table 'OperationTools'
ALTER TABLE [cpe].[OperationTools]
ADD CONSTRAINT [FK_OperationTools_Tools]
    FOREIGN KEY ([ToolId])
    REFERENCES [cpe].[Tools]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OperationTools_Tools'
CREATE INDEX [IX_FK_OperationTools_Tools]
ON [cpe].[OperationTools]
    ([ToolId]);
GO

-- Creating foreign key on [PartId] in table 'PartVersions'
ALTER TABLE [cpe].[PartVersions]
ADD CONSTRAINT [FK_PartVersions_Parts]
    FOREIGN KEY ([PartId])
    REFERENCES [cpe].[Parts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PartVersions_Parts'
CREATE INDEX [IX_FK_PartVersions_Parts]
ON [cpe].[PartVersions]
    ([PartId]);
GO

-- Creating foreign key on [ParentGroupId] in table 'ToolGroups'
ALTER TABLE [cpe].[ToolGroups]
ADD CONSTRAINT [FK_ToolGroups_ToolGroups]
    FOREIGN KEY ([ParentGroupId])
    REFERENCES [cpe].[ToolGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ToolGroups_ToolGroups'
CREATE INDEX [IX_FK_ToolGroups_ToolGroups]
ON [cpe].[ToolGroups]
    ([ParentGroupId]);
GO

-- Creating foreign key on [ToolGroupId] in table 'Tools'
ALTER TABLE [cpe].[Tools]
ADD CONSTRAINT [FK_Tools_ToolGroups]
    FOREIGN KEY ([ToolGroupId])
    REFERENCES [cpe].[ToolGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Tools_ToolGroups'
CREATE INDEX [IX_FK_Tools_ToolGroups]
ON [cpe].[Tools]
    ([ToolGroupId]);
GO

-- Creating foreign key on [ToolId] in table 'TricornTools'
ALTER TABLE [cpe].[TricornTools]
ADD CONSTRAINT [FK_TricornTools_Tools]
    FOREIGN KEY ([ToolId])
    REFERENCES [cpe].[Tools]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TricornTools_Tools'
CREATE INDEX [IX_FK_TricornTools_Tools]
ON [cpe].[TricornTools]
    ([ToolId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------