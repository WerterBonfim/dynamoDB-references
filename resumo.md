

## O que é o Amazon DynamoDB?

É um serviço de banco de dados NoSQL serverless, totalmente
gerenciado, projetado para cargas de trablaho de processamento transasional online (OLTP)

* Esquema flexível
* Estrutura de dados de documentos JSON ou chave-valor
* Oferece suporte à programação orientada a eventos.
* Acessível por meio do console de gerenciamento da AWS, CLI e SDK
* Diponibilidade, durabilidade e escalabilidade integradas
* Escalabilidade horizontal
* Fornece controle de acesso refinado.
* Integraçção com outros serviços da AWS

### Parametros de inicialização local

* -sharedDB: cria um unico arquivo de banco de dados: shared-local-instace.db
caso contratrio myaccesskeyid_region.db 

* -inMemory: não gera nenhum arquivo. todos os dados são escritos na 
memoria. Quando sai do Dynamo os dados são apagados.

* -optimizedDbBeforeStartup: precisa passar o dbPath para do Dynamo 
encontrar o arquivo de banco de dados


### Tipos

Veja a seguir, uma lista completa dos descritores de tipo de dados do DynamoDB:

* S – String
* N – Number
* B – Binary
* BOOL – Boolean
* NULL – Null
* M – Map
* L – List
* SS – String Set
* NS – Number Set
* BS – Binary Set


### 
