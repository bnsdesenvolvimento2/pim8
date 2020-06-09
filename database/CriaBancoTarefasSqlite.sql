

-- Cria tabelas do banco de dados Tarefas



CREATE TABLE Tarefa (
	TarefaID INTEGER PRIMARY KEY  AUTOINCREMENT,
	NomeTarefa TEXT NOT NULL,
	Descricao TEXT,
	Disciplina TEXT NOT NULL,
	Data TEXT  NOT NULL
);

