using Microsoft.VisualStudio.TestTools.UnitTesting;
using DingTechnicalTest.API;
using DingTechnicalTest.Utils;
using DingTechnicalTest.Models;
using System.Xml;

namespace DingTechnicalTest.Tests
{
	[TestClass]
	public class ApiTests
	{

		[TestMethod]
		public void Create_Byte_Array_From_XML(){

			//add reference to APIService
			APIService api = APIService.getApiService();
			//create a request object for testing
			Request r = new Request();
			r.Header.Identifier = "EZE";
			r.Header.MessageDate = "14/03/2017";
			r.Header.MessageTime = "10:54:25 PM";
			r.Body.MessageID = 332526;
			r.Body.PhoneNumber = "630000000000";
			r.Body.Amount = "25";

			string expected = "<?xml version=\"1.0\"?><Request xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Header><Identifier>EZE</Identifier><MessageDate>14/03/2017</MessageDate><MessageTime>10:54:25 PM</MessageTime></Header><Body><MessageID>332526</MessageID><PhoneNumber>630000000000</PhoneNumber><Amount>25</Amount></Body></Request>";


			XmlDocument doc = SerializableHelper.SerializeRequestToXml(r);

			string actual = System.Text.Encoding.Default.GetString(api.ConvertByteArrayFromXml(doc));

			Assert.AreEqual(expected.ToString(), actual.ToString());	
		}

		[TestMethod]
		public void Create_Response_Object_From_Byte_Array() {


			byte[] response = { 69, 90, 69, 45, 88, 77, 76, 45, 77, 115, 103, 48, 50, 60, 77, 101,
                                115, 115, 97, 103, 101, 62, 13, 10, 32, 32, 60, 72, 101, 97, 100,
                101, 114, 62, 13, 10, 32, 32, 32, 32, 60, 77, 101, 115, 115, 97, 103, 101, 68, 97,
                116, 101, 62, 50, 48, 49, 48, 48, 51, 50, 52, 60, 47, 77, 101, 115, 115, 97, 103,
                101, 68, 97, 116, 101, 62, 13, 10, 32, 32, 32, 32, 60, 77, 101, 115, 115, 97, 103,
                101, 84, 105, 109, 101, 62, 49, 57, 50, 54, 48, 50, 60, 47, 77, 101, 115, 115, 97,
                103, 101, 84, 105, 109, 101, 62, 13, 10, 32, 32, 60, 47, 72, 101, 97, 100, 101, 114,
                62, 13, 10, 32, 32, 60, 66, 111, 100, 121, 62, 13, 10, 32, 32, 32, 32, 60, 84, 114,
                97, 110, 115, 97, 99, 116, 105, 111, 110, 73, 68, 62, 51, 51, 50, 53, 50, 54, 60,
                47, 84, 114, 97, 110, 115, 97, 99, 116, 105, 111, 110, 73, 68, 62, 13, 10, 32, 32,
                32, 32, 60, 84, 114, 97, 110, 115, 97, 99, 116, 105, 111, 110, 78, 117, 109, 98,
                101, 114, 62, 49, 50, 49, 48, 52, 53, 50, 60, 47, 84, 114, 97, 110, 115, 97, 99,
                116, 105, 111, 110, 78, 117, 109, 98, 101, 114, 62, 13, 10, 32, 32, 32, 32, 60, 80,
                104, 111, 110, 101, 78, 117, 109, 98, 101, 114, 62, 54, 51, 48, 48, 48, 48, 48, 48,
                48, 48, 48, 48, 60, 47, 80, 104, 111, 110, 101, 78, 117, 109, 98, 101, 114, 62, 13, 10,
                32, 32, 32, 32, 60, 65, 109, 111, 117, 110, 116, 62, 48, 48, 48, 48, 48, 48, 50, 53, 48,
                48, 60, 47, 65, 109, 111, 117, 110, 116, 62, 13, 10, 32, 32, 32, 32, 60, 82, 101, 115, 117,
                108, 116, 62, 48, 49, 60, 47, 82, 101, 115, 117, 108, 116, 62, 13, 10, 32, 32, 60, 47, 66,
                111, 100, 121, 62, 13, 10, 60, 47, 77, 101, 115, 115, 97, 103, 101, 62 };

			Response expected = new Response();
			expected.Body.Amount = "0000002500";
			expected.Body.PhoneNumber = "630000000000";
			expected.Body.Result = "01";
			expected.Body.TransactionID = 332526;
			expected.Body.TransactionNumber = 1210452;
			expected.Header.MessageDate = "20100324";
			expected.Header.MessageTime = "192602";

			Response actual = SerializableHelper.ByteArrayToResponse(response);
			
			Assert.AreEqual(expected.Body.TransactionID, actual.Body.TransactionID);
			Assert.AreEqual(expected.Body.TransactionNumber, actual.Body.TransactionNumber);
		}
	}
}
