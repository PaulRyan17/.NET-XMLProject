using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using DingTechnicalTest.Models;

namespace DingTechnicalTest.Utils
{
	public static class SerializableHelper {

        public static XmlDocument SerializeRequestToXml(Request request)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Request));
			MemoryStream memStream = new MemoryStream();
			serializer.Serialize(memStream, request);
			memStream.Seek(0, System.IO.SeekOrigin.Begin);
			XmlDocument doc = new XmlDocument();
			doc.Load(memStream);
			memStream.Close();

			return doc;
		}

		public static Response ByteArrayToResponse(byte[] arrBytes)
		{
			XmlDocument doc = new XmlDocument();
			//convert byte array to a string
			Console.WriteLine("Response being parsed to String");
			string str = System.Text.Encoding.Default.GetString(arrBytes);
			Console.WriteLine("Response is");
			Console.WriteLine(str);
			//get the xml data from the message
			str = str.Substring(str.IndexOf('<'));
			Console.WriteLine("Convert string to XML");
			doc.LoadXml(str);
			//create a Response object
			Response res = new Response();

			XmlNodeList nl = doc.SelectNodes("Message");
			//create the response object
			foreach (XmlNode xnode in nl)
			{
				XmlNode headerNode = xnode.SelectSingleNode("Header");
				XmlNode bodyNode = xnode.SelectSingleNode("Body");
				//header data
				res.Header.MessageDate = headerNode["MessageDate"].InnerText;
				res.Header.MessageTime = headerNode["MessageTime"].InnerText;
				//body data
				res.Body.TransactionID = Convert.ToInt32(bodyNode["TransactionID"].InnerText);
				res.Body.TransactionNumber = Convert.ToInt32(bodyNode["TransactionNumber"].InnerText);
				res.Body.PhoneNumber = bodyNode["PhoneNumber"].InnerText;
				res.Body.Amount = bodyNode["Amount"].InnerText;
				res.Body.Result = bodyNode["Result"].InnerText;
			}
			Console.WriteLine("XML now parsed to a Response object");

			return res;
		}
	}
}
