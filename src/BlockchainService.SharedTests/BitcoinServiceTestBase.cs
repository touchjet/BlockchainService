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
    public abstract class BitcoinServiceTestBase
    {
        const string BITCOIN_MAIN_ADDRESS_GENESIS = "1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa";

        const string BITCOIN_TESTNET_ADDRESS_1 = "miDeyf1ktMmpEDjyLJvvUuTcEB6neRoFVG";
        const string BITCOIN_TESTNET_ADDRESS_2 = "mucvmebRcahcERecA1WsxS4NdeyAja89yF";

        const string LITECOIN_MAINNET_ADDRESS = "LNj2gmiv2EiQMYPFRdFYZQkq24SmUSLBFf";

        const string DOGECOIN_MAINNET_ADDRESS = "DDMwxnPkNseRRDj8k2LgjWSVNxA38Ldi8B";

        protected IBitcoinServiceFactory factory;

        [Fact]
        public async Task TestBitcoinMain()
        {
            var service = factory.GetService(CoinTypes.Bitcoin, false);

            var blockchain = await service.GetBlockchainInfoAsync();
            Log.Debug($"Block Height: {blockchain.Height}");
            Assert.True(blockchain.Height > 0);

            var addressRecord = await service.GetBalanceAsync(BITCOIN_MAIN_ADDRESS_GENESIS);
            Log.Debug($"Balance: {addressRecord.Balance}");
            Assert.True(addressRecord.Balance >= 1690094937);
            Assert.Equal(addressRecord.Address, BITCOIN_MAIN_ADDRESS_GENESIS);

            var trans = await service.GetTransactionsAsync(BITCOIN_MAIN_ADDRESS_GENESIS, 0, blockchain.Height);
            var count = trans.Count();
            Log.Debug($"Number of Transactions: {count}");
            Assert.True(count > 1460);
            Assert.Contains(trans, t => (t.Value == 800) && (t.BlockHeight == 529532));
        }

        [Fact]
        public async Task TestBitcoinTest()
        {
            var service = factory.GetService(CoinTypes.Bitcoin, true);

            var blockchain = await service.GetBlockchainInfoAsync();
            Log.Debug($"Block Height: {blockchain.Height}");
            Assert.True(blockchain.Height > 0);

            var addressRecord = await service.GetBalanceAsync(BITCOIN_TESTNET_ADDRESS_1);
            Log.Debug($"Balance: {addressRecord.Balance}");
            Assert.True(addressRecord.Balance > 0);
            Assert.Equal(addressRecord.Address, BITCOIN_TESTNET_ADDRESS_1);

            var trans = await service.GetTransactionsAsync(BITCOIN_TESTNET_ADDRESS_1, 0, blockchain.Height);
            var count = trans.Count();
            Assert.True(count > 0);
            Assert.Contains(trans, t => t.Value > 0);
            foreach (var tranHash in trans.Select(t => t.Hash))
            {
                var trx = await service.GetTransactionAsync(tranHash);
                Log.Debug(JsonConvert.SerializeObject(trx));
                Assert.Equal(trx.Hash,tranHash);
                Assert.True(trx.Inputs.Count > 0);
                Assert.True(trx.Outputs.Count > 0);
            }
            var tx = new BitcoinTX()
            {
                Inputs = new List<BitcoinTXInput> { new BitcoinTXInput { Addresses = new List<string> { BITCOIN_TESTNET_ADDRESS_1 } }, new BitcoinTXInput { Addresses = new List<string> { BITCOIN_TESTNET_ADDRESS_2 } } },
                Outputs = new List<BitcoinTXOutput> { new BitcoinTXOutput { Addresses = new List<string> { BITCOIN_TESTNET_ADDRESS_2 }, Value = 1000 } },
                ChangeAddress = BITCOIN_TESTNET_ADDRESS_1
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
            Assert.Contains(txResult.Tx.Inputs, t => t.Addresses.Any(a => a.Equals(BITCOIN_TESTNET_ADDRESS_1)));
            Assert.Contains(txResult.Tx.Outputs, t => t.Addresses.Any(a => a.Equals(BITCOIN_TESTNET_ADDRESS_1)));
        }

        [Fact]
        public async Task TestLitecoin()
        {
            var service = factory.GetService(CoinTypes.Litecoin, false);

            var blockchain = await service.GetBlockchainInfoAsync();
            Log.Debug($"Block Height: {blockchain.Height}");
            Assert.True(blockchain.Height > 0);

            var addressRecord = await service.GetBalanceAsync(LITECOIN_MAINNET_ADDRESS);
            Log.Debug($"Balance: {addressRecord.Balance}");
            Assert.True(addressRecord.Balance >= 0);
            Assert.Equal(addressRecord.Address, LITECOIN_MAINNET_ADDRESS);

            var trans = await service.GetTransactionsAsync(LITECOIN_MAINNET_ADDRESS, 0, blockchain.Height);
            var count = trans.Count();
            Log.Debug($"Number of Transactions: {count}");
            Assert.True(count > 0);
            Assert.Contains(trans, t => t.Value > 0);
        }

        [Fact]
        public async Task TestDogecoin()
        {
            var service = factory.GetService(CoinTypes.Dogecoin, false);

            var blockchain = await service.GetBlockchainInfoAsync();
            Log.Debug($"Block Height: {blockchain.Height}");
            Assert.True(blockchain.Height > 0);

            var addressRecord = await service.GetBalanceAsync(DOGECOIN_MAINNET_ADDRESS);
            Log.Debug($"Balance: {addressRecord.Balance}");
            Assert.True(addressRecord.Balance >= 0);
            Assert.Equal(addressRecord.Address, DOGECOIN_MAINNET_ADDRESS);

            var trans = await service.GetTransactionsAsync(DOGECOIN_MAINNET_ADDRESS, 0, blockchain.Height);
            var count = trans.Count();
            Log.Debug($"Number of Transactions: {count}");
            Assert.True(count > 0);
            Assert.Contains(trans, t => t.Value > 0);
        }
    }
}
