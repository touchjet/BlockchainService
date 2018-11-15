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
using Newtonsoft.Json;
using Serilog;
using BlockchainService.Abstractions.Models;
using Xunit;
using Xunit.Abstractions;
using BlockchainService.Abstractions;
using Microsoft.Extensions.Configuration;

namespace BlockchainService.BlockCypher.Tests
{
    public class BitcoinServiceTest
    {
        const string BITCOIN_TESTNET_ADDRESS_1 = "miDeyf1ktMmpEDjyLJvvUuTcEB6neRoFVG";
        const string BITCOIN_TESTNET_ADDRESS_2 = "mucvmebRcahcERecA1WsxS4NdeyAja89yF";

        const string LITECOIN_MAINNET_ADDRESS = "LNj2gmiv2EiQMYPFRdFYZQkq24SmUSLBFf";

        const string DOGECOIN_MAINNET_ADDRESS = "DDMwxnPkNseRRDj8k2LgjWSVNxA38Ldi8B";

        IBitcoinServiceFactory factory;

        public BitcoinServiceTest(ITestOutputHelper output)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.TestOutput(output, Serilog.Events.LogEventLevel.Verbose)
                .CreateLogger();
            var config = new ConfigurationBuilder()
                .AddJsonFile("settings.json")
                .Build();
            factory = new BitcoinServiceFactory(config["token"]);
        }

        [Fact]
        public async void TestBitcoin()
        {
            var service = factory.GetService(CoinTypes.Bitcoin, true);

            var blockchain = await service.GetBlockchainInfoAsync();
            Log.Debug($"Block Height: {blockchain.Height}");
            Assert.True(blockchain.Height > 0);

            var addressRecord = await service.GetBalanceAsync(BITCOIN_TESTNET_ADDRESS_1);
            Log.Debug($"Balance: {addressRecord.Balance}");
            Assert.True(addressRecord.Balance > 0);
            Assert.Equal(addressRecord.Address, BITCOIN_TESTNET_ADDRESS_1);

            var trans = await service.GetTransactionsAsync(BITCOIN_TESTNET_ADDRESS_1);
            var count = trans.Count();
            Log.Debug($"Number of Transactions: {count}");
            Assert.True(count > 0);
            Assert.Contains(trans, t => t.Value > 0);

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
        public async void TestLitecoin()
        {
            var service = factory.GetService(CoinTypes.Litecoin, false);

            var blockchain = await service.GetBlockchainInfoAsync();
            Log.Debug($"Block Height: {blockchain.Height}");
            Assert.True(blockchain.Height > 0);

            var addressRecord = await service.GetBalanceAsync(LITECOIN_MAINNET_ADDRESS);
            Log.Debug($"Balance: {addressRecord.Balance}");
            Assert.True(addressRecord.Balance >= 0);
            Assert.Equal(addressRecord.Address, LITECOIN_MAINNET_ADDRESS);

            var trans = await service.GetTransactionsAsync(LITECOIN_MAINNET_ADDRESS);
            var count = trans.Count();
            Log.Debug($"Number of Transactions: {count}");
            Assert.True(count > 0);
            Assert.Contains(trans, t => t.Value > 0);
        }

        [Fact]
        public async void TestDogecoin()
        {
            var service = factory.GetService(CoinTypes.Dogecoin, false);

            var blockchain = await service.GetBlockchainInfoAsync();
            Log.Debug($"Block Height: {blockchain.Height}");
            Assert.True(blockchain.Height > 0);

            var addressRecord = await service.GetBalanceAsync(DOGECOIN_MAINNET_ADDRESS);
            Log.Debug($"Balance: {addressRecord.Balance}");
            Assert.True(addressRecord.Balance >= 0);
            Assert.Equal(addressRecord.Address, DOGECOIN_MAINNET_ADDRESS);

            var trans = await service.GetTransactionsAsync(DOGECOIN_MAINNET_ADDRESS);
            var count = trans.Count();
            Log.Debug($"Number of Transactions: {count}");
            Assert.True(count > 0);
            Assert.Contains(trans, t => t.Value > 0);
        }
    }
}
