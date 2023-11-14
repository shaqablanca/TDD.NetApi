using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net.Http;

namespace CloudCustomers.UnitTests.Helpers
{
	internal static class MockHttpMessageHandler<T>
	{
		internal static Mock<HttpMessageHandler> SetupBasicGetResourceList(List<T> expectedResponce) {
			var mockResponce = new HttpResponseMessage(System.Net.HttpStatusCode.OK) { 
				Content = new StringContent(JsonConvert.SerializeObject(expectedResponce))
			};

			mockResponce.Content.Headers.ContentType =
				new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

			var handlerMock = new Mock<HttpMessageHandler>();

			handlerMock
				.Protected()
				.Setup<Task<HttpResponseMessage>>(
					"sendAysnc",
					ItExpr.IsAny<HttpRequestMessage>(),
					ItExpr.IsAny<CancellationToken>())
				.ReturnsAsync(mockResponce);

			return handlerMock;

		}
	}
}

