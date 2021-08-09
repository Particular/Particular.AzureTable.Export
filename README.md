# Particular.AzureTable.Export

A tool to export data from NServiceBus.Persistence.AzureTable for import into NServiceBus.Persistence.CosmosDB.

## Running tests locally

All test projects use NUnit. The test projects can be executed using the test runner included with Visual Studio or by using the [`dotnet test` command](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test) from the command line.

The `AcceptanceTests` projects require access to Azure Table Storage and Cosmos DB for tests to pass.

### Azure Storage emulator set up

Although it's deprecated, the tests can use the [Azure Storage Emulator](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator) with no further configuration.

### Using the Azure Storage service

To use a created Azure Storage Account, set an environment variable named `AzureStoragePersistence_ConnectionString` with [a connection string](https://docs.microsoft.com/en-us/azure/storage/common/storage-account-keys-manage?tabs=azure-portal) for your Storage Account.

### Cosmos DB emulator set up

The [local Cosmos DB emulator](https://docs.microsoft.com/en-us/azure/cosmos-db/local-emulator?tabs=cli%2Cssl-netstd21) can be used without configuring a connection string.

The Cosmos DB Emulator, including a data explorer, can be located at https://localhost:8081/_explorer/index.html.

Once the emulator is setup, create a Database named `CosmosDBPersistence`.

### Using the Cosmos DB service

To create a Cosmos DB Core (SQL) Account refer to the [Microsoft instructions](https://docs.microsoft.com/en-us/azure/cosmos-db/how-to-manage-database-account) for managing Accounts.

Once a Cosmos DB account is setup, you can use the [Azure Cosmos explorer](https://docs.microsoft.com/en-us/azure/cosmos-db/data-explorer) to create a Database named `CosmosDBPersistence` which is required by the test projects.

To use the created Cosmos DB Account, set an environment variable named `CosmosDBPersistence_ConnectionString` with [a Cosmos DB connection string](https://docs.microsoft.com/en-us/azure/cosmos-db/secure-access-to-data) for your Account.
