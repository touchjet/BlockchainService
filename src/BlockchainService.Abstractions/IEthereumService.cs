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
using System.Numerics;
using System.Threading.Tasks;
using BlockchainService.Abstractions.Models;

namespace BlockchainService.Abstractions
{
    public interface IEthereumService
    {
        Task<EthereumBlockchain> GetBlockchainInfoAsync();
        Task<EthereumAddressRecord> GetBalanceAsync(string address);
        Task<IEnumerable<TXRef>> GetTransactionsAsync(string address, BigInteger firstBlock, BigInteger lastBlock);
        Task<EthereumTXSkeleton> CreateTransactionAsync(EthereumTX transaction);
        Task<EthereumTXSkeleton> BroadcastTransactionAsync(EthereumTXSkeleton transaction);
        Task<IEnumerable<EthereumContract>> CreateContractAsync(EthereumContract transaction);
        Task<IEnumerable<EthereumContract>> CallContractMethodAsync(EthereumContract transaction, string method);
    }
}
