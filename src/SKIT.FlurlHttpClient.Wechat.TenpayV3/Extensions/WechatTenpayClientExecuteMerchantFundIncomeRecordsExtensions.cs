﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace SKIT.FlurlHttpClient.Wechat.TenpayV3
{
    /// <summary>
    /// 为 <see cref="WechatTenpayClient"/> 提供来账识别相关的 API 扩展方法。
    /// </summary>
    public static class WechatTenpayClientExecuteMerchantFundIncomeRecordsExtensions
    {
        /// <summary>
        /// <para>异步调用 [GET] /merchantfund/merchant/income-records 接口。</para>
        /// <para>REF: https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pay/transfer/chapter3_7.shtml </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.QueryMerchantFundIncomeRecordsResponse> ExecuteQueryMerchantFundIncomeRecordsAsync(this WechatTenpayClient client, Models.QueryMerchantFundIncomeRecordsRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Get, "merchantfund", "merchant", "income-records")
                .SetQueryParam("account_type", request.AccountType)
                .SetQueryParam("date", request.DateString)
                .SetQueryParam("limit", request.Limit);

            if (request.Offset.HasValue)
                flurlReq.SetQueryParam("offset", request.Offset);

            return await client.SendRequestWithJsonAsync<Models.QueryMerchantFundIncomeRecordsResponse>(flurlReq, cancellationToken: cancellationToken);
        }
    }
}
