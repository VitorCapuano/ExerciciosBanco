CREATE TABLE [dbo].[Projeto]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [nome] VARCHAR(150) NOT NULL, 
    [descricao] VARCHAR(250) NOT NULL, 
    [DataInicio] DATETIME NOT NULL, 
    [DataTermino] DATETIME NULL, 
    [Entregue] BIT NOT NULL, 
    CONSTRAINT [FK_Projeto_Grupo] FOREIGN KEY ([Id]) REFERENCES [Grupo]([Id])
	--clicar com o botao direito no foreig keys e adicionar chave estrangeira, depois editar no constrain
)
