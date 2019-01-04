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
    public class EthereumService : BaseServiceClient, IEthereumService
    {
        const string siteUrl = "https://api.blockcypher.com";

        readonly string _token;
        readonly string _network;
        readonly string _coinType;

        public EthereumService(string token, string coinType, string network) : base(siteUrl, null)
        {
            _token = token;
            _coinType = coinType;
            _network = network;
        }

        public async Task<EthereumTXSkeleton> BroadcastTransactionAsync(EthereumTXSkeleton transaction)
        {
            return await Post<EthereumTXSkeleton, EthereumTXSkeleton>($"/v1/{_coinType}/{_network}/txs/new?token={_token}", transaction);
        }

        public async Task<EthereumContract> CallContractMethodAsync(string address, string method, EthereumContract contract)
        {
            return await Post<EthereumContract, EthereumContract>($"/v1/{_coinType}/{_network}/contracts/{HttpUtility.UrlEncode(address)}/{HttpUtility.UrlEncode(method)}?token={_token}", contract);
        }

        public async Task<IEnumerable<EthereumContract>> CreateContractAsync(EthereumContract contract)
        {
            return await Post<EthereumContract, IEnumerable<EthereumContract>>($"/v1/{_coinType}/{_network}/contracts?token={_token}", contract);
        }

        public async Task<EthereumTXSkeleton> CreateTransactionAsync(EthereumTX transaction)
        {
            var tx = new BlockCypherEthereumTX(transaction);
            return await Post<BlockCypherEthereumTX, BlockCypherEthereumTXSkeleton>($"/v1/{_coinType}/{_network}/txs/new?token={_token}", tx);
        }

        public async Task<EthereumAddressRecord> GetBalanceAsync(string address)
        {
            return await Get<BlockCypherEthereumAddressRecord>($"/v1/{_coinType}/{_network}/addrs/{HttpUtility.UrlEncode(address)}/balance?token={_token}");
        }

        public async Task<EthereumBlockchain> GetBlockchainInfoAsync()
        {
            return await Get<BlockCypherEthereumBlockchain>($"/v1/{_coinType}/{_network}");
        }

        public async Task<IEnumerable<TXRef>> GetTransactionsAsync(string address, Int64 firstBlock, Int64 lastBlock)
        {
            var result = new List<TXRef>();
            var addressRecord = await Get<BlockCypherEthereumAddressRecord>($"/v1/{_coinType}/{_network}/addrs/{HttpUtility.UrlEncode(address)}?token={_token}&after={firstBlock}&before={lastBlock}");
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
    }
}
