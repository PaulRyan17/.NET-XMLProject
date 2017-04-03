
namespace DingTechnicalTest.Models
{
    
	public class Request
	{
		public Header Header;
		public Body Body;


		public Request() {
			Header = new Header();
			Body = new Body();
		}
		
    }

    
	public class Header {
		public string Identifier { get; set; }

        public string MessageDate { get; set; }

        public string MessageTime { get; set; }
	}

	public class Body {
        public int MessageID { get; set; }

        public string PhoneNumber { get; set; }

        public string Amount { get; set; }
	}
		
}

