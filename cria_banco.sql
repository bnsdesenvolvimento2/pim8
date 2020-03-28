create database tarefas;

create table Data (
	DataID Integer,
	Dia Integer,
	Mes Integer,
	Ano Integer
);

create table Tarefa (
	TarefaID Integer,
	NomeTarefa VARCHAR(40),
	Descricao VARCHAR(200),
	Ano Integer
);

create table Disciplina (
	CodigoDisciplina Integer,
	NomeDisciplina VARCHAR(40)
);
