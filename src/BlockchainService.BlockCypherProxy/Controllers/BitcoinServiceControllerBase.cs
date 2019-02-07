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
using System.Threading.Tasks;
using BlockchainService.Abstractions;
using BlockchainService.Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlockchainService.BlockCypherProxy.Controllers
{
    public abstract class BitcoinServiceControllerBase : ControllerBase
    {
        protected IBitcoinService _service;

        [HttpGet]
        public Task<BitcoinBlockchain> BlockchainInfo()
        {
            return _service.GetBlockchainInfoAsync();
        }

        [HttpGet("balance")]
        public Task<BitcoinAddressRecord> Balance(string address)
        {
            return _service.GetBalanceAsync(address);
        }

        [HttpGet("transaction")]
        public async Task<BitcoinTX> Transaction(string hash)
        {
            return await _service.GetTransactionAsync(hash);
        }

        [HttpGet("transactions")]
        public Task<IEnumerable<TXRef>> Transactions(string address, long firstBlock, long lastBlock)
        {
            return _service.GetTransactionsAsync(address, firstBlock, lastBlock);
        }

        [HttpPost("newtransaction")]
        public Task<BitcoinTXSkeleton> CreateTransaction([FromBody] BitcoinTX transaction)
        {
            return _service.CreateTransactionAsync(transaction);
        }

        [HttpPost("sendtransaction")]
        public Task<BitcoinTXSkeleton> BroadcastTransaction([FromBody] BitcoinTXSkeleton transaction)
        {
            return _service.BroadcastTransactionAsync(transaction);
        }

        [HttpPost("pushrawtransaction")]
        public Task<BitcoinTX> PushRawtTransaction([FromBody] BitcoinTXRaw tXRaw)
        {
            return _service.PushRawTransactionAsync(tXRaw);
        }
    }
}
