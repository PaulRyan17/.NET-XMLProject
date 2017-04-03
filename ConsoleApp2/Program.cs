using System;
using DingTechnicalTest.API;
using DingTechnicalTest.Models;
using DingTechnicalTest.Utils;

namespace DingTechnicalTest.ConsoleClient
{
	class Program
	{
		static void Main(string[] args)
		{
			
			APIService api = APIService.getApiService();
			//1. create a request object
			//2. serialize object to xml
			//3. send xml as byte array to api
			api.SendRequest(SerializableHelper.SerializeRequestToXml(
				CreateRequest(
				"EZE",
				DateTime.Now.ToString("dd/MM/yyyy"),
				DateTime.Now.ToString("h:mm:ss tt"),
				332526,
				"630000000000",
				"25")));

			Console.ReadKey();
			
		}

		static Request CreateRequest(string identifer, string messageDate, string messageTime, int messageID,string phoneNumber, string amount ) {
			Request request = new Request();
			request.Header.Identifier = identifer;
			request.Header.MessageDate = messageDate;
			request.Header.MessageTime = messageTime;
			request.Body.MessageID = messageID;
			request.Body.PhoneNumber = phoneNumber;
			request.Body.Amount = amount;

			return request;
		}

		
	}
}
