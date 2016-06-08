
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/06/2016 16:18:14
-- Generated from EDMX file: C:\Users\Felipe Hermida\documents\visual studio 2015\Projects\FrangoFone\FrangoFone.Repository\FrangoFone.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FRANGOFONE];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClienteEndereco]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EnderecoSet] DROP CONSTRAINT [FK_ClienteEndereco];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteContato]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContatoSet] DROP CONSTRAINT [FK_ClienteContato];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoContatoContato]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContatoSet] DROP CONSTRAINT [FK_TipoContatoContato];
GO
IF OBJECT_ID(N'[dbo].[FK_ProdutoProdutoPreco]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProdutoPrecoSet] DROP CONSTRAINT [FK_ProdutoProdutoPreco];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoriaProduto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProdutoSet] DROP CONSTRAINT [FK_CategoriaProduto];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientePedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PedidoSet] DROP CONSTRAINT [FK_ClientePedido];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoEntregaPedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PedidoSet] DROP CONSTRAINT [FK_TipoEntregaPedido];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoPagamentoPedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PedidoSet] DROP CONSTRAINT [FK_TipoPagamentoPedido];
GO
IF OBJECT_ID(N'[dbo].[FK_PedidoEndereco]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PedidoSet] DROP CONSTRAINT [FK_PedidoEndereco];
GO
IF OBJECT_ID(N'[dbo].[FK_PedidoItemPedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItemPedidoSet] DROP CONSTRAINT [FK_PedidoItemPedido];
GO
IF OBJECT_ID(N'[dbo].[FK_ProdutoItemPedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItemPedidoSet] DROP CONSTRAINT [FK_ProdutoItemPedido];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioPermissao]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioSet] DROP CONSTRAINT [FK_UsuarioPermissao];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioCliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClienteSet] DROP CONSTRAINT [FK_UsuarioCliente];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ClienteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClienteSet];
GO
IF OBJECT_ID(N'[dbo].[EnderecoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EnderecoSet];
GO
IF OBJECT_ID(N'[dbo].[ContatoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContatoSet];
GO
IF OBJECT_ID(N'[dbo].[TipoContatoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoContatoSet];
GO
IF OBJECT_ID(N'[dbo].[ProdutoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProdutoSet];
GO
IF OBJECT_ID(N'[dbo].[ProdutoPrecoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProdutoPrecoSet];
GO
IF OBJECT_ID(N'[dbo].[CategoriaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoriaSet];
GO
IF OBJECT_ID(N'[dbo].[PedidoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PedidoSet];
GO
IF OBJECT_ID(N'[dbo].[TipoEntregaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoEntregaSet];
GO
IF OBJECT_ID(N'[dbo].[TipoPagamentoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoPagamentoSet];
GO
IF OBJECT_ID(N'[dbo].[ItemPedidoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ItemPedidoSet];
GO
IF OBJECT_ID(N'[dbo].[UsuarioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioSet];
GO
IF OBJECT_ID(N'[dbo].[PermissaoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PermissaoSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ClienteSet'
CREATE TABLE [dbo].[ClienteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Sobrenone] nvarchar(max)  NOT NULL,
    [CPF] bigint  NOT NULL,
    [DataNascimento] datetime  NULL,
    [DataCadastro] datetime  NOT NULL,
    [Ativo] bit  NOT NULL,
    [UsuarioId] int  NOT NULL
);
GO

-- Creating table 'EnderecoSet'
CREATE TABLE [dbo].[EnderecoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClienteId] int  NOT NULL,
    [Logradouro] nvarchar(max)  NOT NULL,
    [Numero] int  NOT NULL,
    [Complemento] nvarchar(max)  NOT NULL,
    [CEP] int  NOT NULL,
    [Bairro] nvarchar(max)  NOT NULL,
    [Municipio] nvarchar(max)  NOT NULL,
    [Estado] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ContatoSet'
CREATE TABLE [dbo].[ContatoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClienteId] int  NOT NULL,
    [Valor] decimal(18,0)  NOT NULL,
    [TipoContatoId] int  NOT NULL
);
GO

-- Creating table 'TipoContatoSet'
CREATE TABLE [dbo].[TipoContatoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProdutoSet'
CREATE TABLE [dbo].[ProdutoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL,
    [Quantidade] int  NOT NULL,
    [Ativo] bit  NOT NULL,
    [CategoriaId] int  NOT NULL
);
GO

-- Creating table 'ProdutoPrecoSet'
CREATE TABLE [dbo].[ProdutoPrecoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProdutoId] int  NOT NULL,
    [Valor] decimal(18,0)  NOT NULL,
    [InicioVigencia] datetime  NOT NULL,
    [FimVigencia] datetime  NOT NULL
);
GO

-- Creating table 'CategoriaSet'
CREATE TABLE [dbo].[CategoriaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL,
    [Ativa] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PedidoSet'
CREATE TABLE [dbo].[PedidoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClienteId] int  NOT NULL,
    [DataPedido] datetime  NOT NULL,
    [TipoEntregaId] int  NOT NULL,
    [TipoPagamentoId] int  NOT NULL,
    [Endereco_Id] int  NOT NULL
);
GO

-- Creating table 'TipoEntregaSet'
CREATE TABLE [dbo].[TipoEntregaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Ativo] bit  NOT NULL
);
GO

-- Creating table 'TipoPagamentoSet'
CREATE TABLE [dbo].[TipoPagamentoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Ativo] bit  NOT NULL
);
GO

-- Creating table 'ItemPedidoSet'
CREATE TABLE [dbo].[ItemPedidoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PedidoId] int  NOT NULL,
    [ProdutoId] int  NOT NULL,
    [ValorUnitario] decimal(18,0)  NOT NULL,
    [Quantidade] int  NOT NULL
);
GO

-- Creating table 'UsuarioSet'
CREATE TABLE [dbo].[UsuarioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Senha] nvarchar(max)  NOT NULL,
    [Ativo] bit  NOT NULL,
    [DataCadastro] datetime  NOT NULL,
    [Permissao_Id] int  NOT NULL
);
GO

-- Creating table 'PermissaoSet'
CREATE TABLE [dbo].[PermissaoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ClienteSet'
ALTER TABLE [dbo].[ClienteSet]
ADD CONSTRAINT [PK_ClienteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EnderecoSet'
ALTER TABLE [dbo].[EnderecoSet]
ADD CONSTRAINT [PK_EnderecoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContatoSet'
ALTER TABLE [dbo].[ContatoSet]
ADD CONSTRAINT [PK_ContatoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TipoContatoSet'
ALTER TABLE [dbo].[TipoContatoSet]
ADD CONSTRAINT [PK_TipoContatoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProdutoSet'
ALTER TABLE [dbo].[ProdutoSet]
ADD CONSTRAINT [PK_ProdutoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProdutoPrecoSet'
ALTER TABLE [dbo].[ProdutoPrecoSet]
ADD CONSTRAINT [PK_ProdutoPrecoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategoriaSet'
ALTER TABLE [dbo].[CategoriaSet]
ADD CONSTRAINT [PK_CategoriaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PedidoSet'
ALTER TABLE [dbo].[PedidoSet]
ADD CONSTRAINT [PK_PedidoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TipoEntregaSet'
ALTER TABLE [dbo].[TipoEntregaSet]
ADD CONSTRAINT [PK_TipoEntregaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TipoPagamentoSet'
ALTER TABLE [dbo].[TipoPagamentoSet]
ADD CONSTRAINT [PK_TipoPagamentoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ItemPedidoSet'
ALTER TABLE [dbo].[ItemPedidoSet]
ADD CONSTRAINT [PK_ItemPedidoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsuarioSet'
ALTER TABLE [dbo].[UsuarioSet]
ADD CONSTRAINT [PK_UsuarioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PermissaoSet'
ALTER TABLE [dbo].[PermissaoSet]
ADD CONSTRAINT [PK_PermissaoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ClienteId] in table 'EnderecoSet'
ALTER TABLE [dbo].[EnderecoSet]
ADD CONSTRAINT [FK_ClienteEndereco]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[ClienteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteEndereco'
CREATE INDEX [IX_FK_ClienteEndereco]
ON [dbo].[EnderecoSet]
    ([ClienteId]);
GO

-- Creating foreign key on [ClienteId] in table 'ContatoSet'
ALTER TABLE [dbo].[ContatoSet]
ADD CONSTRAINT [FK_ClienteContato]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[ClienteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteContato'
CREATE INDEX [IX_FK_ClienteContato]
ON [dbo].[ContatoSet]
    ([ClienteId]);
GO

-- Creating foreign key on [TipoContatoId] in table 'ContatoSet'
ALTER TABLE [dbo].[ContatoSet]
ADD CONSTRAINT [FK_TipoContatoContato]
    FOREIGN KEY ([TipoContatoId])
    REFERENCES [dbo].[TipoContatoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoContatoContato'
CREATE INDEX [IX_FK_TipoContatoContato]
ON [dbo].[ContatoSet]
    ([TipoContatoId]);
GO

-- Creating foreign key on [ProdutoId] in table 'ProdutoPrecoSet'
ALTER TABLE [dbo].[ProdutoPrecoSet]
ADD CONSTRAINT [FK_ProdutoProdutoPreco]
    FOREIGN KEY ([ProdutoId])
    REFERENCES [dbo].[ProdutoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProdutoProdutoPreco'
CREATE INDEX [IX_FK_ProdutoProdutoPreco]
ON [dbo].[ProdutoPrecoSet]
    ([ProdutoId]);
GO

-- Creating foreign key on [CategoriaId] in table 'ProdutoSet'
ALTER TABLE [dbo].[ProdutoSet]
ADD CONSTRAINT [FK_CategoriaProduto]
    FOREIGN KEY ([CategoriaId])
    REFERENCES [dbo].[CategoriaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaProduto'
CREATE INDEX [IX_FK_CategoriaProduto]
ON [dbo].[ProdutoSet]
    ([CategoriaId]);
GO

-- Creating foreign key on [ClienteId] in table 'PedidoSet'
ALTER TABLE [dbo].[PedidoSet]
ADD CONSTRAINT [FK_ClientePedido]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[ClienteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientePedido'
CREATE INDEX [IX_FK_ClientePedido]
ON [dbo].[PedidoSet]
    ([ClienteId]);
GO

-- Creating foreign key on [TipoEntregaId] in table 'PedidoSet'
ALTER TABLE [dbo].[PedidoSet]
ADD CONSTRAINT [FK_TipoEntregaPedido]
    FOREIGN KEY ([TipoEntregaId])
    REFERENCES [dbo].[TipoEntregaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoEntregaPedido'
CREATE INDEX [IX_FK_TipoEntregaPedido]
ON [dbo].[PedidoSet]
    ([TipoEntregaId]);
GO

-- Creating foreign key on [TipoPagamentoId] in table 'PedidoSet'
ALTER TABLE [dbo].[PedidoSet]
ADD CONSTRAINT [FK_TipoPagamentoPedido]
    FOREIGN KEY ([TipoPagamentoId])
    REFERENCES [dbo].[TipoPagamentoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoPagamentoPedido'
CREATE INDEX [IX_FK_TipoPagamentoPedido]
ON [dbo].[PedidoSet]
    ([TipoPagamentoId]);
GO

-- Creating foreign key on [Endereco_Id] in table 'PedidoSet'
ALTER TABLE [dbo].[PedidoSet]
ADD CONSTRAINT [FK_PedidoEndereco]
    FOREIGN KEY ([Endereco_Id])
    REFERENCES [dbo].[EnderecoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedidoEndereco'
CREATE INDEX [IX_FK_PedidoEndereco]
ON [dbo].[PedidoSet]
    ([Endereco_Id]);
GO

-- Creating foreign key on [PedidoId] in table 'ItemPedidoSet'
ALTER TABLE [dbo].[ItemPedidoSet]
ADD CONSTRAINT [FK_PedidoItemPedido]
    FOREIGN KEY ([PedidoId])
    REFERENCES [dbo].[PedidoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedidoItemPedido'
CREATE INDEX [IX_FK_PedidoItemPedido]
ON [dbo].[ItemPedidoSet]
    ([PedidoId]);
GO

-- Creating foreign key on [ProdutoId] in table 'ItemPedidoSet'
ALTER TABLE [dbo].[ItemPedidoSet]
ADD CONSTRAINT [FK_ProdutoItemPedido]
    FOREIGN KEY ([ProdutoId])
    REFERENCES [dbo].[ProdutoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProdutoItemPedido'
CREATE INDEX [IX_FK_ProdutoItemPedido]
ON [dbo].[ItemPedidoSet]
    ([ProdutoId]);
GO

-- Creating foreign key on [Permissao_Id] in table 'UsuarioSet'
ALTER TABLE [dbo].[UsuarioSet]
ADD CONSTRAINT [FK_UsuarioPermissao]
    FOREIGN KEY ([Permissao_Id])
    REFERENCES [dbo].[PermissaoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioPermissao'
CREATE INDEX [IX_FK_UsuarioPermissao]
ON [dbo].[UsuarioSet]
    ([Permissao_Id]);
GO

-- Creating foreign key on [UsuarioId] in table 'ClienteSet'
ALTER TABLE [dbo].[ClienteSet]
ADD CONSTRAINT [FK_UsuarioCliente]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[UsuarioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioCliente'
CREATE INDEX [IX_FK_UsuarioCliente]
ON [dbo].[ClienteSet]
    ([UsuarioId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------