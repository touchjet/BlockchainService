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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BlockchainService.Abstractions;
using BlockchainService.Abstractions.Models;
using BlockchainService.BlockCypher.Models;
using Touchjet.NetworkUtils;

namespace BlockchainService.BlockCypher
{
    public class BitcoinService : BaseServiceClient, IBitcoinService
    {
        const string siteUrl = "https://api.blockcypher.com";

        readonly string _token;
        readonly string _network;
        readonly string _coinType;

        public BitcoinService(string token, string coinType, string network) : base(siteUrl, null)
        {
            _token = token;
            _coinType = coinType;
            _network = network;
        }

        public async Task<BitcoinTXSkeleton> BroadcastTransactionAsync(BitcoinTXSkeleton transaction)
        {
            return await Post<BitcoinTXSkeleton, BitcoinTXSkeleton>($"/v1/{_coinType}/{_network}/txs/send?token={_token}", transaction);
        }

        public async Task<BitcoinTXSkeleton> CreateTransactionAsync(BitcoinTX transaction)
        {
            var tx = new BlockCypherBitcoinTX(transaction);
            return await Post<BlockCypherBitcoinTX, BlockCypherBitcoinTXSkeleton>($"/v1/{_coinType}/{_network}/txs/new?token={_token}", tx);
        }

        public async Task<BitcoinAddressRecord> GetBalanceAsync(string address)
        {
            return await Get<BlockCypherBitcoinAddressRecord>($"/v1/{_coinType}/{_network}/addrs/{HttpUtility.UrlEncode(address)}/balance?token={_token}");
        }

        public async Task<BitcoinBlockchain> GetBlockchainInfoAsync()
        {
            return await Get<BlockCypherBitcoinBlockchain>($"/v1/{_coinType}/{_network}");
        }

        public async Task<BitcoinTX> GetTransactionAsync(string hash)
        {
            return await Get<BlockCypherBitcoinTX>($"/v1/{_coinType}/{_network}/txs/{hash}");
        }

        public async Task<IEnumerable<TXRef>> GetTransactionsAsync(string address, Int64 firstBlock, Int64 lastBlock)
        {
            var result = new List<TXRef>();
            var addressRecord = await Get<BlockCypherBitcoinAddressRecord>($"/v1/{_coinType}/{_network}/addrs/{HttpUtility.UrlEncode(address)}?token={_token}&after={firstBlock}&before={lastBlock}");
            if (addressRecord.TxRefs != null)
            {
                result.AddRange(addressRecord.TxRefs);
            }
            if (addressRecord.HasMore)
            {
                Int64 firstBlockIndex = result.Where(tx => tx.BlockHeight > 0).Select(tx => tx.BlockHeight).Min();
                result.AddRange(await GetTransactionsAsync(address, firstBlock, firstBlockIndex));
            }
            return result;
        }

        public async Task<BitcoinTX> PushRawTransactionAsync(BitcoinTXRaw rawTx)
        {
            return await Post<BitcoinTXRaw, BlockCypherBitcoinTX>($"/v1/{_coinType}/{_network}/txs/push?token={_token}", rawTx);
        }
    }
}
