using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MarsRover.Models;

namespace MarsRover.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult RoverLogic(string input)
		{
			var finalOutput="";
			string[] instructions = input.Split("\n");
			var platX = Int32.Parse(instructions[0].Split(" ")[0]);
			var platY = Int32.Parse(instructions[0].Split(" ")[1]);
			Plateau pt = new Plateau(platX,platY); //This will create our limits for later  - We only create one plateau that is shared for all the rovers , 
			//This is a very basic check to see whether there are co-ordinates and instructions for each 
			if ((instructions.Length - 1) % 2 == 0) //if the instructions (excluding plateau limits) is a multiple of 2 , then we assume that there are coordinates and instructions for each rover refer to line above 
			{
				for (int i = 1; i < instructions.Length; i++) //start loop at index 1 to ignore plat limits
				{
					var initRover = instructions[i];
					var roverCommands = instructions[i + 1];
					MarsRoverModel rover = new MarsRoverModel(Int32.Parse(initRover.Split(" ")[0]), Int32.Parse(initRover.Split(" ")[1]), initRover.Split(" ")[2]);
					foreach (char c in roverCommands)
					{
						rover.HandleCommand(c, pt);
					}
					if (rover.movementError == null)
					{
						finalOutput += rover.xAxis + " " + rover.yAxis + " " + rover.direction + "\n";
					} else
					{
						finalOutput += rover.movementError + "\n";
					}
					i++;
				}
			} else
			{
				return Content("An Error Exists in your input string");
			}
			return Content(finalOutput);
		}

		

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
