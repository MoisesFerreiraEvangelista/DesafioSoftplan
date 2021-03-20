# Desafio Softplan 

## Instruções para execução em ambiente docker

Realize o clone do projeto e no diretorio `DesafioSoftplan` execute a liha de comando abaixo
Para iniciar o serviço
```bash
docker-compose up -d
``` 
Para interromper o serviço
````bash
docker-compose down
````
Acesse as APIs nas seguintes urls

- API 1 http://localhost:8081
- API 2 http://localhost:8080

## Execução dos testes

#### Dependências

Para a execução do teste de integração inicie a API 1

No diretório `DesafioSoftplan\src\API_1` execute o seguinte comando  

````bash
dotnet watch run
````
#### Executando os testes
No diretorio `DesafioSoftplan\src\Testes>` execute a liha de comando abaixo
```bash
dotnet test
``` 
