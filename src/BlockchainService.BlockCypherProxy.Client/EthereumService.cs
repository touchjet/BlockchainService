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
using System.Threading.Tasks;
using System.Web;
using BlockchainService.Abstractions;
using BlockchainService.Abstractions.Models;
using Touchjet.NetworkUtils;

namespace BlockchainService.BlockCypherProxy.Client
{
    public class EthereumService : BaseServiceClient, IEthereumService
    {
        readonly string _siteUrl;
        readonly string _network;
        readonly string _coinType;

        public EthereumService(string siteUrl, string coinType, string network) : base(siteUrl, null)
        {
            _siteUrl = siteUrl;
            _coinType = coinType;
            _network = network;
        }

        public async Task<EthereumTXSkeleton> BroadcastTransactionAsync(EthereumTXSkeleton transaction)
        {
            return await Post<EthereumTXSkeleton, EthereumTXSkeleton>($"/v1/{_coinType}/{_network}/sendtransaction", transaction);
        }

        public async Task<EthereumContract> CallContractMethodAsync(EthereumContractCall contractCall)
        {
            return await Post<EthereumContractCall, EthereumContract>($"/v1/{_coinType}/{_network}/callcontract", contractCall);
        }

        public async Task<IEnumerable<EthereumContract>> CreateContractAsync(EthereumContract contract)
        {
            return await Post<EthereumContract, IEnumerable<EthereumContract>>($"/v1/{_coinType}/{_network}/newcontract", contract);
        }

        public async Task<EthereumTXSkeleton> CreateTransactionAsync(EthereumTX transaction)
        {
            return await Post<EthereumTX, EthereumTXSkeleton>($"/v1/{_coinType}/{_network}/newtransaction", transaction);
        }

        public async Task<EthereumAddressRecord> GetBalanceAsync(string address)
        {
            return await Get<EthereumAddressRecord>($"/v1/{_coinType}/{_network}/balance?address={HttpUtility.UrlEncode(address)}");
        }

        public async Task<EthereumBlockchain> GetBlockchainInfoAsync()
        {
            return await Get<EthereumBlockchain>($"/v1/{_coinType}/{_network}");
        }

        public async Task<IEnumerable<TXRef>> GetTransactionsAsync(string address, long firstBlock, long lastBlock)
        {
            return await Get<IEnumerable<TXRef>>($"/v1/{_coinType}/{_network}/transactions?address={HttpUtility.UrlEncode(address)}&firstBlock={firstBlock}&lastBlock={lastBlock}");
        }
    }
}
