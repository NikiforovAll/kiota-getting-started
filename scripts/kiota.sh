#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" &> /dev/null && pwd )"

cd "$DIR"
cd ..

# NewsSearch.Sdk
kiota search news

kiota download apisguru::microsoft.com:cognitiveservices-NewsSearch \
    --output ./src/NewsSearch.Sdk/OpenApi/NewsSearch.json

kiota show \
    --openapi ./src/NewsSearch.Sdk/OpenApi/NewsSearch.json

kiota info  -l CSharp

kiota generate -l CSharp \
    --log-level trace \
    --output ./src/NewsSearch.Sdk \
    --namespace-name NewsSearch.Sdk \
    --class-name NewsSearchApiClient \
    --include-path "**/trendingtopics" \
    --exclude-backward-compatible \
    --openapi ./src/NewsSearch.Sdk/OpenApi/NewsSearch.json

# App.Sdk

kiota show \
    --openapi ./src/App.Sdk/OpenApi/App.json

kiota generate -l CSharp \
    --log-level trace \
    --output ./src/App.Sdk \
    --namespace-name App.Sdk \
    --class-name AppApiClient \
    --exclude-backward-compatible \
    --openapi ./src/App.Sdk/OpenApi/App.json

# App.Client.Sdk

kiota show \
    --openapi ./src/App.Client.Sdk/OpenApi/App.Client.json

kiota generate -l CSharp \
    --log-level trace \
    --output ./src/App.Client.Sdk \
    --namespace-name App.Client.Sdk \
    --class-name AppClientApiClient \
    --exclude-backward-compatible \
    --openapi ./src/App.Client.Sdk/OpenApi/App.Client.json


# App.Client.Cli

kiota generate -l CLI \
    --log-level trace \
    --output ./src/App.Client.Cli/Client \
    --namespace-name App.Client.Cli \
    --class-name AppClientCli \
    --exclude-backward-compatible \
    --openapi ./src/App.Client.Sdk/OpenApi/App.Client.json
