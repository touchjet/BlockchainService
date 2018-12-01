#!/bin/bash

set -exuo pipefail

TAG=${1:-latest}

docker build --no-cache -t touchjet/btcnode:${TAG} .
docker push touchjet/btcnode:${TAG}
