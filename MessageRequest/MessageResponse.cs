using System.Xml.Serialization;

namespace DingTechnicalTest.Models
{
	public class Response
	{
		public ResponseHeader Header;
		public ResponseBody Body;

		public Response()
		{
			Header = new ResponseHeader();            

			Body = new ResponseBody();
		}

		
	}

	public class ResponseHeader
	{
		
		public string MessageDate { get; set; }
		public string MessageTime { get; set; }
	}
	
	public class ResponseBody
	{
		public int TransactionID { get; set; }
		public int TransactionNumber { get; set; }
		public string PhoneNumber { get; set; }
		public string Amount { get; set; }
		public string Result { get; set; }


	}
}
