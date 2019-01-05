/*
 * Copyright (C) 2018 Touchjet Limited.
 * 
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockchainService.Abstractions;
using BlockchainService.Abstractions.Models;
using Newtonsoft.Json;
using Serilog;
using Xunit;

namespace BlockchainService.SharedTests
{
    public abstract class EthereumServiceTestBase
    {
        const string ETHEREUM_MAINNET_ADDRESS = "8252bD64934fea5B77dceB160bEc99B7BC1A5D51";

        protected IEthereumServiceFactory factory;

        [Fact]
        public async Task TestEthereum()
        {
            var service = factory.GetService(CoinTypes.Ethereum, false);

            var blockchain = await service.GetBlockchainInfoAsync();
            Log.Debug($"Block Height: {blockchain.Height}");
            Assert.True(blockchain.Height > 0);

            var addressRecord = await service.GetBalanceAsync(ETHEREUM_MAINNET_ADDRESS);
            Log.Debug($"Balance: {addressRecord.Balance}");
            Assert.True(addressRecord.Balance > 0);
            Assert.Equal(addressRecord.Address.ToLower(), ETHEREUM_MAINNET_ADDRESS.ToLower());

            var trans = await service.GetTransactionsAsync(ETHEREUM_MAINNET_ADDRESS, 0, blockchain.Height);
            var count = trans.Count();
            Log.Debug($"Number of Transactions: {count}");
            Assert.True(count > 0);
            Assert.Contains(trans, t => t.Value > 0);

            var tx = new EthereumTX()
            {
                Inputs = new List<EthereumTXInput> { new EthereumTXInput { Addresses = new List<string> { ETHEREUM_MAINNET_ADDRESS } } },
                Outputs = new List<EthereumTXOutput> { new EthereumTXOutput { Addresses = new List<string> { ETHEREUM_MAINNET_ADDRESS }, Value = 1000 } }
            };
            var txResult = await service.CreateTransactionAsync(tx);
            foreach (var i in txResult.Tx.Inputs)
            {
                Log.Debug($"Input : {JsonConvert.SerializeObject(i)}");
            }
            foreach (var o in txResult.Tx.Outputs)
            {
                Log.Debug($"Output : {JsonConvert.SerializeObject(o)}");
            }
            Assert.Contains(txResult.Tx.Inputs, t => t.Addresses.Any(a => a.Equals(ETHEREUM_MAINNET_ADDRESS.ToLower())));
            Assert.Contains(txResult.Tx.Outputs, t => t.Addresses.Any(a => a.Equals(ETHEREUM_MAINNET_ADDRESS.ToLower())));
        }
    }
}
