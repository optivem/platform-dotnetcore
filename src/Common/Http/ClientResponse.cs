﻿using System.Net;

namespace Optivem.Common.Http
{
    public class ClientResponse : IClientResponse
    {
        public ClientResponse(bool isSuccessStatusCode, HttpStatusCode statusCode, string contentString)
        {
            IsSuccessStatusCode = isSuccessStatusCode;
            StatusCode = statusCode;
            ContentString = contentString;
        }

        public bool IsSuccessStatusCode { get; }

        public HttpStatusCode StatusCode { get; }

        public string ContentString { get; }
    }
}