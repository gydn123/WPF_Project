using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject1.Models
{
    class User
    {
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private string userimg;

		public string UserImg
		{
			get { return userimg; }
			set { userimg = value; }
		}


		private int userAge;

		public int UserAge
		{
			get { return userAge; }
			set { userAge = value; }
		}


	}
}
