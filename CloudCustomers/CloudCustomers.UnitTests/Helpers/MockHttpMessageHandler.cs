﻿using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;
using CloudCustomers.API.Models;

namespace CloudCustomers.UnitTests.Helpers
{
	internal static class MockHttpMessageHandler<T>
	{
		internal static Mock<HttpMessageHandler> SetupBasicGetResourceList(List<T> expectedResponse) {
			var mockResponce = new HttpResponseMessage(System.Net.HttpStatusCode.OK) { 
				Content = new StringContent(JsonConvert.SerializeObject(expectedResponse))
			};

			mockResponce.Content.Headers.ContentType =
				new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

			var handlerMock = new Mock<HttpMessageHandler>();

			handlerMock
				.Protected()
				.Setup<Task<HttpResponseMessage>>(
					"SendAsync",
					ItExpr.IsAny<HttpRequestMessage>(),
					ItExpr.IsAny<CancellationToken>())
				.ReturnsAsync(mockResponce);

			return handlerMock;

		}

        internal static Mock<HttpMessageHandler> SetupBasicGetResourceList(List<User> expectedResponse, string endpoint)
        {
            var mockResponce = new HttpResponseMessage(System.Net.HttpStatusCode.OK){
                Content = new StringContent(JsonConvert.SerializeObject(expectedResponse))
            };

            mockResponce.Content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var handlerMock = new Mock<HttpMessageHandler>();

            var httpRequestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(endpoint),
                Method = HttpMethod.Get
            };  

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponce);

            return handlerMock;
        }


        internal static Mock<HttpMessageHandler> SetupReturn404()
        {
            var mockResponce = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
            {
                Content = new StringContent(" ")
            };

            mockResponce.Content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var handlerMock = new Mock<HttpMessageHandler>();

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponce);

            return handlerMock;
        }
    }
}

