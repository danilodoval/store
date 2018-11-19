# STORE

Portal Store Service

## System Requirements

- MongoDb
- SQL Server

## Docker

```
$ cd $WORKSPACE/store
$ docker-compose -f docker-compose.yml up -d
```

## API Guide

The [`api.yaml`](api/src/main/resources/docs/swaggger/v1/api.yaml) is the application Rest APIs documentation source file in
[`SWAGGER`](https://swagger.io/solutions/api-documentation/) format.
After starting the application, the rendered documentation, in `JSON` format, can be found at:

[`http://localhost/api/v1/api-docs`](http://localhost/api/v1/api-docs)