#!/bin/bash

set -exuo pipefail

if [ ${NETWORK:-main} = 'testnet' ]; then
  exec /geth --testnet --rpcaddr 0.0.0.0
elif [ ${NETWORK:=main} = 'rinkeby' ]; then
  exec /geth --rinkeby --rpcaddr 0.0.0.0
else
  exec /geth --rpcaddr 0.0.0.0
fi