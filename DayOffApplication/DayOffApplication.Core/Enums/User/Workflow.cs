using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOffApplication.Core.Enums.User
{
	/// <summary>
	/// İzin Durumu
	/// </summary>
	public enum Workflow:byte
	{
		None = 0,
		Pending = 10,
		Approved = 20,
		Rejected = 30,
		Exception = 100
	}
}
