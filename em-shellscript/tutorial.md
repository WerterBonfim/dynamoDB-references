## Docker

```bash
docker container run -d --name dynamoDB -p 7000:8000 amazon/dynamodb-local
```


## Configurar aws

```bash
aws configure

# AWS Access Key ID:  fakeMyAccessKey
# AWS Secret Access Key ID:  fakeSecretAccessKey
# Default region name:  ap-southeast-2
# Default output format:  
```

listar tabelas
```bash
aws dynamodb list-tables --endpoint-url http://localhost:7000
```

criar tabela
```bash

```
