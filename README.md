# GerenciadorTarefa

baixar a imagem 

docker pull mcr.microsoft.com/mssql/server:2019-latest


#criação do container

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=teste#2024" -p 1450:1433  --name sqlserverdb -d mcr.microsoft.com/mssql/server:2019-latest


#gerar a migration inicial

#executar a aplicação para dar geraras tabelas 

#podendo rodar o docker compose

docker-compose up -d --build


#script de inicialização de duas tabelas que nao tem crud



INSERT INTO TBCargo (DescricaoCargo)
VALUES
    ('Gerente'),
    ('Programador'),
    ('Analista de teste');



INSERT INTO TBUsuario (Nome, Email, Senha, Telefone, CargoUsuarioId)
VALUES
    ('Bruna ', 'bruno@teste.com', '123456', '123456789', 1),
    ('Italo', 'italu@example.com', '123456', '987654321', 2),
    ('Maria', 'maria@example.com', '123456', '555555555', 3);


    #nessa ordem 

