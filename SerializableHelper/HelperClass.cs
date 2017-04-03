using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using MessageModels;

namespace HelperNS
{
	public class HelperClass
    {
		public XmlDocument serializeRequestObject(Request request)
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

		public Response ByteArrayToResponseObject(byte[] arrBytes)
		{
			XmlDocument doc = new XmlDocument();
			//convert byte array to a string
			string str = System.Text.Encoding.Default.GetString(arrBytes);
			Console.WriteLine("Response XML is " + str);
			//due to text before the root tag I must use Substring 
			//to get valid xml
			str = str.Substring(str.IndexOf('<'));
			//Console.WriteLine(str);
			//convert the string to XmlDocument
			doc.LoadXml(str);
			//create Response object
			Response res = new Response();
			//select the root node
			XmlNodeList nl = doc.SelectNodes("Message");
			//create the response object
			foreach (XmlNode xnode in nl)
			{
				XmlNode headerNode = xnode.SelectSingleNode("Header");
				XmlNode bodyNode = xnode.SelectSingleNode("Body");
				//header data
				res.header.messageDate = headerNode["MessageDate"].InnerText;
				res.header.messageTime = headerNode["MessageTime"].InnerText;
				//body data
				res.body.transactionID = Convert.ToInt32(bodyNode["TransactionID"].InnerText);
				res.body.transactionNumber = Convert.ToInt32(bodyNode["TransactionNumber"].InnerText);
				res.body.phoneNumber = bodyNode["PhoneNumber"].InnerText;
				res.body.amount = bodyNode["Amount"].InnerText;
				res.body.result = bodyNode["Result"].InnerText;
			}
			//return the response object created from the byte array
			return res;
		}
	}
}
