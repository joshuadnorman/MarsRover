using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Models
{
	
	public class MarsRoverModel
	{
		public int yAxis;
		public int xAxis;
		public string direction;
		public string movementError;

		public MarsRoverModel(int x,int y,string d){
			xAxis = x;
			yAxis = y;
			direction = d;
		}

		public void HandleCommand(char instruction,Plateau pLimitChecker)
		{
			switch (instruction)
			{
				case 'L':
					TurnLeft();
					break;
				case 'R':
					TurnRight();
					break;
				case 'M':
					if (this.direction == "N")
					{
						if (this.yAxis + 1 <= pLimitChecker.yLimit)
						{
							this.yAxis += 1;
						} else
						{
							this.movementError = "Movement cannot be out of plateau y bounds";
						}
 					}
					if (this.direction == "E")
					{
						if (this.xAxis + 1 <= pLimitChecker.xLimit)
						{
							this.xAxis += 1;
						}
						else
						{
							this.movementError = "Movement cannot be out of plateau x bounds";
						}
					}
					if (this.direction == "S")
					{
						if (this.yAxis - 1 >= 0)
						{
							this.yAxis -= 1;
						}
						else
						{
							this.movementError = "Movement cannot be out of plateau y bounds";
						}
					}
					if (this.direction == "W")
					{
						if (this.xAxis - 1 >= 0)
						{
							this.xAxis -= 1;
						}
						else
						{
							this.movementError = "Movement cannot be out of plateau x bounds";
						}
					}
					break;
				default:
					break;
			}
		}

		public void TurnLeft()
		{
			switch (this.direction)
			{
				case "N":
					this.direction = "W";
					break;
				case "E":
					this.direction = "N";
					break;
				case "S":
					this.direction = "E";
					break;
				case "W":
					this.direction = "S";
					break;
				default:
					break;
			}
		}

		public void TurnRight()
		{
			switch (this.direction)
			{
				case "N":
					this.direction = "E";
					break;
				case "E":
					this.direction = "S";
					break;
				case "S":
					this.direction = "W";
					break;
				case "W":
					this.direction = "N";
					break;
				default:
					break;
			}
		}



	}
}
