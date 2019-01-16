
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/15/2019 17:09:43
-- Generated from EDMX file: C:\SourceCode_GitKraken\QuanLyQuanBida\Bida\Bida\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CodeFirstDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ChiTietHoaDonBan_HoaDonBan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChiTietHoaDonBan] DROP CONSTRAINT [FK_ChiTietHoaDonBan_HoaDonBan];
GO
IF OBJECT_ID(N'[dbo].[FK_ChiTietHoaDonBan_SanPhams]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChiTietHoaDonBan] DROP CONSTRAINT [FK_ChiTietHoaDonBan_SanPhams];
GO
IF OBJECT_ID(N'[dbo].[FK_HoaDonBan_BanBida]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HoaDonBan] DROP CONSTRAINT [FK_HoaDonBan_BanBida];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[BanBida]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BanBida];
GO
IF OBJECT_ID(N'[dbo].[ChiTietHoaDonBan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChiTietHoaDonBan];
GO
IF OBJECT_ID(N'[dbo].[HoaDonBan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HoaDonBan];
GO
IF OBJECT_ID(N'[dbo].[SanPhams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SanPhams];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [AccountId] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NULL,
    [Password] nvarchar(max)  NULL
);
GO

-- Creating table 'BanBidas'
CREATE TABLE [dbo].[BanBidas] (
    [BanBidaId] int IDENTITY(1,1) NOT NULL,
    [TenBanBida] nvarchar(max)  NULL,
    [TinhTrang] nvarchar(max)  NULL,
    [isDelete] bit  NULL
);
GO

-- Creating table 'ChiTietHoaDonBans'
CREATE TABLE [dbo].[ChiTietHoaDonBans] (
    [ChiTietHoaDonBanId] int IDENTITY(1,1) NOT NULL,
    [IdHoaDonBan] int  NULL,
    [IdSanPham] int  NULL,
    [Soluong] int  NULL,
    [isDelete] bit  NULL
);
GO

-- Creating table 'HoaDonBans'
CREATE TABLE [dbo].[HoaDonBans] (
    [HoaDonBanId] int IDENTITY(1,1) NOT NULL,
    [idBanbida] int  NULL,
    [TongTien] float  NULL,
    [NgayBan] datetime  NULL,
    [TienGio] float  NULL,
    [TinhTrang] nvarchar(50)  NULL,
    [isDelete] bit  NULL
);
GO

-- Creating table 'SanPhams'
CREATE TABLE [dbo].[SanPhams] (
    [SanPhamId] int IDENTITY(1,1) NOT NULL,
    [TenSanPham] nvarchar(max)  NULL,
    [GiaTien] nchar(10)  NULL,
    [Soluong] int  NULL,
    [HinhAnh] nvarchar(max)  NULL,
    [isDelete] bit  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [AccountId] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([AccountId] ASC);
GO

-- Creating primary key on [BanBidaId] in table 'BanBidas'
ALTER TABLE [dbo].[BanBidas]
ADD CONSTRAINT [PK_BanBidas]
    PRIMARY KEY CLUSTERED ([BanBidaId] ASC);
GO

-- Creating primary key on [ChiTietHoaDonBanId] in table 'ChiTietHoaDonBans'
ALTER TABLE [dbo].[ChiTietHoaDonBans]
ADD CONSTRAINT [PK_ChiTietHoaDonBans]
    PRIMARY KEY CLUSTERED ([ChiTietHoaDonBanId] ASC);
GO

-- Creating primary key on [HoaDonBanId] in table 'HoaDonBans'
ALTER TABLE [dbo].[HoaDonBans]
ADD CONSTRAINT [PK_HoaDonBans]
    PRIMARY KEY CLUSTERED ([HoaDonBanId] ASC);
GO

-- Creating primary key on [SanPhamId] in table 'SanPhams'
ALTER TABLE [dbo].[SanPhams]
ADD CONSTRAINT [PK_SanPhams]
    PRIMARY KEY CLUSTERED ([SanPhamId] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idBanbida] in table 'HoaDonBans'
ALTER TABLE [dbo].[HoaDonBans]
ADD CONSTRAINT [FK_HoaDonBan_BanBida]
    FOREIGN KEY ([idBanbida])
    REFERENCES [dbo].[BanBidas]
        ([BanBidaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HoaDonBan_BanBida'
CREATE INDEX [IX_FK_HoaDonBan_BanBida]
ON [dbo].[HoaDonBans]
    ([idBanbida]);
GO

-- Creating foreign key on [IdHoaDonBan] in table 'ChiTietHoaDonBans'
ALTER TABLE [dbo].[ChiTietHoaDonBans]
ADD CONSTRAINT [FK_ChiTietHoaDonBan_HoaDonBan]
    FOREIGN KEY ([IdHoaDonBan])
    REFERENCES [dbo].[HoaDonBans]
        ([HoaDonBanId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChiTietHoaDonBan_HoaDonBan'
CREATE INDEX [IX_FK_ChiTietHoaDonBan_HoaDonBan]
ON [dbo].[ChiTietHoaDonBans]
    ([IdHoaDonBan]);
GO

-- Creating foreign key on [IdSanPham] in table 'ChiTietHoaDonBans'
ALTER TABLE [dbo].[ChiTietHoaDonBans]
ADD CONSTRAINT [FK_ChiTietHoaDonBan_SanPhams]
    FOREIGN KEY ([IdSanPham])
    REFERENCES [dbo].[SanPhams]
        ([SanPhamId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChiTietHoaDonBan_SanPhams'
CREATE INDEX [IX_FK_ChiTietHoaDonBan_SanPhams]
ON [dbo].[ChiTietHoaDonBans]
    ([IdSanPham]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------