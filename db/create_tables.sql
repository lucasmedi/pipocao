-- CREATES

use psa_tf;

create table Usuarios (
	id int identity(1, 1) primary key,
	nome nvarchar(255) not null,
	email nvarchar(255) not null
);

create table Filmes (
	id int identity(1, 1) primary key,
	TmdbId int null,
	UsuarioId int not null,
	titulo nvarchar(255) not null,
	descricao nvarchar(4000) null,
	urlImagem nvarchar(255) null,
	urlTrailer nvarchar(255) null,
	tipoMidia int not null
);	

create table Comentarios (
	id int identity(1, 1) primary key,
	FilmeId int not null,
	UsuarioId int not null,
	data datetime not null,
	gostei bit default 0 not null,
	texto nvarchar(4000) not null,
	nota int not null
);

alter table Filmes add constraint fk_filmes_usuarios foreign key (UsuarioId) references Usuarios(id);

alter table Comentarios add constraint fk_comentarios_filmes foreign key (FilmeId) references Filmes(id);
alter table Comentarios add constraint fk_comentarios_usuarios foreign key (UsuarioId) references Usuarios(id);

alter table Filmes add constraint ck_filmes_tipoMidia_range check (tipoMidia >= 1 AND tipoMidia <= 2);
alter table Comentarios add constraint ck_comentarios_nota_range check (nota >= 1 AND nota <= 5);