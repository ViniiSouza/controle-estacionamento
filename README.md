# Instruções de uso
BackEnd:

Configure o arquivo appsettings.json (ou appsettings.Development.json caso for rodar em modo desenvolvedor) com a sua conexão de banco na linha 9, substituindo 'SEUBANCO' pelo nome do seu banco de dados SqlServer. Crie um banco de dados com o nome ControleEstacionamento.

Abra o terminal de comando na pasta da solução do projeto e execute os seguintes comandos: 

```
cd .\ControleEstacionamento\
dotnet ef --startup-project ../ControleEstacionamentoAPI database update
```
Após concluir a atualização do banco, você pode iniciar o projeto.

Na pasta do frontend, execute os seguintes comandos:
```
npm install
npm run dev
```

O frontend será aberto na página http://localhost:5173/. Basta acessar e começar a usar o projeto.
