

# Sobre

Este projeto é um ToDoList que consiste em um CRUD de Tarefas utilizando autenticação JWT :smile:

# Rotas

## Rotas de Usuário (/User)

 - GET - Retorna os dados do usuário e o token, que tem expiração de 1 hora
	 - Parâmetros
		```
		{
			"Name":"String",
			"Password":"String"
		} 		 
		```
 - POST - Insere um novo usuário
	 - Parâmetros
		```
		{
			"name":"String",
			"password":"String"
		} 		 
		```
## Rotas de Tarefas (/Task)

 - **GET** - Retorna todas as tarefas

 - **POST** - Insere uma nova tarefa
	 - Parâmetros:
		 - Caso não passe o parâmetro "**Concluded**" será cadastrado como false por padrão
		```
		{
			"Description":"String",
			"IdUser": Int,
			"Concluded": Bool
		} 		 
		```
- **PUT** - Edita dados da Tarefa
	 - Parâmetros:
		```
		{
			"Id": Int,
			"IdUser": Int,
			"Description": "String"
		}	 
		```
 - **DELETE** - Exclui uma tarefa
	 - Parâmetros:
		```
		{
			"Id": Int
		} 		 
		```
- **PUT** - Altera a situação da tarefa (/Task/ChangeState)
	 - Parâmetros:
		```
		{
			"Id": Int,
			"Concluded": Bool
		}	 
		```

## Observação

- A Rota do swagger é /swagger/index.html :smile: