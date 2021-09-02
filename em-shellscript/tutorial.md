## Docker

```bash
docker container run -d --name dynamoDB -p 7000:8000 amazon/dynamodb-local

# Ou via docker-compose

docker-compose up -d

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
aws dynamodb --endpoint-url=http://localhost:7000 \
    create-table \
        --table-name Music \
        --attribute-definitions \
            AttributeName=Artist,AttributeType=S \
            AttributeName=SongTitle,AttributeType=S \
        --key-schema \
            AttributeName=Artist,KeyType=HASH \
            AttributeName=SongTitle,KeyType=RANGE \
    --provisioned-throughput \
            ReadCapacityUnits=10,WriteCapacityUnits=5
```

retorno

```json
{
    "TableDescription": {
        "AttributeDefinitions": [
            {
                "AttributeName": "Artist",
                "AttributeType": "S"
            },
            {
                "AttributeName": "SongTitle",
                "AttributeType": "S"
            }
        ],
        "TableName": "Music",
        "KeySchema": [
            {
                "AttributeName": "Artist",
                "KeyType": "HASH"
            },
            {
                "AttributeName": "SongTitle",
                "KeyType": "RANGE"
            }
        ],
        "TableStatus": "ACTIVE",
        "CreationDateTime": "2021-08-31T18:34:14.445000-03:00",
        "ProvisionedThroughput": {
            "LastIncreaseDateTime": "1969-12-31T21:00:00-03:00",
            "LastDecreaseDateTime": "1969-12-31T21:00:00-03:00",
            "NumberOfDecreasesToday": 0,
            "ReadCapacityUnits": 10,
            "WriteCapacityUnits": 5
        },
        "TableSizeBytes": 0,
        "ItemCount": 0,
        "TableArn": "arn:aws:dynamodb:ddblocal:000000000000:table/Music"
    }
}

```
