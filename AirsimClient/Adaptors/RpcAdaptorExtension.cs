#region MIT License (c) 2018 Isaac Walker

// Copyright 2018 Isaac Walker
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
// associated documentation files (the "Software"), to deal in the Software without restriction,
// including without limitation the rights to use, copy, modify, merge, publish, distribute,
// sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT
// NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT
// OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#endregion MIT License (c) 2018 Isaac Walker

using MsgPackRpc;
using System.Threading.Tasks;

namespace AirsimClient.Adaptors
{
    /// <summary>
    /// Extension methods for built-in adaption with the rpc client
    /// </summary>
    internal static class RpcAdaptorExtension
    {
        /// <summary>
        /// Performs CallAsync when the result needs to be adapted
        /// </summary>
        /// <returns></returns>
        internal static async Task<RpcResult<R>> CallAsyncAdaptor<T,R>(this RpcProxy m_proxy, string method, params object[] args)
            where T : IAdaptable<R>
        {
            Task<RpcResult<T>> output =  m_proxy.CallAsync<T>(method, args);

            Task<RpcResult<R>> returned = output.ContinueWith<RpcResult<R>>(ContinuationFunction<T, R>);

            return await returned;
        }

        private static RpcResult<R> ContinuationFunction<T,R>(Task<RpcResult<T>> Input)
            where T : IAdaptable<R>
        {
            RpcResult<T> Res = Input.Result;
            if (Res.Successful)
                return new RpcResult<R>() { Value = Res.Value.AdaptTo(), Error = Res.Error };

            return new RpcResult<R> { Value = default(R) };
        }
    }
}
