using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Models
{
	public class Plateau
	{
		public int xLimit; //How Tall
		public int yLimit; //How Wide
		public Plateau(int x,int y)
		{
			xLimit = x;
			yLimit = y;
		}
	}
}
